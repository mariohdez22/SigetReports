using Microsoft.EntityFrameworkCore;
using SigetSystem.Server.Models.Entidades.Padres;
using SigetSystem.Server.Repositorio.MetodoAplicado.Interfaces.Padres;
using SigetSystem.Server.Repositorio.MetodoGenerico.Interfaces;

namespace SigetSystem.Server.Repositorio.MetodoAplicado.Implementacion.Padres
{
    public class MetodoEstadoReporte : IMetodoEstadoReporte
    {
        private readonly IMetodoLookupGenerico<EstadoReporte> _repoGenerico;

        public MetodoEstadoReporte(IMetodoLookupGenerico<EstadoReporte> repoGenerico)
        {
            _repoGenerico = repoGenerico;
        }

        public async Task<List<EstadoReporte>> ConsultaEstadoReporte()
        {
            IQueryable<EstadoReporte> lista = await _repoGenerico.Consulta();

            return await lista.ToListAsync();
        }
    }
}
