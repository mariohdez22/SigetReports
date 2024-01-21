using Microsoft.EntityFrameworkCore;
using SigetSystem.Server.Models.Entidades.Padres;
using SigetSystem.Server.Repositorio.MetodoAplicado.Interfaces.Padres;
using SigetSystem.Server.Repositorio.MetodoGenerico.Interfaces;

namespace SigetSystem.Server.Repositorio.MetodoAplicado.Implementacion.Padres
{
    public class MetodoTipoConformidad : IMetodoTipoConformidad
    {
        private readonly IMetodoLookupGenerico<TipoConformidad> _repositorio;

        public MetodoTipoConformidad(IMetodoLookupGenerico<TipoConformidad> repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<TipoConformidad>> ConsultaTipoConformidad()
        {
            IQueryable<TipoConformidad> listaTipo = await _repositorio.Consulta();

            return await listaTipo.ToListAsync();
        }
    }
}
