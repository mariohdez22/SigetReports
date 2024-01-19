using SigetSystem.Server.Repositorio.MetodoAplicado.Interfaces.Padres;

namespace SigetSystem.Server.Repositorio.MetodoAplicado.Implementacion.Padres
{
    public class MetodoCodigoSiget : IMetodoCodigoSiget
    {
        private readonly IMetodoLookupGenerico<CodigoSiget> _repoGenerico;

        public MetodoCodigoSiget(IMetodoLookupGenerico<CodigoSiget> repoGenerico)
        {
            _repoGenerico = repoGenerico;
        }

        public async Task<List<CodigoSiget>> ConsultaCodigoSiget()
        {
            IQueryable<CodigoSiget> lista = await _repoGenerico.Consulta();

            return await lista.ToListAsync();
        }
    }
}
