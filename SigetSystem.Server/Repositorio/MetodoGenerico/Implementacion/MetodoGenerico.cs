using Microsoft.EntityFrameworkCore;
using SigetSystem.Server.Models.Contexto;
using SigetSystem.Server.Repositorio.MetodoGenerico.Interfaces;

namespace SigetSystem.Server.Repositorio.MetodoGenerico.Implementacion
{
    public class MetodoGenerico<TEntity> : IMetodoGenerico<TEntity> where TEntity : class
    {
        private readonly SigetDbContext _baseDatos;

        public MetodoGenerico(SigetDbContext baseDatos)
        {
            _baseDatos = baseDatos;
        }

        public async Task<IQueryable<TEntity>> Consulta()
        {
            IQueryable<TEntity> lista = _baseDatos.Set<TEntity>();

            return lista;
        }

        public async Task<TEntity> Buscar(int ID)
        {
            try
            {
                return await _baseDatos.Set<TEntity>().FindAsync(ID);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<TEntity> BuscarJob(int ID, string IdModelo)
        {
            try
            {
                return await _baseDatos.Set<TEntity>().FirstOrDefaultAsync(entidad => EF.Property<int>(entidad, IdModelo) == ID);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<TEntity> Crear(TEntity entidad)
        {
            try
            {
                await _baseDatos.Set<TEntity>().AddAsync(entidad);
                await _baseDatos.SaveChangesAsync();

                return entidad;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<TEntity> Editar(TEntity entidad)
        {
            try
            {
                _baseDatos.Set<TEntity>().Update(entidad);
                await _baseDatos.SaveChangesAsync();

                return entidad;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Borrar(TEntity entidad)
        {
            try
            {
                _baseDatos.Set<TEntity>().Remove(entidad);
                await _baseDatos.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
