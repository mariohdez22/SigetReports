using SigetSystem.Server.Models.Entidades.Padres;
using SigetSystem.Shared.MPPs;

namespace SigetSystem.Server.Repositorio.MetodoAplicado.Interfaces.Padres
{
    public interface IMetodoComentariosInconformidad
    {
        Task<(List<ComentariosInconformidad>, int totalRegistro)> ConsultaComentariosInconformidad(ParametrosPaginacion pp);

        Task<ComentariosInconformidad> BuscarComentariosInconformidad(int id);

        Task<ComentariosInconformidad> CrearComentariosInconformidad(ComentariosInconformidad comentario);

        Task<ComentariosInconformidad> EditarComentariosInconformidad(ComentariosInconformidad comentario);

        Task BorrarComentariosInconformidad(ComentariosInconformidad comentario);
    }
}
