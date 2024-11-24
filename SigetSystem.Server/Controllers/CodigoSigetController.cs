using System.Net;
using AutoMapper;
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
    public class CodigoSigetController : ControllerBase
    {
        private readonly ILogger<CodigoSigetController> _logger;
        private readonly IMetodoCodigoSiget _repo;
        private readonly IMapper _mapper;

        public CodigoSigetController(ILogger<CodigoSigetController> logger, IMetodoCodigoSiget repo, IMapper mapper)
        {
            _logger = logger;
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("Consulta")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ConsultaCodigoSiget()
        {
            var _apiResponse = new APIResponse<List<CodigoSigetDTO>>();

            try
            {
                _logger.LogInformation("Obteniendo los codigos del siget");

                List<CodigoSiget> resultado = await _repo.ConsultaCodigoSiget();

                _apiResponse.Resultado = _mapper.Map<List<CodigoSigetDTO>>(resultado);
                _apiResponse.EsExitoso = true;
                _apiResponse.CodigoEstado = HttpStatusCode.OK;
            }
            catch(Exception ex) 
            {
                _apiResponse.EsExitoso = false;
                _apiResponse.MensajeError = ex.Message;
                _apiResponse.MensajesError = new List<string>() {ex.ToString()};
            }

            return Ok(_apiResponse);
        }

    }

}
