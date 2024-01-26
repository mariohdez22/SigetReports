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
        public async Task<IActionResult> ConsultaComentarioInconformidad([FromQuery]ParametrosPaginacion parametros)
        {
            var _apiResponse = new APIResponse<List<ComentariosInconformidadDTO>>();

            try
            {
                _logger.LogInformation("Obteniendo los comentarios de inconformidad");

                (var lista, int totalRegistro) = await _repo.ConsultaComentariosInconformidad(parametros);

                _apiResponse.Resultado = _mapper.Map<List<ComentariosInconformidadDTO>>(lista);
                _apiResponse.TotalRegistros = totalRegistro;
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

        [HttpGet("Buscar/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> BuscarComentarioInconformidad(int id)
        {
            var _apiResponse = new APIResponse<ComentariosInconformidadDTO>();

            try
            {
                _logger.LogInformation("Buscando el comentario");

                if (id <= 0)
                {
                    _logger.LogInformation($"El id proporcionado no es correcto: {id}");
                    _apiResponse.EsExitoso = false;
                    _apiResponse.CodigoEstado = HttpStatusCode.BadRequest;
                    return BadRequest(_apiResponse);
                }

                var registro = await _repo.BuscarComentariosInconformidad(id);

                if (registro == null)
                {
                    _logger.LogInformation($"El comentario con id: {id}, no se ha encontrado");
                    _apiResponse.EsExitoso = false;
                    _apiResponse.CodigoEstado = HttpStatusCode.NotFound;
                    return BadRequest(_apiResponse);
                }

                _logger.LogInformation($"El comentario con id: {id}, ha sido encontrado");

                _apiResponse.Resultado = _mapper.Map<ComentariosInconformidadDTO>(registro);
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


        [HttpPost("Agregar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CrearComentariosInconformidad(ComentariosInconformidadDTO dto)
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

                var comentario = _mapper.Map<ComentariosInconformidad>(dto);
                await _repo.CrearComentariosInconformidad(comentario);

                _apiResponse.EsExitoso = true;
                _apiResponse.CodigoEstado = HttpStatusCode.OK;
                _apiResponse.Resultado = "El comentario se ha creado con exito";
            }
            catch (Exception e)
            {
                _apiResponse.EsExitoso = false;
                _apiResponse.MensajeError = e.Message;
                _apiResponse.MensajesError = new List<string>() { e.ToString() };
            }

            return Ok(_apiResponse);
        }


        [HttpPut("Editar/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> EditarComentarioInconformidad(ComentariosInconformidadDTO dto, int id)
        {
            var _apiResponse = new APIResponse<string>();

            try
            {
                if (dto == null || id <= 0 || id != dto.IdComentarioInconformidad)
                {
                    _apiResponse.CodigoEstado = HttpStatusCode.BadRequest;
                    _apiResponse.EsExitoso = false;
                    return BadRequest(_apiResponse);
                }

                await _repo.EditarComentariosInconformidad(_mapper.Map<ComentariosInconformidad>(dto));

                _apiResponse.Resultado = "El comentario ha sido modificado";
                _apiResponse.EsExitoso = true;
                _apiResponse.CodigoEstado = HttpStatusCode.OK;

                return Ok(_apiResponse);
            }
            catch (Exception e)
            {
                _apiResponse.EsExitoso = false;
                _apiResponse.MensajeError = e.Message;
                _apiResponse.MensajesError = new List<string>() { e.ToString() };
            }

            return BadRequest(_apiResponse);
        }

        [HttpDelete("Eliminar/{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EliminarComentariosInconformidad(int id)
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

                var comentario = await _repo.BuscarComentariosInconformidad(id);

                if (comentario == null)
                {
                    _apiResponse.CodigoEstado = HttpStatusCode.NotFound;
                    _apiResponse.EsExitoso = false;
                    return NotFound(_apiResponse);
                }

                await _repo.BorrarComentariosInconformidad(comentario);

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
