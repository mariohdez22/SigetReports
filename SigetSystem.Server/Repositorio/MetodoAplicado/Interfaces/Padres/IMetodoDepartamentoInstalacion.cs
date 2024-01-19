namespace SigetSystem.Server.Repositorio.MetodoAplicado.Interfaces.Padres
{
    public interface IMetodoDepartamentoInstalacion
    {
        Task<List<DepartamentoInstalacion>> ConsultaDepartamentoInstalacion();
    }
}
