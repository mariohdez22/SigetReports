namespace SigetSystem.Server.Repositorio.MetodoAplicado.Interfaces.Padres
{
    public interface IMetodoCodigoSiget
    {
        Task<List<CodigoSiget>> ConsultaCodigoSiget();
    }
}
