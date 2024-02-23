using SigetSystem.Shared.DTOs.Padres;

namespace SigetSystem.Client.Services.Interfaces
{
    public interface IEstadoRepresentanteService
    {
        Task<List<EstadoRepresentanteDTO>> MostrarEstadoRepresentante();
    }
}
