using SigetSystem.Client.Services.Interfaces;
using SigetSystem.Shared.DTOs.Padres;
using SigetSystem.Shared.MPPs;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace SigetSystem.Client.Services.Servicios
{
    public class CodigoConformidadService : ICodigoConformidadService
    {
        private readonly HttpClient _http;

        public CodigoConformidadService(IHttpClientFactory httpFactory)
        {
            _http = httpFactory.CreateClient("ApiSiget");
        }

        public async Task<List<CodigoConformidadDTO>> MostrarCodigoConformidad()
        {
            var resultado = await _http.GetFromJsonAsync<APIResponse<List<CodigoConformidadDTO>>>("api/CodigoConformidad/Consulta");

            if (resultado!.EsExitoso == true)
            {
                List<CodigoConformidadDTO> lista = resultado.Resultado;

                return lista;
            }
            else
            {
                throw new Exception(resultado.MensajeError);
            }
        }
    }
}
