using SigetSystem.Server.Repositorio.MetodoAplicado.Interfaces.Padres;

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
