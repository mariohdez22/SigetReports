using SigetSystem.Client.Services.Interfaces;
using SigetSystem.Shared.DTOs.Hijas;
using SigetSystem.Shared.MPPs;
using System.Net;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace SigetSystem.Client.Services.Servicios
{
    public class PersonalService : IPersonalService
    {
        private readonly HttpClient _httpClient;

        public PersonalService(IHttpClientFactory httpFactory)
        {
            _httpClient = httpFactory.CreateClient("ApiSiget");
        }

        public async Task<APIResponse<List<PersonalDTO>>> MostrarPersonal(ParametrosPaginacion pp)
        {
            string url = $"api/Personal/Consulta?NumeroPagina={pp.NumeroPagina}&TamañoPagina={pp.TamañoPagina}&Orden={pp.Orden}&ID1={pp.ID1}&ID2={pp.ID2}";

            if (!string.IsNullOrEmpty(pp.Buscar))
            {
                url += $"&Buscar={Uri.EscapeDataString(pp.Buscar)}";
            }

            var resultado = await _httpClient.GetFromJsonAsync<APIResponse<List<PersonalDTO>>>(url);

            if (resultado!.EsExitoso == true)
            {
                return resultado;
            }
            else
            {
                throw new Exception(resultado.MensajeError);
            }
        }

        public async Task<PersonalDTO> BuscarPersonal(int id)
        {
            var resultado = await _httpClient.GetFromJsonAsync<APIResponse<PersonalDTO>>($"api/Personal/Obtener/{id}");

            if (resultado!.EsExitoso == true)
            {
                PersonalDTO articulo = resultado.Resultado;

                return articulo;
            }
            else
            {
                throw new Exception(resultado.MensajeError);
            }
        }

        public async Task<string> CrearPersonal(PersonalDTO personal)
        {
            try
            {
                var resultado = await _httpClient.PostAsJsonAsync("api/Personal/Agregar", personal);
                var respuesta = await resultado.Content.ReadFromJsonAsync<APIResponse<string>>();

                if (respuesta!.CodigoEstado == HttpStatusCode.Created && respuesta!.EsExitoso == true)
                {
                    return respuesta.Resultado;
                }
                else
                {
                    Console.WriteLine(respuesta.MensajeError);
                    throw new Exception(respuesta.MensajeError);
                }
            }
            catch (Exception ex)
            {
                // Log de la excepción interna
                await Console.Out.WriteLineAsync("--------------------------------------------------------");
                Console.WriteLine(ex.InnerException?.Message ?? ex.Message);
                throw new Exception("An error occurred while saving the entity changes. See the inner exception for details.", ex);
            }           
        }

        public async Task<string> EditarPersonal(PersonalDTO personal, int id)
        {
            var resultado = await _httpClient.PutAsJsonAsync($"api/Personal/Editar/{id}", personal);
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

        public async Task<string> EliminarPersonal(int id)
        {
            var resultado = await _httpClient.DeleteAsync($"api/Personal/Eliminar/{id}");
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

        //----------------------------------------------------------------------------------------

        public async Task<List<PersonalDTO>> MostrarPersonalSimple()
        {
            var resultado = await _httpClient.GetFromJsonAsync<APIResponse<List<PersonalDTO>>>("api/Personal/ConsultaSimple");

            if (resultado!.EsExitoso == true)
            {
                List<PersonalDTO> lista = resultado.Resultado;
                return lista;
            }
            else
            {
                throw new Exception(resultado.MensajeError);
            }
        }
    }
}
