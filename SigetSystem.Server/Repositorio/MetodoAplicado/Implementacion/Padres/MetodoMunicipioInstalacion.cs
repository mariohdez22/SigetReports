using Microsoft.EntityFrameworkCore;
using SigetSystem.Server.Models.Entidades.Padres;
using SigetSystem.Server.Repositorio.MetodoAplicado.Interfaces.Padres;
using SigetSystem.Server.Repositorio.MetodoGenerico.Interfaces;

namespace SigetSystem.Server.Repositorio.MetodoAplicado.Implementacion.Padres
{
    public class MetodoMunicipioInstalacion : IMetodoMunicipioInstalacion
    {
        private readonly IMetodoLookupGenerico<MunicipioInstalacion> _repoGenerico;

        public MetodoMunicipioInstalacion(IMetodoLookupGenerico<MunicipioInstalacion> repoGenerico)
        {
            _repoGenerico = repoGenerico;
        }

        public async Task<List<MunicipioInstalacion>> ConsultaMunicipioInstalacion()
        {
            IQueryable<MunicipioInstalacion> lista = await _repoGenerico.Consulta();

            return await lista.ToListAsync();
        }
    }
}
