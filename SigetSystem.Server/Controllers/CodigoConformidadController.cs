using System.Net;
using AutoMapper;
using Hangfire.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SigetSystem.Server.Models.Entidades.Padres;
using SigetSystem.Server.Repositorio.MetodoAplicado.Interfaces.Padres;
using SigetSystem.Shared.DTOs.Padres;
using SigetSystem.Shared.MPPs;

namespace SigetSystem.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodigoConformidadController : ControllerBase
    {
        private readonly IMetodoCodigoConformidad _repo;
        private readonly ILogger<CodigoConformidadController> _logger;
        private readonly IMapper _mapper;

        public CodigoConformidadController(IMetodoCodigoConformidad repo, ILogger<CodigoConformidadController> logger, IMapper mapper)
        {
            _repo = repo;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("Consulta")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ConsultaCodigoConformidad()
        {
            var _apiResponse = new APIResponse<List<CodigoConformidadDTO>>();

            try
            {
                var lista = await _repo.ConsultaCodigoConformidad();

                _apiResponse.Resultado = _mapper.Map<List<CodigoConformidadDTO>>(lista);
                _apiResponse.CodigoEstado = HttpStatusCode.OK;
                _apiResponse.EsExitoso = true;
            }
            catch (Exception ex)
            {
                _apiResponse.EsExitoso = false;
                _apiResponse.MensajeError = ex.Message;
                _apiResponse.MensajesError = new List<string>() { ex.ToString() };
            }

            return Ok(_apiResponse);
        }
    }
}
