using SigetSystem.Server.Repositorio.MetodoAplicado.Interfaces.Padres;

namespace SigetSystem.Server.Repositorio.MetodoAplicado.Implementacion.Padres
{
    public class MetodoCodigoConformidad : IMetodoCodigoConformidad
    {
        private readonly IMetodoLookupGenerico<CodigoConformidad> _repoGenerico;

        public MetodoCodigoConformidad(IMetodoLookupGenerico<CodigoConformidad> repoGenerico)
        {
            _repoGenerico = repoGenerico;
        }

        public async Task<List<CodigoConformidad>> ConsultaCodigoConformidad()
        {
            IQueryable<CodigoConformidad> lista = await _repoGenerico.Consulta();

            return await lista.ToListAsync();
        }
    }
}
