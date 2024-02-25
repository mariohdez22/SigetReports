using SigetSystem.Shared.DTOs.Hijas;
using SigetSystem.Shared.MPPs;

namespace SigetSystem.Client.Services.Interfaces
{
    public interface IRequisitoMayorService
    {
        Task<APIResponse<List<RequisitoMayorDTO>>> MostrarRequisitoMayor(ParametrosPaginacion pp);

        Task<List<RequisitoMayorDTO>> MostrarRequisitoMayor();

        Task<RequisitoMayorDTO> BuscarRequisitoMayor(int id);

        Task<string> CrearRequisitoMAyor(RequisitoMayorDTO dto);

        Task<string> EditarRequisito(RequisitoMayorDTO dto, int id);

        Task<string> EliminarRequisito(int id);
    }
}
