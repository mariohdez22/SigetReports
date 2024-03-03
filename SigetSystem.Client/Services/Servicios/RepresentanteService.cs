using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using SigetSystem.Client.Services.Interfaces;
using SigetSystem.Shared.DTOs.Hijas;
using SigetSystem.Shared.DTOs.Padres;
using SigetSystem.Shared.MPPs;
using static System.Net.WebRequestMethods;


namespace SigetSystem.Client.Services.Servicios
{
    public class RepresentanteService : IRepresentanteService
    {
        private readonly HttpClient _httpClient;

        public RepresentanteService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<APIResponse<List<RepresentanteDTO>>> MostrarRepresentante(ParametrosPaginacion pp)
        {
            string url = $"api/Representante/Consulta?NumeroPagina={pp.NumeroPagina}&TamañoPagina={pp.TamañoPagina}&Orden={pp.Orden}&ID1={pp.ID1}&ID2={pp.ID2}";

            if (!string.IsNullOrEmpty(pp.Buscar))
            {
                url += $"&Buscar={Uri.EscapeDataString(pp.Buscar)}";
            }

            var resultado = await _httpClient.GetFromJsonAsync<APIResponse<List<RepresentanteDTO>>>(url);

            if (resultado!.EsExitoso == true)
            {
                return resultado;
            }
            else
            {
                throw new Exception(resultado.MensajeError);
            }
        }

        public async Task<List<RepresentanteDTO>> MostrarRepresentante()
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

            string url = $"api/Representante/Consulta?NumeroPagina={pp.NumeroPagina}&TamañoPagina={pp.TamañoPagina}&Orden={pp.Orden}&ID1={pp.ID1}&ID2={pp.ID2}";

            if (!string.IsNullOrEmpty(pp.Buscar))
            {
                url += $"&Buscar={Uri.EscapeDataString(pp.Buscar)}";
            }

            var resultado = await _httpClient.GetFromJsonAsync<APIResponse<List<RepresentanteDTO>>>(url);

            if (resultado!.EsExitoso == true)
            {
                return resultado.Resultado;
            }
            else
            {
                throw new Exception(resultado.MensajeError);
            }
        }

        public async Task<RepresentanteDTO> BuscarRepresentante(int id)
        {
            var resultado = await _httpClient.GetFromJsonAsync<APIResponse<RepresentanteDTO>>($"api/Representante/Obtener/{id}");

            if (resultado!.EsExitoso == true)
            {
                RepresentanteDTO articulo = resultado.Resultado;

                return articulo;
            }
            else
            {
                throw new Exception(resultado.MensajeError);
            }
        }

        public async Task<string> CrearRepresentante(RepresentanteDTO representante)
        {
            var resultado = await _httpClient.PostAsJsonAsync("api/Representante/Agregar", representante);
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

        public async Task<string> EditarRepresentante(RepresentanteDTO representante, int id)
        {
            var resultado = await _httpClient.PutAsJsonAsync($"api/Representante/Editar/{id}", representante);
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

        public async Task<string> EliminarRepresentante(int id)
        {
            var resultado = await _httpClient.DeleteAsync($"api/Representante/Eliminar/{id}");
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

        public async Task<List<RepresentanteDTO>> MostrarRepresentanteSimple()
        {
            var resultado = await _httpClient.GetFromJsonAsync<APIResponse<List<RepresentanteDTO>>>("api/Representante/ConsultaSimple");

            if (resultado!.EsExitoso == true)
            {
                List<RepresentanteDTO> lista = resultado.Resultado;
                return lista;
            }
            else
            {
                throw new Exception(resultado.MensajeError);
            }
        }
    }
}

