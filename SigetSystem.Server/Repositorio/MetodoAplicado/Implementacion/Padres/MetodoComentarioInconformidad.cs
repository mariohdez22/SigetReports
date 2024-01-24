using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SigetSystem.Server.Models.Entidades.Hijas;
using SigetSystem.Server.Models.Entidades.Padres;
using SigetSystem.Server.Repositorio.MetodoAplicado.Interfaces.Padres;
using SigetSystem.Server.Repositorio.MetodoGenerico.Interfaces;
using SigetSystem.Shared.MPPs;

namespace SigetSystem.Server.Repositorio.MetodoAplicado.Implementacion.Padres
{
    public class MetodoComentarioInconformidad : IMetodoComentariosInconformidad
    {
        private readonly IMetodoGenerico<ComentariosInconformidad> _repoGenerico;

        public MetodoComentarioInconformidad(IMetodoGenerico<ComentariosInconformidad> repoGenerico)
        {
            _repoGenerico = repoGenerico;
        }

        public IQueryable<ComentariosInconformidad> OrdenarComentarios(
            IQueryable<ComentariosInconformidad> lista,
            Expression<Func<ComentariosInconformidad, int>> criterioOrden,
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

        public async Task<(List<ComentariosInconformidad>, int totalRegistro)> ConsultaComentariosInconformidad(ParametrosPaginacion pp)
        {
            IQueryable<ComentariosInconformidad> lista = await _repoGenerico.Consulta();

            int totalRegistro = await lista.CountAsync();
            var listaOrdenada =  OrdenarComentarios(lista, c => c.IdComentarioInconformidad, pp.Orden);

            var listaComentarios = await listaOrdenada
                .Skip((pp.NumeroPagina - 1) * pp.TamañoPagina)
                .Take(pp.TamañoPagina)
                .ToListAsync();

            return (listaComentarios, totalRegistro);
        }

        public async Task<ComentariosInconformidad> BuscarComentariosInconformidad(int id)
        {
            return await _repoGenerico.Buscar(id);
        }

        public async Task<ComentariosInconformidad> CrearComentariosInconformidad(ComentariosInconformidad comentario)
        {
            try
            {
                return await _repoGenerico.Crear(comentario);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<ComentariosInconformidad> EditarComentariosInconformidad(ComentariosInconformidad comentario)
        {
            try
            {
                return await _repoGenerico.Editar(comentario);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task BorrarComentariosInconformidad(ComentariosInconformidad comentario)
        {
            try
            {
                await _repoGenerico.Borrar(comentario);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
