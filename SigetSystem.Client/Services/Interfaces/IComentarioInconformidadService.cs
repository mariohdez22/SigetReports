using SigetSystem.Shared.DTOs.Hijas;
using SigetSystem.Shared.DTOs.Padres;
using SigetSystem.Shared.MPPs;

namespace SigetSystem.Client.Services.Interfaces
{
    public interface IComentarioInconformidadService
    {
        Task<APIResponse<List<ComentariosInconformidadDTO>>> MostrarComentarioInconformidad(ParametrosPaginacion pp);

        Task<List<ComentariosInconformidadDTO>> MostrarComentarioInconformidad();

        Task<ComentariosInconformidadDTO> BuscarComentarioInconformidad(int id);

        Task<string> AgregarComentarioInconformidad(ComentariosInconformidadDTO dto);

        Task<string> EditarComentarioInconformidad(ComentariosInconformidadDTO dto, int id);

        Task<string> EliminarComentarioInconformidad(int id);


    }
}
