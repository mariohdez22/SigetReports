using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using SigetSystem.Client.Services.Interfaces;
using SigetSystem.Shared.DTOs.Hijas;
using SigetSystem.Shared.DTOs.Padres;
using SigetSystem.Shared.MPPs;

namespace SigetSystem.Client.Services.Servicios
{
    public class OrganismoService : IOrganismoService
    {
        private readonly HttpClient _http;

        public OrganismoService(HttpClient http)
        {
            _http = http;
        }

        public async Task<APIResponse<List<OrganismoDTO>>> MostrarOrganismos(ParametrosPaginacion pp)
        {
            string url = $"api/Organismos/Consulta?NumeroPagina={pp.NumeroPagina}&TamañoPagina={pp.TamañoPagina}&Orden={pp.Orden}&ID1={pp.ID1}&ID2={pp.ID2}";

            if (!string.IsNullOrEmpty(pp.Buscar))
            {
                url += $"&Buscar={Uri.EscapeDataString(pp.Buscar)}";
            }

            var resultado = await _http.GetFromJsonAsync<APIResponse<List<OrganismoDTO>>>(url);

            if (resultado!.EsExitoso == true)
            {
                return resultado;
            }
            else
            {
                throw new Exception(resultado.MensajeError);
            }
        }

        public async Task<OrganismoDTO> BuscarOrganismo(int id)
        {
            var resultado = await _http.GetFromJsonAsync<APIResponse<OrganismoDTO>>($"api/Organismos/Buscar/{id}");

            if (resultado!.EsExitoso == true)
            {
                OrganismoDTO articulo = resultado.Resultado;

                return articulo;
            }
            else
            {
                throw new Exception(resultado.MensajeError);
            }
        }

        public async Task<string> AgregarOrganismo(OrganismoDTO dto)
        {
            var resultado = await _http.PostAsJsonAsync("api/Organismos/Agregar", dto);
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

        public async Task<string> EditarOrganismo(OrganismoDTO dto, int id)
        {
            var resultado = await _http.PutAsJsonAsync($"api/Organismos/Editar/{id}", dto);
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

        public async Task<string> EliminarOrganismo(int id)
        {
            var resultado = await _http.DeleteAsync($"api/Organismos/Eliminar/{id}");
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
