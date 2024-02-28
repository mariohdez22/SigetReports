using SigetSystem.Shared.DTOs.Padres;

namespace SigetSystem.Client.Services.Interfaces
{
    public interface IMunicipioInstalacionService
    {
        Task<List<MunicipioInstalacionDTO>> MostrarMunicipio();
    }
}
