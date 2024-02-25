using SigetSystem.Shared.DTOs.Padres;

namespace SigetSystem.Client.Services.Interfaces
{
    public interface ICodigoConformidadService
    {
        Task<List<CodigoConformidadDTO>> MostrarCodigoConformidad();
    }
}
