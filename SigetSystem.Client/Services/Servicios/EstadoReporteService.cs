using SigetSystem.Client.Services.Interfaces;
using SigetSystem.Shared.DTOs.Padres;
using SigetSystem.Shared.MPPs;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace SigetSystem.Client.Services.Servicios
{
    public class EstadoReporteService : IEstadoReporteService
    {
        private readonly HttpClient _http;

        public EstadoReporteService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<EstadoReporteDTO>> MostrarReporte()
        {
            var resultado = await _http.GetFromJsonAsync<APIResponse<List<EstadoReporteDTO>>>("api/EstadoReporte/Consulta");

            if (resultado!.EsExitoso == true)
            {
                List<EstadoReporteDTO> lista = resultado.Resultado;

                return lista;
            }
            else
            {
                throw new Exception(resultado.MensajeError);
            }
        }
    }
}
