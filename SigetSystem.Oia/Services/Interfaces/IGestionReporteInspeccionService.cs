using SigetSystem.Shared.DTOs.Hijas;
using SigetSystem.Shared.MPPs;

namespace SigetSystem.Oia.Services.Interfaces
{
    public interface IGestionReporteInspeccionService
    {
        Task<List<ReporteInspeccionDTO>> obtenerReportes();
        Task<ReporteInspeccionDTO> obtenerReporte(int id);
    }
}
