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
    public class DepartamentoInstalacionController : ControllerBase
    {
        private readonly ILogger<DepartamentoInstalacionController> _logger;
        private readonly IMetodoDepartamentoInstalacion _repo;
        private readonly IMapper _mapper;

        public DepartamentoInstalacionController(ILogger<DepartamentoInstalacionController> logger, IMetodoDepartamentoInstalacion repo, IMapper mapper)
        {
            _logger = logger;
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("Consulta")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ConsultaDepartamentoInstalacion()
        {
            var _apiResponse = new APIResponse<List<DepartamentoInstalacionDTO>>();
            try
            {
                _logger.LogInformation("Obteniendo los departamentos");

                List<DepartamentoInstalacion> resultado = await _repo.ConsultaDepartamentoInstalacion();

                _apiResponse.Resultado = _mapper.Map<List<DepartamentoInstalacionDTO>>(resultado);
                _apiResponse.EsExitoso = true;
                _apiResponse.CodigoEstado = HttpStatusCode.OK;
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
