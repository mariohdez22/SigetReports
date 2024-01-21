using Microsoft.EntityFrameworkCore;
using SigetSystem.Server.Models.Entidades.Padres;
using SigetSystem.Server.Repositorio.MetodoAplicado.Interfaces.Padres;
using SigetSystem.Server.Repositorio.MetodoGenerico.Interfaces;

namespace SigetSystem.Server.Repositorio.MetodoAplicado.Implementacion.Padres
{
    public class MetodoEstadoPersonal : IMetodoEstadoPersonal
    {
        private readonly IMetodoLookupGenerico<EstadoPersonal> _repositorio;

        public MetodoEstadoPersonal(IMetodoLookupGenerico<EstadoPersonal> repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<EstadoPersonal>> ConsultaEstadoPersonal()
        {
            IQueryable<EstadoPersonal> listaEstado = await _repositorio.Consulta();

            return await listaEstado.ToListAsync();
        }
    }
}
