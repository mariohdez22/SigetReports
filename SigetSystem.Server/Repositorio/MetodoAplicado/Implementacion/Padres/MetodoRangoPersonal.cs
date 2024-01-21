using Microsoft.EntityFrameworkCore;
using SigetSystem.Server.Models.Entidades.Padres;
using SigetSystem.Server.Repositorio.MetodoAplicado.Interfaces.Padres;
using SigetSystem.Server.Repositorio.MetodoGenerico.Interfaces;

namespace SigetSystem.Server.Repositorio.MetodoAplicado.Implementacion.Padres
{
    public class MetodoRangoPersonal : IMetodoRangoPersonal
    {
        private readonly IMetodoLookupGenerico<RangoPersonal> _repositorio;

        public MetodoRangoPersonal(IMetodoLookupGenerico<RangoPersonal> repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<RangoPersonal>> ConsultaRangoPersonal()
        {
            IQueryable<RangoPersonal> listaRango = await _repositorio.Consulta();

            return await listaRango.ToListAsync();
        }
    }
}
