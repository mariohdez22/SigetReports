namespace SigetSystem.Server.Repositorio.MetodoAplicado.Interfaces.Padres
{
    public interface IMetodoEstadoReporte
    {
        Task<List<EstadoReporte>> ConsultaEstadoReporte();
    }
}
