using SigetSystem.Server.Models.Contexto;
using SigetSystem.Server.Repositorio.MetodoGenerico.Interfaces;

namespace SigetSystem.Server.Repositorio.MetodoGenerico.Implementacion
{
    public class MetodoLookupGenerico<TEntity> : IMetodoLookupGenerico<TEntity> where TEntity : class
    {
        private readonly SigetDbContext _baseDatos;

        public MetodoLookupGenerico(SigetDbContext baseDatos)
        {
            _baseDatos = baseDatos;
        }

        public async Task<IQueryable<TEntity>> Consulta()
        {
            IQueryable<TEntity> lista = _baseDatos.Set<TEntity>();

            return lista;
        }
    }
}
