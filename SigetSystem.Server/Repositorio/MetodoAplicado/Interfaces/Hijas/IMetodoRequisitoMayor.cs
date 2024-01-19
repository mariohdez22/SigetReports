namespace SigetSystem.Server.Repositorio.MetodoAplicado.Interfaces.Hijas
{
    public interface IMetodoRequisitoMayor
    {
        Task<(List<RequisitoMayor>, int totalRegistros)> ConsultaRequisitoMayor(ParametrosPaginacion pp);

        Task<RequisitoMayor> CrearRequisitoMayor(RequisitoMayor requisitoMayor)

        Task<RequisitoMayor> BuscarRequisitoMayor(int id);

        Task<RequisitoMayor> CrearRequisitoMayor(RequisitoMayor requisitoMayor);

        Task<RequisitoMayor> EditarRequisitoMayor(RequisitoMayor requisitoMayor);

        Task BorrarRequisitoMayor(RequisitoMayor requisitoMayor);
    }
}
