using SigetSystem.Server.Models.Entidades.Padres;

namespace SigetSystem.Server.Repositorio.MetodoAplicado.Interfaces.Padres
{
    public interface IMetodoRangoPersonal
    {
        Task<List<RangoPersonal>> ConsultaRangoPersonal();
    }
}
