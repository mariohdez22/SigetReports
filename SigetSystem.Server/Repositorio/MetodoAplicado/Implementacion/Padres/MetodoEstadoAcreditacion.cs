using Microsoft.EntityFrameworkCore;
using SigetSystem.Server.Models.Entidades.Padres;
using SigetSystem.Server.Repositorio.MetodoAplicado.Interfaces.Padres;
using SigetSystem.Server.Repositorio.MetodoGenerico.Interfaces;

namespace SigetSystem.Server.Repositorio.MetodoAplicado.Implementacion.Padres
{
    public class MetodoEstadoAcreditacion : IMetodoEstadoAcreditacion
    {
        private readonly IMetodoLookupGenerico<EstadoAcreditacion> _repoGenerico;

        public MetodoEstadoAcreditacion(IMetodoLookupGenerico<EstadoAcreditacion> repoGenerico)
        {
            _repoGenerico = repoGenerico;
        }

        public async Task<List<EstadoAcreditacion>> ConsultaEstadoAcreditacion()
        {
            IQueryable<EstadoAcreditacion> lista = await _repoGenerico.Consulta();

            return await lista.ToListAsync();
        }
    }
}
