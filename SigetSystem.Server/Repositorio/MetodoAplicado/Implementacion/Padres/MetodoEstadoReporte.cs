using SigetSystem.Server.Repositorio.MetodoAplicado.Interfaces.Padres;

namespace SigetSystem.Server.Repositorio.MetodoAplicado.Implementacion.Padres
{
    public class MetodoEstadoReporte : IMetodoEstadoReporte
    {
        private readonly IMetodoLookupGenerico<EstadoReporte> _repoGenerico;

        public MetodoEstadoReporte(IMetodoLookupGenerico<EstadoReporte> repoGenerico)
        {
            _repoGenerico = repoGenerico;
        }

        public Task<List<EstadoReporte>> ConsultaEstadoReporte()
        {
            IQueryable<EstadoReporte> lista = await _repoGenerico.Consulta();

            return await lista.ToListAsync();
        }
    }
}
