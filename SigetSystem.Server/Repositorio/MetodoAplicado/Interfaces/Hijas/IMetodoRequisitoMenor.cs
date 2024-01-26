using SigetSystem.Server.Models.Entidades.Hijas;
using SigetSystem.Shared.MPPs;

namespace SigetSystem.Server.Repositorio.MetodoAplicado.Interfaces.Hijas
{
    public interface IMetodoRequisitoMenor
    {
        Task<(List<RequisitoMenor>, int totalRegistros)> ConsultarRequisitoMenor(ParametrosPaginacion pp);

        Task<RequisitoMenor> BuscarRequisitoMenor(int ID);

        Task<RequisitoMenor> CrearRequisitoMenor(RequisitoMenor requisitoMenor);

        Task<RequisitoMenor> EditarRequisitoMenor(RequisitoMenor requisitoMenor);

        Task BorrarRequisitoMenor(RequisitoMenor requisitoMenor);
    }
}
