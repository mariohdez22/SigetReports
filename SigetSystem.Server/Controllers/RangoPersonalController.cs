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
    public class RangoPersonalController : ControllerBase
    {
        private readonly ILogger<RangoPersonalController> _logger;
        private readonly IMetodoRangoPersonal _repositorio;
        private readonly IMapper _mapper;

        public RangoPersonalController(ILogger<RangoPersonalController> logger,
                                        IMetodoRangoPersonal repositorio,
                                        IMapper mapper)
        {
            _logger = logger;
            _repositorio = repositorio;
            _mapper = mapper;
        }

        [HttpGet("Consulta")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ConsultaRangoPersonal()
        {
            var _apiResponse = new APIResponse<List<RangoPersonalDTO>>();

            try
            {
                _logger.LogInformation("Obtener todos los rangos del personal");

                List<RangoPersonal> lista = await _repositorio.ConsultaRangoPersonal();

                _apiResponse.Resultado = _mapper.Map<List<RangoPersonalDTO>>(lista);
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
