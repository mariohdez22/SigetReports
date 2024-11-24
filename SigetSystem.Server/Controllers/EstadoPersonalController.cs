using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SigetSystem.Server.Models.Entidades.Padres;
using SigetSystem.Server.Repositorio.MetodoAplicado.Interfaces.Padres;
using SigetSystem.Shared.DTOs.Padres;
using SigetSystem.Shared.MPPs;
using System.Net;

namespace SigetSystem.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoPersonalController : ControllerBase
    {
        private readonly ILogger<EstadoPersonalController> _logger;
        private readonly IMetodoEstadoPersonal _repositorio;
        private readonly IMapper _mapper;

        public EstadoPersonalController(ILogger<EstadoPersonalController> logger,
                                        IMetodoEstadoPersonal repositorio,
                                        IMapper mapper)
        {
            _logger = logger;
            _repositorio = repositorio;
            _mapper = mapper;
        }

        [HttpGet("Consulta")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ConsultaEstadoPersonal()
        {
            var _apiResponse = new APIResponse<List<EstadoPersonalDTO>>();

            try
            {
                _logger.LogInformation("Obtener todos los estados del personal");

                List<EstadoPersonal> lista = await _repositorio.ConsultaEstadoPersonal();

                _apiResponse.Resultado = _mapper.Map<List<EstadoPersonalDTO>>(lista);
                _apiResponse.CodigoEstado = HttpStatusCode.OK;
                _apiResponse.EsExitoso = true;
            }
            catch (Exception ex)
            {
                _apiResponse.EsExitoso = false;
                _apiResponse.MensajesError = new List<string>() { ex.ToString() };
                _apiResponse.MensajeError = ex.Message;
            }

            return Ok(_apiResponse);
        }
    }
}
