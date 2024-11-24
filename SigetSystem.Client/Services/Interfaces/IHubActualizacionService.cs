namespace SigetSystem.Client.Services.Interfaces
{
    public interface IHubActualizacionService
    {
        event Func<string, Task> OnRegisterEdited;

        Task ConnectAsync();

        Task DisconnectAsync();
    }
}
