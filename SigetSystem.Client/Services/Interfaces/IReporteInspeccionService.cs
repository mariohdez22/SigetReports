using SigetSystem.Shared.DTOs.Hijas;
using SigetSystem.Shared.MPPs;

namespace SigetSystem.Client.Services.Interfaces
{
    public interface IReporteInspeccionService
    {
        Task<APIResponse<List<ReporteInspeccionDTO>>> MostrarReporte(ParametrosPaginacion pp);

        Task<List<ReporteInspeccionDTO>> Reportes();

        Task<ReporteInspeccionDTO> BuscarReporte(int id);

        Task<string> AgregarReporte(ReporteInspeccionDTO dto);

        Task<string> EditarReporte(ReporteInspeccionDTO dto, int id);

        Task<string> EliminarReporte(int id);

    }
}
