using Microsoft.EntityFrameworkCore;
using SigetSystem.Server.Models.Entidades.Hijas;
using SigetSystem.Server.Repositorio.MetodoAplicado.Interfaces.Hijas;
using SigetSystem.Server.Repositorio.MetodoGenerico.Interfaces;
using SigetSystem.Shared.MPPs;
using System.Linq.Expressions;

namespace SigetSystem.Server.Repositorio.MetodoAplicado.Implementacion.Hijas
{
    public class MetodoPersonal : IMetodoPersonal
    {
        private readonly IMetodoGenerico<Personal> _repositorio;

        public MetodoPersonal(IMetodoGenerico<Personal> repositorio)
        {
            _repositorio = repositorio;
        }

        public IQueryable<Personal> OrdenarPersonal(IQueryable<Personal> lista, Expression<Func<Personal, int>> criterioOrden, string FormatoOrden)
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

        public async Task<(List<Personal>, int totalRegistros)> ConsultaPersonal(ParametrosPaginacion pp)
        {
            IQueryable<Personal> lista = await _repositorio.Consulta();

            if (pp.ID1 != 0)
            {
                lista = lista.Where(p => p.IdRangoPersonal == pp.ID1);
            }

            if (pp.ID2 != 0)
            {
                lista = lista.Where(p => p.IdEstadoPersonal == pp.ID2);
            }

            if (!String.IsNullOrEmpty(pp.Buscar))
            {
                lista = lista.Where(
                    b => b.Nombres!.Contains(pp.Buscar) ||
                         b.Celular!.Contains(pp.Buscar) ||
                         b.Email!.Contains(pp.Buscar)   ||
                         b.DUI!.Contains(pp.Buscar)     ||
                         b.Nickname!.Contains(pp.Buscar));
            }

            int totalRegistros = await lista.CountAsync();

            var listaOrdenada = OrdenarPersonal(lista, p => p.IdPersonal, pp.Orden);

            var listaPersonal = await listaOrdenada
                                            .Include(t => t.RangoPersonal)
                                            .Include(e => e.EstadoPersonal)
                                            .Skip((pp.NumeroPagina - 1) * pp.TamañoPagina)
                                            .Take(pp.TamañoPagina)
                                            .ToListAsync();

            return (listaPersonal, totalRegistros);
        }

        public async Task<Personal> BuscarPersonal(int ID)
        {
            return await _repositorio.Buscar(ID);
        }

        public async Task<Personal> CrearPersonal(Personal entidad)
        {
            try
            {
                Personal articulo = await _repositorio.Crear(entidad);

                return articulo;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Personal> EditarPersonal(Personal entidad)
        {
            try
            {
                Personal articulo = await _repositorio.Editar(entidad);

                return articulo;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task BorrarPersonal(Personal entidad)
        {
            try
            {
                await _repositorio.Borrar(entidad);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Personal>> ConsultaPersonalSimple()
        {
            IQueryable<Personal> lista = await _repositorio.Consulta();

            var listaPersonal = await lista.Include(t => t.RangoPersonal)
                                           .Include(e => e.EstadoPersonal)
                                           .ToListAsync();

            return listaPersonal;
        }
    }
}
