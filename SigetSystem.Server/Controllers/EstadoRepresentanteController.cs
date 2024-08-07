using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SigetSystem.Server.Models.Entidades.Padres;
using SigetSystem.Server.Repositorio.MetodoAplicado.Interfaces.Hijas;
using SigetSystem.Server.Repositorio.MetodoAplicado.Interfaces.Padres;
using SigetSystem.Shared.DTOs.Padres;
using SigetSystem.Shared.MPPs;
using System.Net;

namespace SigetSystem.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoRepresentanteController : ControllerBase
    {
        private readonly ILogger<EstadoRepresentanteController> _logger;
        private readonly IMetodoEstadoRepresentante _repositorio;
        private readonly IMapper _mapper;

        public EstadoRepresentanteController(ILogger<EstadoRepresentanteController> logger,
                                        IMetodoEstadoRepresentante repositorio,
                                        IMapper mapper)
        {
            _logger = logger;
            _repositorio = repositorio;
            _mapper = mapper;
        }

        [HttpGet("Consulta")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ConsultaEstadoRepresentante()
        {
            var _apiResponse = new APIResponse<List<EstadoRepresentanteDTO>>();

            try
            {
                _logger.LogInformation("Obtener todos los estados del personal");

                List<EstadoRepresentante> lista = await _repositorio.ConsultaEstadoRepresentante();

                _apiResponse.Resultado = _mapper.Map<List<EstadoRepresentanteDTO>>(lista);
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
