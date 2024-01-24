﻿using System.Linq.Expressions;
using Hangfire;
using Microsoft.EntityFrameworkCore;
using SigetSystem.Shared;
using SigetSystem.Server.Models.Entidades.Hijas;
using SigetSystem.Server.Repositorio.MetodoAplicado.Interfaces.Hijas;
using SigetSystem.Server.Repositorio.MetodoGenerico.Interfaces;
using SigetSystem.Shared.MPPs;

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

            if (pp.ID1 != 0)
            {
                lista = lista.Where(p => p.IdEstadoReporte == pp.ID1);
            }

            //if (pp.ID2 != 0)
            //{
            //    lista = lista.Where(p => p.idEstadoReporte == pp.ID2);
            //}

            int totalRegistros = await lista.CountAsync();

            var listaOrdenada = OrdenarReportes(lista, p => p.IdReporteInspeccion, pp.Orden);

            var listaReportes = await listaOrdenada
                .Include(o => o.IdOrganismo)
                .Include(r => r.IdRepresentante)
                .Include(dp => dp.IdDepartamentoInstalacion)
                .Include(m => m.IdMunicipioInstalacion)
                .Include(c => c.IdCodigoConformidad)
                .Include(s => s.IdCodigoSiget)
                .Include(rqmr => rqmr.IdRequisitoMenor)
                .Include(rqmy => rqmy.IdRequisitoMayor)
                .Include(e => e.IdEstadoReporte)
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
    }
}
