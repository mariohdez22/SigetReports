using SigetSystem.Client.Services.Interfaces;
using SigetSystem.Shared.DTOs.Padres;
using SigetSystem.Shared.MPPs;
using System.Net.Http.Json;

namespace SigetSystem.Client.Services.Servicios
{
    public class TipoConformidadService : ITipoConformidadService
    {
        private readonly HttpClient _httpClient;

        public TipoConformidadService(IHttpClientFactory httpFactory)
        {
            _httpClient = httpFactory.CreateClient("ApiSiget");
        }

        public async Task<List<TipoConformidadDTO>> MostrarTipoConformidad()
        {
            var resultado = await _httpClient.GetFromJsonAsync<APIResponse<List<TipoConformidadDTO>>>("api/TipoConformidad/Consulta");

            if (resultado!.EsExitoso == true)
            {
                List<TipoConformidadDTO> lista = resultado.Resultado;
                return lista;
            }
            else
            {
                throw new Exception(resultado.MensajeError);
            }
        }
    }
}
