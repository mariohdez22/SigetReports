using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SigetSystem.Server.Hubs;
using SigetSystem.Server.Models.Entidades.Hijas;
using SigetSystem.Server.Repositorio.MetodoAplicado.Interfaces.Hijas;
using SigetSystem.Server.Repositorio.MetodoGenerico.Interfaces;
using SigetSystem.Shared.MPPs;

namespace SigetSystem.Server.Repositorio.MetodoAplicado.Implementacion.Hijas
{
    public class MetodoOrganismo : IMetodoOrganismo
    {
        private readonly IMetodoGenerico<Organismo> _repoGenerico;
        private readonly IHubContext<HubRegistro> _hubRegistro;

        public MetodoOrganismo(IMetodoGenerico<Organismo> repoGenerico, 
                               IHubContext<HubRegistro> hubRegistro)
        {
            _repoGenerico = repoGenerico;
            _hubRegistro = hubRegistro;
        }

        public IQueryable<Organismo> OrdenarOrganismo(IQueryable<Organismo> lista, Expression<Func<Organismo, int>> criterioOrden, string FormatoOrden)
        {
            var resultado = FormatoOrden == "Ascendente"
                ? lista.OrderBy(criterioOrden)
                : FormatoOrden == "Descendente"
                    ? lista.OrderByDescending(criterioOrden)
                    : null;
            if (resultado == null)
                return lista;
            else
                return resultado;
        }

        public async Task<(List<Organismo>, int totalRegistro)> ConsultaOrganismo(ParametrosPaginacion pp)
        {
            IQueryable<Organismo> lista = await _repoGenerico.Consulta();

            if (pp.ID1 != 0)
            {
                lista = lista.Where(o => o.IdOrganismo == pp.ID1);
            }

            if (pp.ID2 != 0)
            {
                lista = lista.Where(o => o.IdEstadoAcreditacion == pp.ID2);
            }

            if (!String.IsNullOrEmpty(pp.Buscar))
            {
                lista = lista.Where(
                    o => o.CodigoUnico!.Contains(pp.Buscar) ||
                         o.Email!.Contains(pp.Buscar) ||
                         o.NombreOIA!.Contains(pp.Buscar) ||
                         o.Responsable!.Contains(pp.Buscar) ||
                         o.Telefono!.Contains(pp.Buscar)
                );
            }

            int totalRegistro = await lista.CountAsync();

            var listaOrdenada = OrdenarOrganismo(lista, o => o.IdOrganismo, pp.Orden);

            var listaOrganismo = await listaOrdenada
                .Include(e => e.EstadoAcreditacion)
                .Include(p => p.Personal)
                .Skip((pp.NumeroPagina - 1) * pp.TamañoPagina)
                .Take(pp.TamañoPagina)
                .ToListAsync();

            return (listaOrganismo, totalRegistro);
        }

        public async Task<Organismo> Buscar(int id)
        {
            return await _repoGenerico.Buscar(id);
        }

        public async Task<Organismo> CrearOrganismo(Organismo org)
        {
            try
            {
                Organismo organismo = await _repoGenerico.Crear(org);

                await _hubRegistro.Clients.All.SendAsync("ObtencionMensaje", "El registro se creo correctamente.");

                return organismo;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Organismo> EditarOrganismo(Organismo org)
        {
            try
            {
                Organismo organismo = await _repoGenerico.Editar(org);

                await _hubRegistro.Clients.All.SendAsync("RegistroEditado", "El registro se edito correctamente.");

                return organismo;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task BorrarOrganismo(Organismo org)
        {
            try
            {
                await _repoGenerico.Borrar(org);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
