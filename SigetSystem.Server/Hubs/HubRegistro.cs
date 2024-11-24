using Microsoft.AspNetCore.SignalR;

namespace SigetSystem.Server.Hubs
{
    public class HubRegistro : Hub
    {
        public async Task NuevoRegistro(string mensaje)
        {
            await Clients.All.SendAsync("ObtencionMensaje", mensaje);
        }

        //public async Task RegistroEditado(string mensaje)
        //{
        //    await Clients.All.SendAsync("RegistroEditado", mensaje);
        //}
    }
}
