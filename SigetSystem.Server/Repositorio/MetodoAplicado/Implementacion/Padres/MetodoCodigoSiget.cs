using SigetSystem.Server.Repositorio.MetodoAplicado.Interfaces.Padres;

namespace SigetSystem.Server.Repositorio.MetodoAplicado.Implementacion.Padres
{
    public class MetodoCodigoSiget : IMetodoCodigoSiget
    {
        private readonly IMetodoGenerico<CodigoSiget> _repoGenerico;

        public MetodoCodigoSiget(IMetodoGenerico<CodigoSiget> repoGenerico)
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
