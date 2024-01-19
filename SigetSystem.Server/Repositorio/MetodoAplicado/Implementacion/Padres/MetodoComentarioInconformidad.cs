using Microsoft.EntityFrameworkCore;
using SigetSystem.Server.Models.Entidades.Padres;
using SigetSystem.Server.Repositorio.MetodoAplicado.Interfaces.Padres;
using SigetSystem.Server.Repositorio.MetodoGenerico.Interfaces;

namespace SigetSystem.Server.Repositorio.MetodoAplicado.Implementacion.Padres
{
    public class MetodoComentarioInconformidad : IMetodoComentariosInconformidad
    {
        private readonly IMetodoLookupGenerico<ComentariosInconformidad> _repoGenerico;

        public MetodoComentarioInconformidad(IMetodoLookupGenerico<ComentariosInconformidad> repoGenerico)
        {
            _repoGenerico = repoGenerico;
        }

        public async Task<List<ComentariosInconformidad>> ConsultaComentariosInconformidad()
        {
            IQueryable<ComentariosInconformidad> lista = await _repoGenerico.Consulta();

            return await lista.ToListAsync();
        }
    }
}
