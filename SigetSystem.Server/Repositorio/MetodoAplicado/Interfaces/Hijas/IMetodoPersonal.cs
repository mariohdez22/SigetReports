using SigetSystem.Server.Models.Entidades.Hijas;
using SigetSystem.Shared.MPPs;

namespace SigetSystem.Server.Repositorio.MetodoAplicado.Interfaces.Hijas
{
    public interface IMetodoPersonal
    {
        Task<(List<Personal>, int totalRegistros)> ConsultaPersonal(ParametrosPaginacion pp);

        Task<Personal> BuscarPersonal (int ID);

        Task<Personal> CrearPersonal (Personal entidad);

        Task<Personal> EditarPersonal (Personal entidad);

        Task BorrarPersonal (Personal entidad);
    }
}
