using SigetSystem.Client.Services.Interfaces;
using SigetSystem.Shared.DTOs.Hijas;
using SigetSystem.Shared.MPPs;
using System.Net;
using System.Net.Http.Json;

namespace SigetSystem.Client.Services.Servicios
{
    public class ComentarioSigetService : IComentarioSigetService
    {
        private readonly HttpClient _httpClient;

        public ComentarioSigetService(IHttpClientFactory httpFactory)
        {
            _httpClient = httpFactory.CreateClient("ApiSiget");
        }

        public async Task<APIResponse<List<ComentarioSigetDTO>>> MostrarComentarios(ParametrosPaginacion pp)
        {
            string url = $"api/ComentarioSiget/Consulta?NumeroPagina={pp.NumeroPagina}&TamañoPagina={pp.TamañoPagina}&Orden={pp.Orden}&ID1={pp.ID1}&ID2={pp.ID2}";

            if (!string.IsNullOrEmpty(pp.Buscar))
            {
                url += $"&Buscar={Uri.EscapeDataString(pp.Buscar)}";
            }

            var resultado = await _httpClient.GetFromJsonAsync<APIResponse<List<ComentarioSigetDTO>>>(url);

            if (resultado!.EsExitoso == true)
            {
                return resultado;
            }
            else
            {
                throw new Exception(resultado.MensajeError);
            }
        }

        public async Task<ComentarioSigetDTO> BuscarComentario(int id)
        {
            var resultado = await _httpClient.GetFromJsonAsync<APIResponse<ComentarioSigetDTO>>($"api/ComentarioSiget/Obtener/{id}");

            if (resultado!.EsExitoso == true)
            {
                ComentarioSigetDTO articulo = resultado.Resultado;

                return articulo;
            }
            else
            {
                throw new Exception(resultado.MensajeError);
            }
        }

        public async Task<string> CrearComentario(ComentarioSigetDTO comentario)
        {
            var resultado = await _httpClient.PostAsJsonAsync("api/ComentarioSiget/Agregar", comentario);
            var respuesta = await resultado.Content.ReadFromJsonAsync<APIResponse<string>>();

            if (respuesta!.CodigoEstado == HttpStatusCode.Created && respuesta!.EsExitoso == true)
            {
                return respuesta.Resultado;
            }
            else
            {
                throw new Exception(respuesta.MensajeError);
            }
        }

        public async Task<string> EditarComentario(ComentarioSigetDTO comentario, int id)
        {
            var resultado = await _httpClient.PutAsJsonAsync($"api/ComentarioSiget/Editar/{id}", comentario);
            var respuesta = await resultado.Content.ReadFromJsonAsync<APIResponse<string>>();

            if (respuesta!.CodigoEstado == HttpStatusCode.NoContent && respuesta!.EsExitoso == true)
            {
                return respuesta.Resultado;
            }
            else
            {
                throw new Exception(respuesta.MensajeError);
            }
        }

        public async Task<string> EliminarComentario(int id)
        {
            var resultado = await _httpClient.DeleteAsync($"api/ComentarioSiget/Eliminar/{id}");
            var respuesta = await resultado.Content.ReadFromJsonAsync<APIResponse<string>>();

            if (respuesta!.CodigoEstado == HttpStatusCode.NoContent && respuesta!.EsExitoso == true)
            {
                return respuesta.Resultado;
            }
            else
            {
                throw new Exception(respuesta.MensajeError);
            }
        }

    }
}
