using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SigetSystem.Server.Models.Entidades.Hijas;
using SigetSystem.Server.Repositorio.MetodoAplicado.Interfaces.Hijas;
using SigetSystem.Shared.DTOs.Hijas;
using SigetSystem.Shared.MPPs;
using System.ComponentModel;
using System.Net;

namespace SigetSystem.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepresentanteController : ControllerBase
    {
        private readonly ILogger<RepresentanteController> _logger;
        private readonly IMetodoRepresentante _repositorio;
        private readonly IMapper _mapper;

        public RepresentanteController(ILogger<RepresentanteController> logger,
                                       IMetodoRepresentante repositorio,
                                       IMapper mapper)
        {
            _logger = logger;
            _repositorio = repositorio;
            _mapper = mapper;
        }

        [HttpGet("Consulta")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> ConsultarRepresentante([FromQuery] ParametrosPaginacion parametros)
        {
            var _apiResponse = new APIResponse<List<RepresentanteDTO>>();

            try
            {
                _logger.LogInformation("Obtener todos los representante");

                (List<Representante> lista,int totalRegistros) = await _repositorio.ConsultaRepresentante(parametros); 
                
                _apiResponse.Resultado = _mapper.Map<List<RepresentanteDTO>>(lista);
                _apiResponse.TotalRegistros = totalRegistros;
                _apiResponse.CodigoEstado = System.Net.HttpStatusCode.OK;
                _apiResponse.EsExitoso = true;
            }
            catch (Exception ex)
            {

                _apiResponse.EsExitoso = false;
                _apiResponse.MensajesError = new List<string>() { ex.ToString()};
                _apiResponse.MensajeError = ex.Message;
            }

            return Ok(_apiResponse);
        }
        [HttpGet("Obtener/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> BuscarRepresentante(int id)
        {
            var _apiResponse = new APIResponse<RepresentanteDTO>();

            try
            {
                if (id == 0)
                {
                    _logger.LogInformation($"Error al obtener el representante con el Id {id}");
                    _apiResponse.CodigoEstado = HttpStatusCode.BadRequest;
                    _apiResponse.EsExitoso = false;
                    return BadRequest(_apiResponse);
                }

                var representante = await _repositorio.BuscarRepresentante(id);

                if (representante == null)
                {
                    _apiResponse.CodigoEstado = HttpStatusCode.NotFound;
                    _apiResponse.EsExitoso = false;
                    return NotFound(_apiResponse);
                }

                _apiResponse.Resultado = _mapper.Map<RepresentanteDTO>(representante);
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
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CrearRepresentante(RepresentanteDTO representanteDTO)
        {
            var _apiResponse = new APIResponse<string>();

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (representanteDTO == null)
                {
                    return BadRequest(representanteDTO);
                }

                //--------------------------------------------------------------

                Representante representante = _mapper.Map<Representante>(representanteDTO);
                await _repositorio.CrearRepresentante(representante);

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
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EditarRepresentante(RepresentanteDTO representanteDTO, int id)
        {
            var _apiResponse = new APIResponse<string>();

            try
            {
                if (representanteDTO == null || id != representanteDTO.IdRepresentante)
                {
                    _apiResponse.CodigoEstado = HttpStatusCode.BadRequest;
                    _apiResponse.EsExitoso = false;
                    return BadRequest(_apiResponse);
                }

                Representante representante = _mapper.Map<Representante>(representanteDTO);
                await _repositorio.EditarRepresentante(representante);

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
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EliminarRepresentante(int id)
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

                var representante = await _repositorio.BuscarRepresentante(id);

                if (representante == null)
                {
                    _apiResponse.CodigoEstado = HttpStatusCode.NotFound;
                    _apiResponse.EsExitoso = false;
                    return NotFound(_apiResponse);
                }

                await _repositorio.BorrarRepresentante(representante);

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
