using Microsoft.EntityFrameworkCore;
using SigetSystem.Server.Models.Entidades.Hijas;
using SigetSystem.Server.Repositorio.MetodoAplicado.Interfaces.Hijas;
using SigetSystem.Server.Repositorio.MetodoGenerico.Interfaces;
using SigetSystem.Shared.MPPs;
using System.Linq.Expressions;

namespace SigetSystem.Server.Repositorio.MetodoAplicado.Implementacion.Hijas
{
    public class MetodoComentarioSiget : IMetodoComentarioSiget
    {
        private readonly IMetodoGenerico<ComentarioSiget> _repositorio;

        public MetodoComentarioSiget(IMetodoGenerico<ComentarioSiget> repositorio)
        {
            _repositorio = repositorio;
        }

        public IQueryable<ComentarioSiget> OrdenarComentario(IQueryable<ComentarioSiget> lista, Expression<Func<ComentarioSiget, int>> criterioOrden, string FormatoOrden)
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

        public async Task<(List<ComentarioSiget>, int totalRegistros)> ConsultaComentario(ParametrosPaginacion pp)
        {
            IQueryable<ComentarioSiget> lista = await _repositorio.Consulta();

            if (pp.ID1 != 0)
            {
                lista = lista.Where(p => p.IdTipoConformidad == pp.ID1);
            }

            //if (pp.ID2 != 0)
            //{
            //    lista = lista.Where(p => p.IdRangoPersonal == pp.ID2);
            //}

            if (!String.IsNullOrEmpty(pp.Buscar))
            {
                lista = lista.Where(
                    b => b.Comentario!.Contains(pp.Buscar) ||
                         b.MotivoComentario!.Contains(pp.Buscar) ||
                         b.Representante.Nombres!.Contains(pp.Buscar) ||
                         b.Personal.Nombres!.Contains(pp.Buscar));
            }

            int totalRegistros = await lista.CountAsync();

            var listaOrdenada = OrdenarComentario(lista, p => p.IdComentario, pp.Orden);

            var listaComentario = await listaOrdenada
                                            .Include(t => t.TipoConformidad)
                                            .Include(r => r.ReporteInspeccion)
                                            .Include(r => r.Representante)
                                            .Include(p => p.Personal)
                                            .Skip((pp.NumeroPagina - 1) * pp.TamañoPagina)
                                            .Take(pp.TamañoPagina)
                                            .ToListAsync();

            return (listaComentario, totalRegistros);
        }

        public async Task<ComentarioSiget> BuscarComentario(int ID)
        {
            return await _repositorio.Buscar(ID);
        }

        public async Task<ComentarioSiget> CrearComentario(ComentarioSiget entidad)
        {
            try
            {
                ComentarioSiget articulo = await _repositorio.Crear(entidad);

                return articulo;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ComentarioSiget> EditarComentario(ComentarioSiget entidad)
        {
            try
            {
                ComentarioSiget articulo = await _repositorio.Editar(entidad);

                return articulo;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task BorrarComentario(ComentarioSiget entidad)
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
    }
}
