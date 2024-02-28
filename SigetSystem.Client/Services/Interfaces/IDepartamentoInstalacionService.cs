using SigetSystem.Shared.DTOs.Padres;

namespace SigetSystem.Client.Services.Interfaces
{
    public interface IDepartamentoInstalacionService
    {
        Task<List<DepartamentoInstalacionDTO>> MostrarDepartamentos();
    }
}
