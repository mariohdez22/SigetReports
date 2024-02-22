using SigetSystem.Shared.DTOs.Hijas;
using SigetSystem.Shared.DTOs.Padres;
using SigetSystem.Shared.MPPs;

namespace SigetSystem.Client.Services.Interfaces
{
    public interface IRepresentanteService
    {

        Task<APIResponse<List<RepresentanteDTO>>> MostrarRepresentante(ParametrosPaginacion pp);

        Task<RepresentanteDTO> BuscarRepresentante(int id);

        Task<string> CrearRepresentante(RepresentanteDTO representante);

        Task<string> EditarRepresentante(RepresentanteDTO representante, int id);

        Task<string> EliminarRepresentante(int id);
    }
}
