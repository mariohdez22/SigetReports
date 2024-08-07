using SigetSystem.Client.Services.Interfaces;
using SigetSystem.Shared.DTOs.Hijas;
using SigetSystem.Shared.DTOs.Padres;
using SigetSystem.Shared.MPPs;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;

namespace SigetSystem.Client.Services.Servicios

{
    public class ReporteInspeccionService : IReporteInspeccionService
    {
        private readonly HttpClient _http;

        public ReporteInspeccionService(IHttpClientFactory httpFactory)
        {
            _http = httpFactory.CreateClient("ApiSiget");
        }

        public async Task<APIResponse<List<ReporteInspeccionDTO>>> MostrarReporte(ParametrosPaginacion pp)
        {
            string url = $"api/ReporteInspeccion/Consulta?NumeroPagina={pp.NumeroPagina}&TamañoPagina={pp.TamañoPagina}&Orden={pp.Orden}&ID1={pp.ID1}&ID2={pp.ID2}" +
                $"&ReporteFiltro.IdDepartamentoInstalacion={pp.ReporteFiltro.IdDepartamentoInstalacion}" +
                $"&ReporteFiltro.IdMunicipioInstalacion={pp.ReporteFiltro.IdMunicipioInstalacion}" +
                $"&ReporteFiltro.IdCodigoConformidad={pp.ReporteFiltro.IdCodigoConformidad}" +
                $"&ReporteFiltro.IdCodigoSiget={pp.ReporteFiltro.IdCodigoSiget}" +
                $"&ReporteFiltro.IdEstadoReporte={pp.ReporteFiltro.IdEstadoReporte}";

            if (!string.IsNullOrEmpty(pp.Buscar))
            {
                url += $"&Buscar={Uri.EscapeDataString(pp.Buscar)}";
            }

            var resultado = await _http.GetFromJsonAsync<APIResponse<List<ReporteInspeccionDTO>>>(url);

            if (resultado!.EsExitoso == true)
            {
                return resultado;
            }
            else
            {
                throw new Exception(resultado.MensajeError);
            }
        }

        public async Task<List<ReporteInspeccionDTO>> Reportes()
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

            string url = $"api/ReporteInspeccion/Consulta?NumeroPagina={pp.NumeroPagina}&TamañoPagina={pp.TamañoPagina}&Orden={pp.Orden}&ID1={pp.ID1}&ID2={pp.ID2}";

            if (!string.IsNullOrEmpty(pp.Buscar))
            {
                url += $"&Buscar={Uri.EscapeDataString(pp.Buscar)}";
            }

            var resultado = await _http.GetFromJsonAsync<APIResponse<List<ReporteInspeccionDTO>>>(url);

            if (resultado!.EsExitoso == true)
            {
                return resultado.Resultado;
            }
            else
            {
                throw new Exception(resultado.MensajeError);
            }
        }

        public async Task<string> AgregarReporte(ReporteInspeccionDTO dto)
        {
            var resultado = await _http.PostAsJsonAsync("api/ReporteInspeccion/Agregar", dto);
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

        public async Task<ReporteInspeccionDTO> BuscarReporte(int id)
        {
            var resultado = await _http.GetFromJsonAsync<APIResponse<ReporteInspeccionDTO>>($"api/ReporteInspeccion/Obtener/{id}");

            if (resultado!.EsExitoso == true)
            {
                ReporteInspeccionDTO articulo = resultado.Resultado;

                return articulo;
            }
            else
            {
                throw new Exception(resultado.MensajeError);
            }
        }

        public async Task<string> EditarReporte(ReporteInspeccionDTO dto, int id)
        {
            var resultado = await _http.PutAsJsonAsync($"api/ReporteInspeccion/Editar/{id}", dto);
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

        public async Task<string> EliminarReporte(int id)
        {
            var resultado = await _http.DeleteAsync($"api/ReporteInspeccion/Eliminar/{id}");
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

        public async Task<List<ReporteInspeccionDTO>> MostrarReporteSimple()
        {
            var resultado = await _http.GetFromJsonAsync<APIResponse<List<ReporteInspeccionDTO>>>("api/ReporteInspeccion/ConsultaSimple");

            if (resultado!.EsExitoso == true)
            {
                List<ReporteInspeccionDTO> lista = resultado.Resultado;
                return lista;
            }
            else
            {
                throw new Exception(resultado.MensajeError);
            }
        }
    }
}
