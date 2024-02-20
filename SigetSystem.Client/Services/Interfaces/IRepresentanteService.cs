using SigetSystem.Shared.DTOs.Hijas;
using SigetSystem.Shared.MPPs;

namespace SigetSystem.Client.Services.Interfaces
{
    public interface IRepresentanteService
    {
        Task<APIResponse<List<RepresentanteDTO>>> MostrarRepresentantes(ParametrosPaginacion pp);

        Task<RepresentanteDTO> BuscarRepresentante(int id);

        Task<string> CrearRepresentante(RepresentanteDTO dto);

        Task<string> EditarRepresentante(RepresentanteDTO dto, int id);

        Task<string> EliminarRepresentante(int id);
    }
}
