using SigetSystem.Server.Models.Entidades.Independientes;

namespace SigetSystem.Server.Repositorio.MetodoAplicado.Interfaces.Independientes
{
    public interface IMetodoJobReporte
    {
        Task<JobReporte> GuardarJobReporte(int id, string token);

        Task<JobReporte> BuscarJobReporte(int id);

        bool BorrarJobReporte(string token);
    }
}
