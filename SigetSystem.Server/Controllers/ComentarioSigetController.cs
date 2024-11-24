using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SigetSystem.Server.Models.Entidades.Hijas;
using SigetSystem.Server.Repositorio.MetodoAplicado.Interfaces.Hijas;
using SigetSystem.Shared.DTOs.Hijas;
using SigetSystem.Shared.MPPs;
using System.Net;

namespace SigetSystem.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioSigetController : ControllerBase
    {
        private readonly ILogger<ComentarioSigetController> _logger;
        private readonly IMetodoComentarioSiget _repositorio;
        private readonly IMapper _mapper;

        public ComentarioSigetController(ILogger<ComentarioSigetController> logger,
                                         IMetodoComentarioSiget repositorio,
                                         IMapper mapper)
        {
            _logger = logger;
            _repositorio = repositorio;
            _mapper = mapper;   
        }

        [HttpGet("Consulta")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ConsultaComentario([FromQuery] ParametrosPaginacion parametros)
        {
            var _apiResponse = new APIResponse<List<ComentarioSigetDTO>>();

            try
            {
                _logger.LogInformation("Obtener todo el Comentario");

                (List<ComentarioSiget> lista, int totalRegistros) = await _repositorio.ConsultaComentario(parametros);

                _apiResponse.Resultado = _mapper.Map<List<ComentarioSigetDTO>>(lista);
                _apiResponse.TotalRegistros = totalRegistros;
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

        [HttpGet("Obtener/{id:int}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> BuscarComentario(int id)
        {
            var _apiResponse = new APIResponse<ComentarioSigetDTO>();

            try
            {
                if (id == 0)
                {
                    _logger.LogInformation($"Error al obtener el Comentario con el Id {id}");
                    _apiResponse.CodigoEstado = HttpStatusCode.BadRequest;
                    _apiResponse.EsExitoso = false;
                    return BadRequest(_apiResponse);
                }

                var comentario = await _repositorio.BuscarComentario(id);

                if (comentario == null)
                {
                    _apiResponse.CodigoEstado = HttpStatusCode.NotFound;
                    _apiResponse.EsExitoso = false;
                    return NotFound(_apiResponse);
                }

                _apiResponse.Resultado = _mapper.Map<ComentarioSigetDTO>(comentario);
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

        [HttpPost("Agregar")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CrearComentario(ComentarioSigetDTO comentarioSigetDTO)
        {
            var _apiResponse = new APIResponse<string>();

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (comentarioSigetDTO == null)
                {
                    return BadRequest(comentarioSigetDTO);
                }

                //--------------------------------------------------------------

                ComentarioSiget comentario = _mapper.Map<ComentarioSiget>(comentarioSigetDTO);
                await _repositorio.CrearComentario(comentario);

                //--------------------------------------------------------------

                _apiResponse.Resultado = "Ejecucion Correcta";
                _apiResponse.CodigoEstado = HttpStatusCode.Created;
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

        [HttpPut("Editar/{id:int}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EditarComentario(ComentarioSigetDTO comentarioSigetDTO, int id)
        {
            var _apiResponse = new APIResponse<string>();

            try
            {
                if (comentarioSigetDTO == null || id != comentarioSigetDTO.IdComentario)
                {
                    _logger.LogInformation($"ID DTO: {comentarioSigetDTO.IdReporteInspeccion}");
                    _logger.LogInformation($"ID P: {id}");

                    _apiResponse.CodigoEstado = HttpStatusCode.BadRequest;
                    _apiResponse.EsExitoso = false;
                    return BadRequest(_apiResponse);
                }

                ComentarioSiget comentario = _mapper.Map<ComentarioSiget>(comentarioSigetDTO);
                await _repositorio.EditarComentario(comentario);

                _apiResponse.Resultado = "Ejecucion Correcta";
                _apiResponse.CodigoEstado = HttpStatusCode.NoContent;
                _apiResponse.EsExitoso = true;

                return Ok(_apiResponse);
            }
            catch (Exception ex)
            {
                _apiResponse.EsExitoso = false;
                _apiResponse.MensajesError = new List<string>() { ex.ToString() };
                _apiResponse.MensajeError = ex.Message;
            }

            return BadRequest(_apiResponse);
        }

        [HttpDelete("Eliminar/{id:int}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EliminarComentario(int id)
        {
            var _apiResponse = new APIResponse<string>();

            try
            {
                if (id == 0)
                {
                    _apiResponse.CodigoEstado = HttpStatusCode.BadRequest;
                    _apiResponse.EsExitoso = false;
                    return BadRequest(_apiResponse);
                }

                var comentario = await _repositorio.BuscarComentario(id);

                if (comentario == null)
                {
                    _apiResponse.CodigoEstado = HttpStatusCode.NotFound;
                    _apiResponse.EsExitoso = false;
                    return NotFound(_apiResponse);
                }

                await _repositorio.BorrarComentario(comentario);

                _apiResponse.Resultado = "Ejecucion Correcta";
                _apiResponse.CodigoEstado = HttpStatusCode.NoContent;
                _apiResponse.EsExitoso = true;

                return Ok(_apiResponse);
            }
            catch (Exception ex)
            {
                _apiResponse.EsExitoso = false;
                _apiResponse.MensajesError = new List<string>() { ex.ToString() };
                _apiResponse.MensajeError = ex.Message;
            }

            return BadRequest(_apiResponse);
        }
    }
}
