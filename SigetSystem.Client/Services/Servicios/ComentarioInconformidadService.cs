using SigetSystem.Client.Services.Interfaces;
using SigetSystem.Shared.DTOs.Hijas;
using SigetSystem.Shared.DTOs.Padres;
using SigetSystem.Shared.MPPs;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace SigetSystem.Client.Services.Servicios
{
    public class ComentarioInconformidadService : IComentarioInconformidadService
    {
        private readonly HttpClient _http;

        public ComentarioInconformidadService(IHttpClientFactory httpFactory)
        {
            _http = httpFactory.CreateClient("ApiSiget");
        }

        public async Task<APIResponse<List<ComentariosInconformidadDTO>>> MostrarComentarioInconformidad(ParametrosPaginacion pp)
        {
            string url = $"api/ComentariosInconformidad/Consulta?NumeroPagina={pp.NumeroPagina}&TamañoPagina={pp.TamañoPagina}&Orden={pp.Orden}&ID1={pp.ID1}&ID2={pp.ID2}";

            if (!string.IsNullOrEmpty(pp.Buscar))
            {
                url += $"&Buscar={Uri.EscapeDataString(pp.Buscar)}";
            }

            var resultado = await _http.GetFromJsonAsync<APIResponse<List<ComentariosInconformidadDTO>>>(url);

            if (resultado!.EsExitoso == true)
            {
                return resultado;
            }
            else
            {
                throw new Exception(resultado.MensajeError);
            }
        }

        public async Task<List<ComentariosInconformidadDTO>> MostrarComentarioInconformidad()
        {
            ParametrosPaginacion pp = new ParametrosPaginacion()
            {
                NumeroPagina = 1,
                TamañoPagina = sizeof(int),
                Orden = "Descendente",
                Buscar = "",
                ID1 = 0,
                ID2 = 0,
            };

            string url = $"api/ComentariosInconformidad/Consulta?NumeroPagina={pp.NumeroPagina}&TamañoPagina={pp.TamañoPagina}&Orden={pp.Orden}&ID1={pp.ID1}&ID2={pp.ID2}";

            if (!string.IsNullOrEmpty(pp.Buscar))
            {
                url += $"&Buscar={Uri.EscapeDataString(pp.Buscar)}";
            }

            var resultado = await _http.GetFromJsonAsync<APIResponse<List<ComentariosInconformidadDTO>>>(url);

            if (resultado!.EsExitoso == true)
            {
                return resultado.Resultado;
            }
            else
            {
                throw new Exception(resultado.MensajeError);
            }
        }

        public async Task<string> AgregarComentarioInconformidad(ComentariosInconformidadDTO dto)
        {
            var resultado = await _http.PostAsJsonAsync("api/ComentariosInconformidad/Agregar", dto);
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

        public async Task<ComentariosInconformidadDTO> BuscarComentarioInconformidad(int id)
        {
            var resultado = await _http.GetFromJsonAsync<APIResponse<ComentariosInconformidadDTO>>($"api/ComentariosInconformidad/Obtener/{id}");

            if (resultado!.EsExitoso == true)
            {
                ComentariosInconformidadDTO articulo = resultado.Resultado;

                return articulo;
            }
            else
            {
                throw new Exception(resultado.MensajeError);
            }
        }

        public async Task<string> EditarComentarioInconformidad(ComentariosInconformidadDTO dto, int id)
        {
            var resultado = await _http.PutAsJsonAsync($"api/ComentariosInconformidad/Editar/{id}", dto);
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

        public async Task<string> EliminarComentarioInconformidad(int id)
        {
            var resultado = await _http.DeleteAsync($"api/ComentariosInconformidad/Eliminar/{id}");
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
