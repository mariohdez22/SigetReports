using SigetSystem.Server.Models.Entidades.Hijas;
using SigetSystem.Shared.MPPs;

namespace SigetSystem.Server.Repositorio.MetodoAplicado.Interfaces.Hijas
{
    public interface IMetodoComentarioSiget
    {
        Task<(List<ComentarioSiget>, int totalRegistros)> ConsultaComentario(ParametrosPaginacion pp);

        Task<ComentarioSiget> BuscarComentario(int ID);

        Task<ComentarioSiget> CrearComentario(ComentarioSiget entidad);

        Task<ComentarioSiget> EditarComentario(ComentarioSiget entidad);

        Task BorrarComentario(ComentarioSiget entidad);
    }
}
