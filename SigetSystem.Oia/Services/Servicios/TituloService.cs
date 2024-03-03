namespace SigetSystem.Oia.Services.Servicios
{
    public class TituloService
    {
        public string Titulo { get; private set; } = "Inicio Siget";
        public event Action OnTitleChanged;

        public void AgregarTitulo(string titulo)
        {
            Titulo = titulo;
            OnTitleChanged?.Invoke();
        }
    }
}
