using SigetSystem.Shared.DTOs.Padres;

namespace SigetSystem.Oia.Services.Interfaces
{
    public interface IComentariosOIAService
    {
        Task<ComentariosInconformidadDTO> obtenerComentario(int id);
    }
}
