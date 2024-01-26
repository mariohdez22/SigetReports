using SigetSystem.Shared.DTOs.Hijas;
using SigetSystem.Shared.MPPs;

namespace SigetSystem.Client.Services.Interfaces
{
    public interface IPersonalService
    {
        Task<APIResponse<List<PersonalDTO>>> MostrarPersonal(ParametrosPaginacion pp);

        Task<PersonalDTO> BuscarPersonal(int id);

        Task<string> CrearPersonal(PersonalDTO personal);

        Task<string> EditarPersonal(PersonalDTO personal, int id);

        Task<string> EliminarPersonal(int id);
    }
}
