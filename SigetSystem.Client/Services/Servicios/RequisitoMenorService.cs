using SigetSystem.Client.Services.Interfaces;
using SigetSystem.Shared.DTOs.Hijas;
using SigetSystem.Shared.MPPs;
using System.Net.Http.Json;
using System.Net;

namespace SigetSystem.Client.Services.Servicios
{
    public class RequisitoMenorService : IRequisitoMenorService
    {
        private readonly HttpClient _http;

        public RequisitoMenorService(IHttpClientFactory httpFactory)
        {
            _http = httpFactory.CreateClient("ApiSiget");
        }

        public async Task<APIResponse<List<RequisitoMenorDTO>>> MostrarRequisitoMenor(ParametrosPaginacion pp)
        {
            string url = $"api/RequisitosMenores/Consulta?NumeroPagina={pp.NumeroPagina}&TamañoPagina={pp.TamañoPagina}&Orden={pp.Orden}&ID1={pp.ID1}&ID2={pp.ID2}";

            if (!string.IsNullOrEmpty(pp.Buscar))
            {
                url += $"&Buscar={Uri.EscapeDataString(pp.Buscar)}";
            }

            var resultado = await _http.GetFromJsonAsync<APIResponse<List<RequisitoMenorDTO>>>(url);

            if (resultado!.EsExitoso == true)
            {
                return resultado;
            }
            else
            {
                throw new Exception(resultado.MensajeError);
            }
        }

        public async Task<List<RequisitoMenorDTO>> MostrarRequisitoMenor()
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

            string url = $"api/RequisitosMenores/Consulta?NumeroPagina={pp.NumeroPagina}&TamañoPagina={pp.TamañoPagina}&Orden={pp.Orden}&ID1={pp.ID1}&ID2={pp.ID2}";

            if (!string.IsNullOrEmpty(pp.Buscar))
            {
                url += $"&Buscar={Uri.EscapeDataString(pp.Buscar)}";
            }

            var resultado = await _http.GetFromJsonAsync<APIResponse<List<RequisitoMenorDTO>>>(url);

            if (resultado!.EsExitoso == true)
            {
                return resultado.Resultado;
            }
            else
            {
                throw new Exception(resultado.MensajeError);
            }
        }

        public async Task<RequisitoMenorDTO> BuscarRequisitoMenor(int id)
        {
            var resultado = await _http.GetFromJsonAsync<APIResponse<RequisitoMenorDTO>>($"api/RequisitosMaenores/Obtener/{id}");

            if (resultado!.EsExitoso == true)
            {
                RequisitoMenorDTO articulo = resultado.Resultado;

                return articulo;
            }
            else
            {
                throw new Exception(resultado.MensajeError);
            }
        }

        public async Task<string> CrearRequisitoMenor(RequisitoMenorDTO dto)
        {
            var resultado = await _http.PostAsJsonAsync("api/RequisitosMenores/Agregar", dto);
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

        public async Task<string> EditarRequisito(RequisitoMenorDTO dto, int id)
        {
            var resultado = await _http.PutAsJsonAsync($"api/RequisitosMenores/Editar{id}", dto);
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

        public async Task<string> EliminarRequisito(int id)
        {
            var resultado = await _http.DeleteAsync($"api/RequisitosMenores/Eliminar/{id}");
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
