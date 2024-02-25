using SigetSystem.Shared.DTOs.Padres;

namespace SigetSystem.Client.Services.Interfaces
{
    public interface IEstadoReporteService
    {
        Task<List<EstadoReporteDTO>> MostrarReporte();
    }
}
