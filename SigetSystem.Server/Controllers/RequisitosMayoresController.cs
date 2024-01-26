using System.ComponentModel;
using System.Net;
using AutoMapper;
using Hangfire.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SigetSystem.Server.Models.Entidades.Hijas;
using SigetSystem.Server.Repositorio.MetodoAplicado.Interfaces.Hijas;
using SigetSystem.Shared.DTOs.Hijas;
using SigetSystem.Shared.MPPs;

namespace SigetSystem.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequisitosMayoresController : ControllerBase
    {
        private readonly IMetodoRequisitoMayor _repo;
        private readonly ILogger<RequisitosMayoresController> _logger;
        private readonly IMapper _mapper;

        public RequisitosMayoresController(IMetodoRequisitoMayor repo, ILogger<RequisitosMayoresController> logger, IMapper mapper)
        {
            _repo = repo;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("Consulta")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ConsultaRequisitosMayores([FromQuery] ParametrosPaginacion pp)
        {
            var _apiResponse = new APIResponse<List<RequisitoMayorDTO>>();

            try
            {
                _logger.LogInformation("Consultando los requisitos mayores");

                (var lista, int totalRegistros) = await _repo.ConsultaRequisitoMayor(pp);

                _apiResponse.Resultado = _mapper.Map<List<RequisitoMayorDTO>>(lista);
                _apiResponse.EsExitoso = true;
                _apiResponse.TotalRegistros = totalRegistros;
                _apiResponse.CodigoEstado = HttpStatusCode.OK;
            }
            catch (Exception e)
            {
                _apiResponse.EsExitoso = false;
                _apiResponse.MensajeError = e.Message;
                _apiResponse.MensajesError = new List<string>() { e.Message };
            }

            return Ok(_apiResponse);
        }

        [HttpGet("Buscar/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> BuscarRequisitoMayor(int id)
        {
            var _apiResponse = new APIResponse<RequisitoMayorDTO>();

            try
            {
                if (id <= 0)
                {
                    _apiResponse.EsExitoso = false;
                    _apiResponse.CodigoEstado = HttpStatusCode.BadRequest;
                    return BadRequest(_apiResponse);
                }

                var requisito = await _repo.BuscarRequisitoMayor(id);

                if (requisito == null)
                {
                    _apiResponse.EsExitoso = false;
                    _apiResponse.CodigoEstado = HttpStatusCode.NotFound;
                    return NotFound(_apiResponse);
                }

                _apiResponse.EsExitoso = true;
                _apiResponse.CodigoEstado = HttpStatusCode.OK;
                _apiResponse.Resultado = _mapper.Map<RequisitoMayorDTO>(requisito);
            }
            catch (Exception e)
            {
                _apiResponse.EsExitoso = false;
                _apiResponse.MensajeError = e.Message;
                _apiResponse.MensajesError = new List<string>() { e.Message };
            }

            return Ok(_apiResponse);
        }

        [HttpPost("Agregar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AgregarRequisitoMayor(RequisitoMayorDTO dto)
        {
            var _apiResponse = new APIResponse<string>();

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (dto == null)
                {
                    return BadRequest(dto);
                }

                var requisito = _mapper.Map<RequisitoMayor>(dto);
                await _repo.CrearRequisitoMayor(requisito);

                _apiResponse.EsExitoso = true;
                _apiResponse.CodigoEstado = HttpStatusCode.NoContent;
                _apiResponse.Resultado = "El requisito ha sido creado";


                return Ok(_apiResponse);
            }
            catch (Exception e)
            {
                _apiResponse.EsExitoso = false;
                _apiResponse.MensajeError = e.Message;
                _apiResponse.MensajesError = new List<string>() { e.Message };
            }

            return BadRequest(_apiResponse);
        }

        [HttpPut("Editar/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EditarRequisitoMayor(RequisitoMayorDTO dto, int id)
        {
            var _apiResponse = new APIResponse<string>();

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (dto == null)
                {
                    return BadRequest(dto);
                }

                if (id <= 0 || id != dto.IdMayores)
                {
                    _apiResponse.EsExitoso = false;
                    _apiResponse.CodigoEstado = HttpStatusCode.BadRequest;
                    return BadRequest(_apiResponse);
                }

                var rm = _mapper.Map<RequisitoMayor>(dto);

                await _repo.EditarRequisitoMayor(rm);

                _apiResponse.Resultado = "Ha sido actualizado con exito";
                _apiResponse.EsExitoso = true;
                _apiResponse.CodigoEstado = HttpStatusCode.NoContent;

                return Ok(_apiResponse);
            }
            catch (Exception e)
            {
                _apiResponse.EsExitoso = false;
                _apiResponse.MensajeError = e.Message;
                _apiResponse.MensajesError = new List<string>() { e.Message };
            }

            return BadRequest(_apiResponse);
        }


        [HttpDelete("Eliminar/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EliminarRequisitoMayor(RequisitoMayorDTO dto, int id)
        {
            var _apiResponse = new APIResponse<string>();

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (dto == null)
                {
                    return BadRequest(dto);
                }

                if (id <= 0)
                {
                    _apiResponse.EsExitoso = false;
                    _apiResponse.CodigoEstado = HttpStatusCode.BadRequest;
                    return BadRequest(_apiResponse);
                }

                var reqBuscado = await _repo.BuscarRequisitoMayor(id);

                if (reqBuscado == null)
                {
                    _apiResponse.EsExitoso = false;
                    _apiResponse.CodigoEstado = HttpStatusCode.NotFound;
                    return NotFound(_apiResponse);
                }

                await _repo.BorrarRequisitoMayor(reqBuscado);

                _apiResponse.Resultado = "Ha sido eliminado con exito";
                _apiResponse.EsExitoso = true;
                _apiResponse.CodigoEstado = HttpStatusCode.NoContent;

                return Ok(_apiResponse);
            }
            catch (Exception e)
            {
                _apiResponse.EsExitoso = false;
                _apiResponse.MensajeError = e.Message;
                _apiResponse.MensajesError = new List<string>() { e.Message };
            }

            return BadRequest(_apiResponse);
        }


    }
}
