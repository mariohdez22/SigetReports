using Microsoft.AspNetCore.SignalR.Client;
using SigetSystem.Client.Services.Interfaces;

namespace SigetSystem.Client.Services.Servicios
{
    public class HubActualizacionService : IHubActualizacionService
    {
        public HubConnection _hubConnection { get; set; }

        public event Func<string, Task> OnRegisterEdited;

        public HubActualizacionService()
        {
            _hubConnection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7284/hubRegistro")
                .Build();

            _hubConnection.On<string>("RegistroEditado", async (registro) =>
            {
                if (OnRegisterEdited != null)

                    await OnRegisterEdited(registro);
            });
        }

        public async Task ConnectAsync()
        {
            if (_hubConnection.State == HubConnectionState.Disconnected)
            {
                await _hubConnection.StartAsync();
            }
        }

        public async Task DisconnectAsync()
        {
            if (_hubConnection.State == HubConnectionState.Connected)
            {
                await _hubConnection.StopAsync();
            }
        }

    }
}
