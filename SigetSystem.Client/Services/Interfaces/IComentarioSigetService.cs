using SigetSystem.Shared.DTOs.Hijas;
using SigetSystem.Shared.MPPs;

namespace SigetSystem.Client.Services.Interfaces
{
    public interface IComentarioSigetService
    {
        Task<APIResponse<List<ComentarioSigetDTO>>> MostrarComentarios(ParametrosPaginacion pp);

        Task<ComentarioSigetDTO> BuscarComentario(int id);
    }
}
