using SigetSystem.Server.Models.Entidades.Padres;

namespace SigetSystem.Server.Repositorio.MetodoAplicado.Interfaces.Padres
{
    public interface IMetodoEstadoPersonal
    {
        Task<List<EstadoPersonal>> ConsultaEstadoPersonal();
    }
}
