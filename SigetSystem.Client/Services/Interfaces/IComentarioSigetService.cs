using SigetSystem.Shared.DTOs.Hijas;
using SigetSystem.Shared.MPPs;

namespace SigetSystem.Client.Services.Interfaces
{
    public interface IComentarioSigetService
    {
        Task<APIResponse<List<ComentarioSigetDTO>>> MostrarComentarios(ParametrosPaginacion pp);

        Task<ComentarioSigetDTO> BuscarComentario(int id);

        Task<string> CrearComentario(ComentarioSigetDTO comentario);

        Task<string> EditarComentario(ComentarioSigetDTO comentario, int id);

        Task<string> EliminarComentario(int id);
    }
}
