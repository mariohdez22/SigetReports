using SigetSystem.Shared.DTOs.Padres;

namespace SigetSystem.Client.Services.Interfaces
{
    public interface ITipoConformidadService
    {
        Task<List<TipoConformidadDTO>> MostrarTipoConformidad();
    }
}
