using System.Net;
using AutoMapper;
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
    public class ComentariosInconformidadController : ControllerBase
    {
        private readonly IMetodoComentariosInconformidad _repo;
        private readonly ILogger<ComentariosInconformidadController> _logger;
        private readonly IMapper _mapper;

        public ComentariosInconformidadController(IMetodoComentariosInconformidad repo,
            ILogger<ComentariosInconformidadController> logger, IMapper mapper)
        {
            _repo = repo;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("Consulta")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ConsultaComentarioInconformidad()
        {
            var _apiResponse = new APIResponse<List<ComentariosInconformidadDTO>>();

            try
            {
                _logger.LogInformation("Obteniendo los comentarios de inconformidad");

                var lista = await _repo.ConsultaComentariosInconformidad();

                _apiResponse.Resultado = _mapper.Map<List<ComentariosInconformidadDTO>>(lista);
                _apiResponse.EsExitoso = true;
                _apiResponse.CodigoEstado = HttpStatusCode.OK;

            }
            catch (Exception e)
            {
                _apiResponse.EsExitoso = false;
                _apiResponse.MensajeError = e.Message;
                _apiResponse.MensajesError = new List<string>() { e.ToString() };
            }

            return Ok(_apiResponse);
        }
    }
}
