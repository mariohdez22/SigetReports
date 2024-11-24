using SigetSystem.Oia.Services.Interfaces;
using SigetSystem.Shared.DTOs.Hijas;
using SigetSystem.Shared.DTOs.Padres;
using SigetSystem.Shared.MPPs;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Reflection.Metadata;

namespace SigetSystem.Oia.Services.Servicios
{
    public class GestionReporteInspeccionService : IGestionReporteInspeccionService
    {
        private readonly HttpClient _httpClient;

        public GestionReporteInspeccionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ReporteInspeccionDTO>> obtenerReportes()
        {
            ParametrosPaginacion pp = new ParametrosPaginacion()
            {
                NumeroPagina = 1,
                TamañoPagina = 5,
                Orden = "Descendente",
                ID1 = 1,
                ID2 = 0
            };

            string url = $"api/ReporteInspeccion/Consulta?NumeroPagina={pp.NumeroPagina}&TamañoPagina={pp.TamañoPagina}&Orden={pp.Orden}&ID1={pp.ID1}&ID2={pp.ID2}";

            var resultado = await _httpClient.GetFromJsonAsync<APIResponse<List<ReporteInspeccionDTO>>>(url);

            if (resultado!.EsExitoso)
            {
                return resultado.Resultado;
            }
            else
            {
                throw new Exception(resultado.MensajeError);
            }

        }

        public async Task<ReporteInspeccionDTO> obtenerReporte(int id)
        {
            var resultado = await _httpClient.GetFromJsonAsync<APIResponse<ReporteInspeccionDTO>>($"api/ReporteInspeccion/Obtener/{id}");

            if (resultado!.EsExitoso == true)
            {
                ReporteInspeccionDTO r = resultado.Resultado;

                return r;
            }
            else
            {
                throw new Exception(resultado.MensajeError);
            }
        }

    }
}
