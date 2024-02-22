using SigetSystem.Shared.DTOs.Hijas;
using SigetSystem.Shared.MPPs;

namespace SigetSystem.Client.Services.Interfaces
{
    public interface IRequisitoMenorService
    {
        Task<APIResponse<List<RequisitoMenorDTO>>> MostrarRequisitoMenor(ParametrosPaginacion pp);

        Task<RequisitoMenorDTO> BuscarRequisitoMenor(int id);

        Task<string> CrearRequisitoMenor(RequisitoMenorDTO dto);

        Task<string> EditarRequisito(RequisitoMenorDTO dto, int id);

        Task<string> EliminarRequisito(int id);
    }
}
