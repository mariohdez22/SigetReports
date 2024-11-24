using SigetSystem.Client.Services.Interfaces;
using SigetSystem.Shared.DTOs.Padres;
using SigetSystem.Shared.MPPs;
using System.Net.Http.Json;

namespace SigetSystem.Client.Services.Servicios
{
    public class RangoPersonalService : IRangoPersonalService
    {
        private readonly HttpClient _httpClient;

        public RangoPersonalService(IHttpClientFactory httpFactory)
        {
            _httpClient = httpFactory.CreateClient("ApiSiget");
        }

        public async Task<List<RangoPersonalDTO>> MostrarRangoPersonal()
        {
            var resultado = await _httpClient.GetFromJsonAsync<APIResponse<List<RangoPersonalDTO>>>("api/RangoPersonal/Consulta");

            if (resultado!.EsExitoso == true)
            {
                List<RangoPersonalDTO> lista = resultado.Resultado;
                return lista;  
            }
            else
            {
                throw new Exception(resultado.MensajeError);
            }
        }
    }
}
