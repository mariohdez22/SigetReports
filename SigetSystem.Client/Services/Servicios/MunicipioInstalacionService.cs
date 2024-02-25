using SigetSystem.Client.Services.Interfaces;
using SigetSystem.Shared.DTOs.Padres;
using SigetSystem.Shared.MPPs;
using System.Net.Http.Json;

namespace SigetSystem.Client.Services.Servicios
{
    public class MunicipioInstalacionService : IMunicipioInstalacionService
    {
        private readonly HttpClient _http;

        public MunicipioInstalacionService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<MunicipioInstalacionDTO>> MostrarMunicipio()
        {
            var resultado = await _http.GetFromJsonAsync<APIResponse<List<MunicipioInstalacionDTO>>>("api/MunicipioInstalacion/Consulta");

            if (resultado!.EsExitoso == true)
            {
                List<MunicipioInstalacionDTO> lista = resultado.Resultado;

                return lista;
            }
            else
            {
                throw new Exception(resultado.MensajeError);
            }
        }
    }

}
