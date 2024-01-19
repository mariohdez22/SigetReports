using Microsoft.EntityFrameworkCore;
using SigetSystem.Server.Models.Entidades.Padres;
using SigetSystem.Server.Repositorio.MetodoAplicado.Interfaces.Padres;
using SigetSystem.Server.Repositorio.MetodoGenerico.Interfaces;

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
