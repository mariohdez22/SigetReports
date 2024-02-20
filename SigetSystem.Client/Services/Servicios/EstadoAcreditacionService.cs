using System.Net.Http.Json;
using SigetSystem.Client.Services.Interfaces;
using SigetSystem.Shared.DTOs.Padres;
using SigetSystem.Shared.MPPs;

namespace SigetSystem.Client.Services.Servicios
{
    public class EstadoAcreditacionService : IEstadoAcreditacionService
    {
        private readonly HttpClient _http;

        public EstadoAcreditacionService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<EstadoAcreditacionDTO>> MostrarEstadoAcreditacion()
        {
            var resultado =
                await _http.GetFromJsonAsync<APIResponse<List<EstadoAcreditacionDTO>>>(
                    "api/EstadoAcreditacion/Consulta");

            if (resultado!.EsExitoso == true)
            {
                List<EstadoAcreditacionDTO> lista = resultado.Resultado;

                return lista;
            }
            else
            {
                throw new Exception(resultado.MensajeError);
            }
        }
    }

}
