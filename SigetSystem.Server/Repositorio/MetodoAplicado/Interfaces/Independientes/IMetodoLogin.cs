using SigetSystem.Server.Models.Entidades.Hijas;
using SigetSystem.Shared.DTOs.Independientes;

namespace SigetSystem.Server.Repositorio.MetodoAplicado.Interfaces.Independientes
{
    public interface IMetodoLogin
    {
        Task<(bool IsSuccess, string Token)> LoginPersonal(LoginDTO loginDto);
    }
}
