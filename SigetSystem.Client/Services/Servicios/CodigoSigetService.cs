using SigetSystem.Client.Services.Interfaces;
using SigetSystem.Shared.DTOs.Padres;
using SigetSystem.Shared.MPPs;
using System.Net.Http.Json;

namespace SigetSystem.Client.Services.Servicios
{
    public class CodigoSigetService : ICodigoSigetService
    {
        private readonly HttpClient _http;

        public CodigoSigetService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<CodigoSigetDTO>> MostrarCodigoSiget()
        {
            var resultado = await _http.GetFromJsonAsync<APIResponse<List<CodigoSigetDTO>>>("api/CodigoSiget/Consulta");

            if (resultado!.EsExitoso == true)
            {
                List<CodigoSigetDTO> lista = resultado.Resultado;

                return lista;
            }
            else
            {
                throw new Exception(resultado.MensajeError);
            }
        }
    }

}
