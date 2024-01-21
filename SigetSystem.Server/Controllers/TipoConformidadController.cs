using AutoMapper;
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
    public class TipoConformidadController : ControllerBase
    {
        private readonly ILogger<TipoConformidadController> _logger;
        private readonly IMetodoTipoConformidad _repositorio;
        private readonly IMapper _mapper;

        public TipoConformidadController(ILogger<TipoConformidadController> logger,
                                         IMetodoTipoConformidad repositorio,
                                         IMapper mapper)
        {
            _logger = logger;
            _repositorio = repositorio;
            _mapper = mapper;
        }

        [HttpGet("Consulta")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ConsultaTipoConformidad()
        {
            var _apiResponse = new APIResponse<List<TipoConformidadDTO>>();

            try
            {
                _logger.LogInformation("Obtener todos los tipos de conformidad");

                List<TipoConformidad> lista = await _repositorio.ConsultaTipoConformidad();

                _apiResponse.Resultado = _mapper.Map<List<TipoConformidadDTO>>(lista);
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
