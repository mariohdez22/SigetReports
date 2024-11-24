using System.Linq.Expressions;

namespace SigetSystem.Server.Repositorio.MetodoGenerico.Interfaces
{
    public interface IMetodoGenerico<TEntity> where TEntity : class
    {
        Task<IQueryable<TEntity>> Consulta();

        Task<TEntity> Buscar(int ID);

        Task<TEntity> BuscarPorCondicion(Expression<Func<TEntity, bool>> condicion,
        params Expression<Func<TEntity, object>>[] includes);

        Task<TEntity> BuscarJob(int ID, string IdModelo);

        Task<TEntity> Crear(TEntity entidad);

        Task<TEntity> Editar(TEntity entidad);

        Task Borrar(TEntity entidad);
    }
}
