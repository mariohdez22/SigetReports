using SigetSystem.Client.Services.Interfaces;
using SigetSystem.Shared.DTOs.Hijas;
using SigetSystem.Shared.MPPs;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;

namespace SigetSystem.Client.Services.Servicios
{
    public class RequisitoMayorService : IRequisitoMayorService
    {
        private readonly HttpClient _http;

        public RequisitoMayorService(HttpClient http)
        {
            _http = http;
        }

        public async Task<APIResponse<List<RequisitoMayorDTO>>> MostrarRequisitoMayor(ParametrosPaginacion pp)
        {
            string url = $"api/RequisitosMayores/Consulta?NumeroPagina={pp.NumeroPagina}&TamañoPagina={pp.TamañoPagina}&Orden={pp.Orden}&ID1={pp.ID1}&ID2={pp.ID2}";

            if (!string.IsNullOrEmpty(pp.Buscar))
            {
                url += $"&Buscar={Uri.EscapeDataString(pp.Buscar)}";
            }

            var resultado = await _http.GetFromJsonAsync<APIResponse<List<RequisitoMayorDTO>>>(url);

            if (resultado!.EsExitoso == true)
            {
                return resultado;
            }
            else
            {
                throw new Exception(resultado.MensajeError);
            }
        }

        public async Task<RequisitoMayorDTO> BuscarRequisitoMayor(int id)
        {
            var resultado = await _http.GetFromJsonAsync<APIResponse<RequisitoMayorDTO>>($"api/RequisitosMayores/Obtener/{id}");

            if (resultado!.EsExitoso == true)
            {
                RequisitoMayorDTO articulo = resultado.Resultado;

                return articulo;
            }
            else
            {
                throw new Exception(resultado.MensajeError);
            }
        }

        public async Task<string> CrearRequisitoMAyor(RequisitoMayorDTO dto)
        {
            var resultado = await _http.PostAsJsonAsync("api/RequisitosMayores/Agregar", dto);
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

        public async Task<string> EditarRequisito(RequisitoMayorDTO dto, int id)
        {
            var resultado = await _http.PutAsJsonAsync($"api/RequisitosMayores/Editar{id}", dto);
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
            var resultado = await _http.DeleteAsync($"api/RequisitosMayores/Eliminar/{id}");
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
