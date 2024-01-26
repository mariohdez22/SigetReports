using Microsoft.EntityFrameworkCore;
using SigetSystem.Server.Models.Entidades.Padres;
using SigetSystem.Server.Repositorio.MetodoAplicado.Interfaces.Padres;
using SigetSystem.Server.Repositorio.MetodoGenerico.Interfaces;

namespace SigetSystem.Server.Repositorio.MetodoAplicado.Implementacion.Padres
{
    public class MetodoEstadoComentario : IMetodoEstadoComentario
    {
        private readonly IMetodoLookupGenerico<EstadoComentario> _repoGenerico;

        public MetodoEstadoComentario(IMetodoLookupGenerico<EstadoComentario> repoGenerico)
        {
            _repoGenerico = repoGenerico;
        }

        public async Task<List<EstadoComentario>> Consulta()
        {
            IQueryable<EstadoComentario> lista = await _repoGenerico.Consulta();

            return await lista.ToListAsync();
        }
    }
}
