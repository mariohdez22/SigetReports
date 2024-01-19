using Microsoft.EntityFrameworkCore;
using SigetSystem.Server.Models.Entidades.Padres;
using SigetSystem.Server.Repositorio.MetodoAplicado.Interfaces.Padres;
using SigetSystem.Server.Repositorio.MetodoGenerico.Interfaces;

namespace SigetSystem.Server.Repositorio.MetodoAplicado.Implementacion.Padres
{
    public class MetodoDepartamentoInstalacion : IMetodoDepartamentoInstalacion
    {
        private readonly IMetodoLookupGenerico<DepartamentoInstalacion> _repoGenerico;

        public MetodoDepartamentoInstalacion(IMetodoLookupGenerico<DepartamentoInstalacion> repoGenerico)
        {
            _repoGenerico = repoGenerico;
        }

        public async Task<List<DepartamentoInstalacion>> ConsultaDepartamentoInstalacion()
        {
            IQueryable<DepartamentoInstalacion> lista = await _repoGenerico.Consulta();

            return await lista.ToListAsync();
        }
    }
}
