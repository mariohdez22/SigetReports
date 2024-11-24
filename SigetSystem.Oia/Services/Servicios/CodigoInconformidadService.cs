using SigetSystem.Oia.Services.Interfaces;
using SigetSystem.Shared.DTOs.Padres;
using SigetSystem.Shared.MPPs;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace SigetSystem.Oia.Services.Servicios
{
    public class CodigoInconformidadService : ICodigoInconformidadService
    {
        private readonly HttpClient _httpClient;

        public CodigoInconformidadService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

    }
}
