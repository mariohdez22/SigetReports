using SigetSystem.Shared.DTOs.Padres;

namespace SigetSystem.Client.Services.Interfaces
{
    public interface IEstadoPersonalService
    {
        Task<List<EstadoPersonalDTO>> MostrarEstadoPersonal();
    }
}
