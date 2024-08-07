using System.Net;
using AutoMapper;
using Hangfire.Logging;
using Microsoft.AspNetCore.Authorization;
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
    public class MunicipioInstalacionController : ControllerBase
    {
        public readonly IMetodoMunicipioInstalacion _repo;
        public readonly ILogger<MunicipioInstalacionController> _logger;
        public readonly IMapper _mapper;

        public MunicipioInstalacionController(IMetodoMunicipioInstalacion repo, ILogger<MunicipioInstalacionController> logger, IMapper mapper)
        {
            _repo = repo;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("Consulta")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ConsultaMunicipioInstalacion()
        {
            var _apiResponse = new APIResponse<List<MunicipioInstalacionDTO>>();

            try
            {
                _logger.LogInformation("Obteniendo el municipio de instalacion");

                var lista = await _repo.ConsultaMunicipioInstalacion();

                _apiResponse.Resultado = _mapper.Map<List<MunicipioInstalacionDTO>>(lista);
                _apiResponse.EsExitoso = true;
                _apiResponse.CodigoEstado = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error en el controlador de municipio");

                _apiResponse.EsExitoso = false;
                _apiResponse.MensajeError = ex.Message;
                _apiResponse.MensajesError = new List<string>() { ex.Message };
            }

            return Ok(_apiResponse);
        }
    }
}
