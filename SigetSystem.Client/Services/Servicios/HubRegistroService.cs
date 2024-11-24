using Microsoft.AspNetCore.SignalR.Client;
using SigetSystem.Client.Services.Interfaces;

namespace SigetSystem.Client.Services.Servicios
{
    public class HubRegistroService : IHubRegistroService
    {
        public HubConnection _hubConnection { get; set; }

        public event Func<string, Task> OnRegisterReceived;

        public HubRegistroService()
        {
            _hubConnection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7284/hubRegistro")  
                .Build();

            _hubConnection.On<string>("ObtencionMensaje", async (registro) =>
            {
                if (OnRegisterReceived != null)

                    await OnRegisterReceived(registro);
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
































//public async Task SendNotificationAsync(string message)
//{
//    await _hubConnection.SendAsync("SendNotification", message);
//}

//public async ValueTask DisposeAsync()
//{
//    if (_hubConnection != null)
//    {
//        await _hubConnection.DisposeAsync();
//    }
//}