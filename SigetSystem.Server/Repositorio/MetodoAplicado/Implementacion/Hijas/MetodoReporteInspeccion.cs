using System.Linq.Expressions;
using Hangfire;
using Microsoft.EntityFrameworkCore;
using SigetSystem.Shared;
using SigetSystem.Server.Models.Entidades.Hijas;
using SigetSystem.Server.Repositorio.MetodoAplicado.Interfaces.Hijas;
using SigetSystem.Server.Repositorio.MetodoGenerico.Interfaces;
using SigetSystem.Shared.MPPs;
using System.Collections.Generic;

namespace SigetSystem.Server.Repositorio.MetodoAplicado.Implementacion.Hijas
{
    public class MetodoReporteInspeccion : IMetodoReporteInspeccion
    {
        private readonly IMetodoGenerico<ReporteInspeccion> _repoGenerico;
        private readonly IBackgroundJobClient _bjob;

        public MetodoReporteInspeccion(IMetodoGenerico<ReporteInspeccion> repoGenerico, IBackgroundJobClient bjob)
        {
            _repoGenerico = repoGenerico;
            _bjob = bjob;
        }

        public IQueryable<ReporteInspeccion> OrdenarReportes(
            IQueryable<ReporteInspeccion> lista,
            Expression<Func<ReporteInspeccion, int>> criterioOrden,
            string formatoOrden
        )
        {
            var resultado = formatoOrden == "Ascendente"
                ? lista.OrderBy(criterioOrden)
                : formatoOrden == "Descendente"
                    ? lista.OrderByDescending(criterioOrden)
                    : null;

            if (resultado == null)
            {
                return lista;
            }
            else
            {
                return resultado;
            }
        }

        public async Task<(List<ReporteInspeccion>, int totalRegistros)> ConsultaReporteInspeccion(
            ParametrosPaginacion pp)
        {
            IQueryable<ReporteInspeccion> lista = await _repoGenerico.Consulta();

            if (pp.ReporteFiltro?.IdDepartamentoInstalacion != 0)
            {
                lista = lista.Where(p => p.IdDepartamentoInstalacion == pp.ReporteFiltro.IdDepartamentoInstalacion);
            }

            if (pp.ReporteFiltro?.IdMunicipioInstalacion != 0)
            {
                lista = lista.Where(p => p.IdMunicipioInstalacion == pp.ReporteFiltro.IdMunicipioInstalacion);
            }

            if (pp.ReporteFiltro?.IdCodigoConformidad != 0)
            {
                lista = lista.Where(p => p.IdCodigoConformidad == pp.ReporteFiltro.IdCodigoConformidad);
            }

            if (pp.ReporteFiltro?.IdCodigoSiget != 0)
            {
                lista = lista.Where(p => p.IdCodigoSiget == pp.ReporteFiltro.IdCodigoSiget);
            }

            if (pp.ReporteFiltro?.IdEstadoReporte != 0)
            {
                lista = lista.Where(p => p.IdEstadoReporte == pp.ReporteFiltro.IdEstadoReporte);
            }

            if (!String.IsNullOrEmpty(pp.Buscar))
            {
                lista = lista.Where(r =>
                    r.CodigoDepartamentalInstElectrica!.Contains(pp.Buscar) ||
                    r.ColoniaInstalacion!.Contains(pp.Buscar) ||
                    r.CodigoDepartamentalInstElectrica!.Contains(pp.Buscar) ||
                    r.CodigoInspeccion!.Contains(pp.Buscar) ||
                    r.CodigoMunicipioInstalacion!.Contains(pp.Buscar) ||
                    r.DireccionInstalacion!.Contains(pp.Buscar) ||
                    r.EspecificacionesCertificado!.Contains(pp.Buscar) ||
                    r.NombreSolicitante!.Contains(pp.Buscar) ||
                    r.NumeroCreditoFiscal!.Contains(pp.Buscar) ||
                    r.FechaDepagoSolicitante.ToString().Contains(pp.Buscar) ||
                    r.FechaEntregaConformidad.ToString().Contains(pp.Buscar) ||
                    r.FechaPrimeraInspeccion.ToString().Contains(pp.Buscar) ||
                    r.FechaUltimaInspeccion.ToString().Contains(pp.Buscar)
                );
            }

            int totalRegistros = await lista.CountAsync();

            var listaOrdenada = OrdenarReportes(lista, p => p.IdReporteInspeccion, pp.Orden);

            var listaReportes = await listaOrdenada
                .Include(o => o.Organismo)
                .Include(r => r.Representante)
                .Include(dp => dp.DepartamentoInstalacion)
                .Include(m => m.MunicipioInstalacion)
                .Include(c => c.CodigoConformidad)
                .Include(s => s.CodigoSiget)
                .Include(rqmr => rqmr.RequisitoMenor)
                .Include(rqmy => rqmy.RequisitoMayor)
                .Include(e => e.EstadoReporte)
                .Skip((pp.NumeroPagina - 1) * pp.TamañoPagina)
                .Take(pp.TamañoPagina)
                .ToListAsync();

            return (listaReportes, totalRegistros);
        }

        public async Task<ReporteInspeccion> BuscarReporte(int id)
        {
            return await _repoGenerico.Buscar(id);
        }

        public async Task<ReporteInspeccion> CrearReporte(ReporteInspeccion reporte)
        {
            try
            {
                return await _repoGenerico.Crear(reporte);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ReporteInspeccion> EditarReporte(ReporteInspeccion reporte)
        {
            try
            {
                return await _repoGenerico.Editar(reporte);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task BorrarReporte(ReporteInspeccion reporte)
        {
            try
            {
                await _repoGenerico.Borrar(reporte);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<(int id, string tokenJob)> GenerarEdicionPrograma(int idReporte)
        {
            try
            {
                var reporte = await BuscarReporte(idReporte);

                ReporteInspeccion reporteUpdate = new ReporteInspeccion()
                {
                    IdReporteInspeccion = reporte.IdReporteInspeccion,
                    CodigoInspeccion = reporte.CodigoInspeccion,
                    NombreSolicitante = reporte.NombreSolicitante,
                    CodigoDepartamentalInstElectrica = reporte.CodigoDepartamentalInstElectrica,
                    CodigoMunicipioInstalacion = reporte.CodigoMunicipioInstalacion,
                    ColoniaInstalacion = reporte.ColoniaInstalacion,
                    DireccionInstalacion = reporte.DireccionInstalacion,
                    FechaDepagoSolicitante = reporte.FechaDepagoSolicitante,
                    FechaPrimeraInspeccion = reporte.FechaPrimeraInspeccion,
                    FechaUltimaInspeccion = reporte.FechaUltimaInspeccion,
                    FechaEntregaConformidad = reporte.FechaEntregaConformidad,
                    EspecificacionesCertificado = reporte.EspecificacionesCertificado,
                    MontoSolicitante = reporte.MontoSolicitante,
                    NumeroCreditoFiscal = reporte.NumeroCreditoFiscal,


                    IdOrganismo = reporte.IdOrganismo,
                    IdRepresentante = reporte.IdRepresentante,
                    IdDepartamentoInstalacion = reporte.IdDepartamentoInstalacion,
                    IdMunicipioInstalacion = reporte.IdMunicipioInstalacion,
                    IdCodigoConformidad = reporte.IdCodigoConformidad,
                    IdCodigoSiget = reporte.IdCodigoSiget,
                    IdRequisitoMenor = reporte.IdRequisitoMenor,
                    IdRequisitoMayor = reporte.IdRequisitoMayor,
                    IdEstadoReporte = 3
                };

                var token = _bjob.Schedule(() => EditarReporte(reporteUpdate), TimeSpan.FromMinutes(5));

                return (reporte.IdReporteInspeccion, token);
            } 
            catch (Exception)
            {
                throw;
            }
        }

        //--------------------------------------------------------------------------------------------------

        public async Task<List<ReporteInspeccion>> ConsultaReporteSimple()
        {
            IQueryable<ReporteInspeccion> lista = await _repoGenerico.Consulta();

            var listaReporte = await lista.Include(o => o.Organismo)
                                          .Include(r => r.Representante)
                                          .Include(dp => dp.DepartamentoInstalacion)
                                          .Include(m => m.MunicipioInstalacion)
                                          .Include(c => c.CodigoConformidad)
                                          .Include(s => s.CodigoSiget)
                                          .Include(rqmr => rqmr.RequisitoMenor)
                                          .Include(rqmy => rqmy.RequisitoMayor)
                                          .Include(e => e.EstadoReporte)
                                          .ToListAsync();

            return listaReporte;
        }
    }
}
