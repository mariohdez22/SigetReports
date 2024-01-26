using Microsoft.EntityFrameworkCore;
using SigetSystem.Server.Models.Entidades.Padres;
using SigetSystem.Server.Repositorio.MetodoAplicado.Interfaces.Padres;
using SigetSystem.Server.Repositorio.MetodoGenerico.Interfaces;

namespace SigetSystem.Server.Repositorio.MetodoAplicado.Implementacion.Padres
{
    public class MetodoEstadoRepresentante : IMetodoEstadoRepresentante
    {

        private readonly IMetodoLookupGenerico<EstadoRepresentante> _repositorio;

        public MetodoEstadoRepresentante(IMetodoLookupGenerico<EstadoRepresentante> repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<EstadoRepresentante>> ConsultaEstadoRepresentante()
        {
            IQueryable<EstadoRepresentante> listaEstado = await _repositorio.Consulta();

            return await listaEstado.ToListAsync();
        }
    }
}
