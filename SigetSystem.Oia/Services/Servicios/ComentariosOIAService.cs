using SigetSystem.Oia.Services.Interfaces;
using SigetSystem.Shared.DTOs.Hijas;
using SigetSystem.Shared.DTOs.Padres;
using SigetSystem.Shared.MPPs;
using System.Net.Http;
using System.Net.Http.Json;

namespace SigetSystem.Oia.Services.Servicios
{
    public class ComentariosOIAService : IComentariosOIAService
    {
        private readonly HttpClient _httpClient;

        public ComentariosOIAService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ComentariosInconformidadDTO> obtenerComentario(int id)
        {
            var resultado = await _httpClient.GetFromJsonAsync<APIResponse<ComentariosInconformidadDTO>>($"api/ComentariosInconformidad/Buscar/{id}");

            if (resultado!.EsExitoso == true)
            {
                ComentariosInconformidadDTO c = resultado.Resultado;

                return c;
            }
            else
            {
                throw new Exception(resultado.MensajeError);
            }
        }

    }
}
