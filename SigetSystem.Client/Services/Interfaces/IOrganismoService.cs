using SigetSystem.Shared.DTOs.Hijas;
using SigetSystem.Shared.MPPs;

namespace SigetSystem.Client.Services.Interfaces
{
    public interface IOrganismoService
    {
        Task<APIResponse<List<OrganismoDTO>>> MostrarOrganismos(ParametrosPaginacion pp);

        Task<List<OrganismoDTO>> MostrarOrganismos();

        Task<OrganismoDTO> BuscarOrganismo(int id);

        Task<string> AgregarOrganismo(OrganismoDTO dto);

        Task<string> EditarOrganismo(OrganismoDTO dto, int id);

        Task<string> EliminarOrganismo(int id);
    }
}
