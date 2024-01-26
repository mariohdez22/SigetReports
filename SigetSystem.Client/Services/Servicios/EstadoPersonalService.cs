using SigetSystem.Client.Services.Interfaces;
using SigetSystem.Shared.DTOs.Padres;
using SigetSystem.Shared.MPPs;
using System.Net.Http;
using System.Net.Http.Json;

namespace SigetSystem.Client.Services.Servicios
{
    public class EstadoPersonalService : IEstadoPersonalService
    {
        private readonly HttpClient _httpClient;

        public EstadoPersonalService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<EstadoPersonalDTO>> MostrarEstadoPersonal()
        {
            var resultado = await _httpClient.GetFromJsonAsync<APIResponse<List<EstadoPersonalDTO>>>("api/EstadoPersonal/Consulta");

            if (resultado!.EsExitoso == true)
            {
                List<EstadoPersonalDTO> lista = resultado.Resultado;
                return lista;
            }
            else
            {
                throw new Exception(resultado.MensajeError);
            }
        }
    }
}
