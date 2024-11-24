using SigetSystem.Client.Services.Interfaces;
using SigetSystem.Shared.DTOs.Padres;
using SigetSystem.Shared.MPPs;
using System.Net.Http.Json;

namespace SigetSystem.Client.Services.Servicios
{
    public class EstadoRepresentanteService : IEstadoRepresentanteService
    {
        private readonly HttpClient _httpClient;

        public EstadoRepresentanteService(IHttpClientFactory httpFactory)
        {
            _httpClient = httpFactory.CreateClient("ApiSiget");
        }

        public async Task<List<EstadoRepresentanteDTO>> MostrarEstadoRepresentante()
        {
            var resultado = await _httpClient.GetFromJsonAsync<APIResponse<List<EstadoRepresentanteDTO>>>("api/EstadoRepresentante/Consulta");

            if (resultado!.EsExitoso == true)
            {
                List<EstadoRepresentanteDTO> lista = resultado.Resultado;
                return lista;
            }
            else
            {
                throw new Exception(resultado.MensajeError);
            }
        }
    }
}
