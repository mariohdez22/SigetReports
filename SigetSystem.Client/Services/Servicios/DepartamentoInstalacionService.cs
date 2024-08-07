using SigetSystem.Client.Services.Interfaces;
using SigetSystem.Shared.DTOs.Padres;
using SigetSystem.Shared.MPPs;
using System.Net.Http.Json;

namespace SigetSystem.Client.Services.Servicios
{
    public class DepartamentoInstalacionService : IDepartamentoInstalacionService
    {
        private readonly HttpClient _http;

        public DepartamentoInstalacionService(IHttpClientFactory httpFactory)
        {
            _http = httpFactory.CreateClient("ApiSiget");
        }

        public async Task<List<DepartamentoInstalacionDTO>> MostrarDepartamentos()
        {
            var resultado = await _http.GetFromJsonAsync<APIResponse<List<DepartamentoInstalacionDTO>>>("api/DepartamentoInstalacion/Consulta");

            if (resultado!.EsExitoso == true)
            {
                List<DepartamentoInstalacionDTO> lista = resultado.Resultado;

                return lista;
            }
            else
            {
                throw new Exception(resultado.MensajeError);
            }
        }
    }
}
