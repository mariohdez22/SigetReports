using SigetSystem.Shared.DTOs.Padres;

namespace SigetSystem.Client.Services.Interfaces
{
    public interface IEstadoAcreditacionService
    {
        Task<List<EstadoAcreditacionDTO>> MostrarEstadoAcreditacion();
    }
}
