namespace SigetSystem.Server.Repositorio.MetodoAplicado.Interfaces.Hijas
{
    public interface IMetodoReporteInspeccion
    {
        Task<(List<ReporteInspeccion>, int totalRegistros)> ConsultaReporteInspeccion(ParametrosPaginacion pp);

        Task<ReporteInspeccion> BuscarReporte(int id);

        Task<ReporteInspeccion> CrearReporte(ReporteInspeccion reporte);

        Task<ReporteInspeccion> EditarReporte(ReporteInspeccion reporte);

        Task BorrarReporte(ReporteInspeccion);

        Task<(int id, string tokenJob)> GenerarEdicionPrograma(int idReporte);
    }
}
