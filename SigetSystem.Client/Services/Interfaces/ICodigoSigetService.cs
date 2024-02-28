using SigetSystem.Shared.DTOs.Padres;

namespace SigetSystem.Client.Services.Interfaces
{
    public interface ICodigoSigetService
    {
        Task<List<CodigoSigetDTO>> MostrarCodigoSiget();
    }
}
