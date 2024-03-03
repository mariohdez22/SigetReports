using SigetSystem.Client.Services.Interfaces;
using SigetSystem.Shared.DTOs.Hijas;
using SigetSystem.Shared.MPPs;

namespace SigetSystem.Client.Services.Servicios
{
    public class ComentarioSigetService : IComentarioSigetService
    {
        private readonly HttpClient _httpClient;

        public ComentarioSigetService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<ComentarioSigetDTO> BuscarComentario(int id)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse<List<ComentarioSigetDTO>>> MostrarComentarios(ParametrosPaginacion pp)
        {
            throw new NotImplementedException();
        }
    }
}
