using SigetSystem.Server.Models.Entidades.Hijas;
using SigetSystem.Shared.MPPs;

namespace SigetSystem.Server.Repositorio.MetodoAplicado.Interfaces.Hijas
{
    public interface IMetodoOrganismo
    {
        Task<(List<Organismo>, int totalRegistro)> ConsultaOrganismo(ParametrosPaginacion pp);

        Task<Organismo> Buscar(int id);

        Task<Organismo> CrearOrganismo(Organismo org);

        Task<Organismo> EditarOrganismo(Organismo org);

        Task BorrarOrganismo(Organismo org);

    }
}
