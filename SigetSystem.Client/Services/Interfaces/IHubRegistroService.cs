namespace SigetSystem.Client.Services.Interfaces
{
    public interface IHubRegistroService
    {
        event Func<string, Task> OnRegisterReceived;

        Task ConnectAsync();

        Task DisconnectAsync();
    }
}
