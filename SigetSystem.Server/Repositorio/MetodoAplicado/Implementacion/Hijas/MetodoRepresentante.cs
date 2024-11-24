using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SigetSystem.Server.Hubs;
using SigetSystem.Server.Models.Entidades.Hijas;
using SigetSystem.Server.Repositorio.MetodoAplicado.Interfaces.Hijas;
using SigetSystem.Server.Repositorio.MetodoGenerico.Interfaces;
using SigetSystem.Shared.MPPs;
using System.Linq.Expressions;

namespace SigetSystem.Server.Repositorio.MetodoAplicado.Implementacion.Hijas
{
    public class MetodoRepresentante : IMetodoRepresentante
    {
        private readonly IMetodoGenerico<Representante> _repositorio;
        private readonly IHubContext<HubRegistro> _hubRegistro;

        public MetodoRepresentante(IMetodoGenerico<Representante> repositorio,
                                   IHubContext<HubRegistro> hubRegistro)
        {
            _repositorio = repositorio;
            _hubRegistro = hubRegistro;
        }
        
        public IQueryable<Representante> OrdenarRepresentante(IQueryable<Representante> lista, Expression<Func<Representante, int>> criterioOrden, string FormatoOrden)
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

        public async Task<(List<Representante>, int totalRegistros)> ConsultaRepresentante(ParametrosPaginacion pp)
        {
            IQueryable<Representante> lista = await _repositorio.Consulta();

            if(pp.ID1 != 0)
            {
                lista = lista.Where(p => p.IdEstadoRepresentante == pp.ID1);
            }

            if(pp.ID2 != 0)
            {
                lista = lista.Where(p => p.IdOrganismo == pp.ID2);
            }

            if (!String.IsNullOrEmpty(pp.Buscar))
            {
                lista = lista.Where(
                    b => b.Nombres!.Contains(pp.Buscar)       ||
                        b.Celular!.Contains(pp.Buscar)        ||
                        b.Email!.Contains(pp.Buscar)          ||
                        b.DUI!.Contains(pp.Buscar)            ||
                        b.ComprobanteOIA!.Contains(pp.Buscar) ||
                        b.Nickname!.Contains(pp.Buscar));
            }

            int totalRegistros = await lista.CountAsync();

            var listaOrdenada = OrdenarRepresentante(lista, p => p.IdRepresentante, pp.Orden);

            var listaRepresentante = await listaOrdenada
                                                 .Include(t => t.EstadoRepresentante)
                                                 .Include(e => e.Organismo)
                                                 .Skip((pp.NumeroPagina - 1) * pp.TamañoPagina)
                                                 .Take(pp.TamañoPagina)
                                                 .ToListAsync();

            return (listaRepresentante, totalRegistros);
        }
        public async Task<Representante> BuscarRepresentante(int ID)
        {
            return await _repositorio.Buscar(ID);
        }

        public async Task<Representante> CrearRepresentante(Representante representante)
        {
            try
            {
                Representante representantes = await _repositorio.Crear(representante);

                await _hubRegistro.Clients.All.SendAsync("ObtencionMensaje", "El registro se creo correctamente.");

                return representantes;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Representante> EditarRepresentante(Representante representante)
        {
            try
            {
                Representante representantes = await _repositorio.Editar(representante);

                await _hubRegistro.Clients.All.SendAsync("RegistroEditado", "El registro se edito correctamente.");

                return representantes;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task BorrarRepresentante(Representante representante)
        {
            try
            {
                await _repositorio.Borrar(representante);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //--------------------------------------------------------------------------------------------------

        public async Task<List<Representante>> ConsultaRepresentanteSimple()
        {
            IQueryable<Representante> lista = await _repositorio.Consulta();

            var listaRepresentante = await lista.Include(t => t.EstadoRepresentante)
                                          .Include(e => e.Organismo)
                                          .ToListAsync();

            return listaRepresentante;
        }
    }
}
