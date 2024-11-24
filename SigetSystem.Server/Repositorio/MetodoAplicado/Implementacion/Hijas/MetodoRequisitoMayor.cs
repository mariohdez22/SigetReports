using System.Linq.Expressions;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SigetSystem.Server.Hubs;
using SigetSystem.Server.Models.Entidades.Hijas;
using SigetSystem.Server.Repositorio.MetodoAplicado.Interfaces.Hijas;
using SigetSystem.Server.Repositorio.MetodoGenerico.Interfaces;
using SigetSystem.Shared.MPPs;

namespace SigetSystem.Server.Repositorio.MetodoAplicado.Implementacion.Hijas
{
    public class MetodoRequisitoMayor : IMetodoRequisitoMayor
    {
        private readonly IMetodoGenerico<RequisitoMayor> _repoGenerico;
        private readonly IHubContext<HubRegistro> _hubRegistro;

        public MetodoRequisitoMayor(IMetodoGenerico<RequisitoMayor> repoGenerico, 
                                    IHubContext<HubRegistro> hubRegistro)
        {
            _repoGenerico = repoGenerico;
            _hubRegistro = hubRegistro;
        }

        public IQueryable<RequisitoMayor> OrdenarRequisitos
        (
            IQueryable<RequisitoMayor> lista,
            Expression<Func<RequisitoMayor, int>> criterioOrdern,
            string formatoOrden
        )
        {
            var resultado = formatoOrden == "Ascendente"
                ? lista.OrderBy(criterioOrdern)
                : formatoOrden == "Descendente"
                    ? lista.OrderByDescending(criterioOrdern)
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

        public async Task<(List<RequisitoMayor>, int totalRegistros)> ConsultaRequisitoMayor(ParametrosPaginacion pp)
        {
            IQueryable<RequisitoMayor> lista = await _repoGenerico.Consulta();

            if (pp.ID1 != 0)
            {
                lista = lista.Where(p => p.IdOrganismo == pp.ID1);
            }

            if (pp.ID2 != 0)
            {
                lista = lista.Where(p => p.IdRepresentante == pp.ID2);
            }

            if (!String.IsNullOrEmpty(pp.Buscar))
            {
                lista = lista.Where(c =>
                    c.CodigoRequisito!.Contains(pp.Buscar) ||
                    c.ArchivoCopiaCarnetElectricista!.Contains(pp.Buscar) ||
                    c.ArchivoCopiaDuiElectricista!.Contains(pp.Buscar) ||
                    c.ArchivoCopiaDuiPropietario!.Contains(pp.Buscar) ||
                    c.ArchivoCopiaDuiRetiro!.Contains(pp.Buscar) ||
                    c.ArchivoCopiaFacturaDeMateriales!.Contains(pp.Buscar) ||
                    c.ArchivoCopiaGarantiaDeTransformador!.Contains(pp.Buscar) ||
                    c.ArchivoPlanosDualesDeConstruccion!.Contains(pp.Buscar) ||
                    c.ArchivoPlanosDualesDeDiseñoMinimo!.Contains(pp.Buscar) ||
                    c.FechaRegistro!.ToString().Contains(pp.Buscar) ||
                    c.Organismo.CodigoUnico!.Contains(pp.Buscar) ||
                    c.Organismo.NombreOIA!.Contains(pp.Buscar) ||
                    c.Representante.Nombres!.Contains(pp.Buscar)
                );
            }

            int totalRegistros = await lista.CountAsync();

            var listaOrdenada = OrdenarRequisitos(lista, p => p.IdMayores, pp.Orden);

            var listaRequisitos = await 
                listaOrdenada
                    .Include(o => o.Organismo)
                    .Include(r => r.Representante)
                    .Skip((pp.NumeroPagina - 1) * pp.TamañoPagina)
                    .Take(pp.NumeroPagina)
                    .ToListAsync();

            return (listaRequisitos, totalRegistros);
        }

        public async Task<RequisitoMayor> BuscarRequisitoMayor(int id)
        {
            return await _repoGenerico.Buscar(id);
        }

        public async Task<RequisitoMayor> CrearRequisitoMayor(RequisitoMayor requisitoMayor)
        {
            try
            {
                RequisitoMayor requisitoMayores = await _repoGenerico.Crear(requisitoMayor);

                await _hubRegistro.Clients.All.SendAsync("ObtencionMensaje", "El registro se creo correctamente.");

                return requisitoMayores;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<RequisitoMayor> EditarRequisitoMayor(RequisitoMayor requisitoMayor)
        {
            try
            {
                RequisitoMayor requisito = await _repoGenerico.Editar(requisitoMayor);

                await _hubRegistro.Clients.All.SendAsync("RegistroEditado", "El registro se edito correctamente.");

                return requisito;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task BorrarRequisitoMayor(RequisitoMayor requisitoMayor)
        {
            try
            {
                await _repoGenerico.Borrar(requisitoMayor);
            }
            catch (Exception)
            {

            }
        }
    }
}
