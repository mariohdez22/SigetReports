using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SigetSystem.Server.Repositorio.MetodoAplicado.Interfaces.Padres;
using SigetSystem.Shared.DTOs.Padres;
using SigetSystem.Shared.MPPs;

namespace SigetSystem.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoComentarioController : ControllerBase
    {
        private readonly IMetodoEstadoComentario _repo;
        private readonly ILogger<EstadoComentarioController> _logger;
        private readonly IMapper _mapper;

        public EstadoComentarioController(IMetodoEstadoComentario repo, ILogger<EstadoComentarioController> logger,
            IMapper mapper)
        {
            _repo = repo;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ConsultaEstadoComentario()
        {
            var _apiResponse = new APIResponse<List<EstadoComentarioDTO>>();

            try
            {
                _logger.LogInformation("Consultado estados comentarios");

                var lista = await _repo.Consulta();

                _apiResponse.Resultado = _mapper.Map<List<EstadoComentarioDTO>>(lista);
                _apiResponse.EsExitoso = true;
                _apiResponse.CodigoEstado = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _apiResponse.EsExitoso = false;
                _apiResponse.MensajeError = ex.Message;
                _apiResponse.MensajesError = new List<string>() {ex.ToString()};
            }

            return Ok(_apiResponse);
        }
    }
}
