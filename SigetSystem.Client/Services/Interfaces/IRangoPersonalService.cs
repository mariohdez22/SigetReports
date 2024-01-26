using SigetSystem.Shared.DTOs.Padres;

namespace SigetSystem.Client.Services.Interfaces
{
    public interface IRangoPersonalService
    {
        Task<List<RangoPersonalDTO>> MostrarRangoPersonal();
    }
}
