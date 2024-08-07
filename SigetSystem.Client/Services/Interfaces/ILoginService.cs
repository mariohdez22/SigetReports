using SigetSystem.Shared.DTOs.Independientes;

namespace SigetSystem.Client.Services.Interfaces
{
    public interface ILoginService
    {
        Task<string> LogeoPersonal(LoginDTO loginDTO);

        Task Logout();

        Task<string> GetToken();
    }
}
