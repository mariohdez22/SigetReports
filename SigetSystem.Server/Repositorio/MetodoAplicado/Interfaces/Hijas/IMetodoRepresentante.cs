using SigetSystem.Server.Models.Entidades.Hijas;
using SigetSystem.Shared.MPPs;

namespace SigetSystem.Server.Repositorio.MetodoAplicado.Interfaces.Hijas
{
    public interface IMetodoRepresentante
    {
        Task<(List<Representante>, int totalRegistros)> ConsultaRepresentante(ParametrosPaginacion pp);

        Task<Representante> BuscarRepresentante(int ID);

        Task<Representante> CrearRepresentante(Representante representante);

        Task<Representante> EditarRepresentante(Representante representante);

        Task BorrarRepresentante(Representante representante);

        //--------------------------------------------------------------------------------------------------

        Task<List<Representante>> ConsultaRepresentanteSimple();
    }
}
