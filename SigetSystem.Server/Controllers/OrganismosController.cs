using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SigetSystem.Server.Repositorio.MetodoAplicado.Interfaces.Hijas;
using SigetSystem.Shared.DTOs.Hijas;
using SigetSystem.Shared.MPPs;
using System.Net;
using SigetSystem.Server.Models.Entidades.Hijas;

namespace SigetSystem.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganismosController : ControllerBase
    {
        private readonly IMetodoOrganismo _repoOrg;
        private readonly ILogger<OrganismosController> _logger;
        private readonly IMapper _mapper;

        public OrganismosController(IMetodoOrganismo repoOrg, ILogger<OrganismosController> logger, IMapper mapper)
        {
            _repoOrg = repoOrg;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("Consulta")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ConsultaOrganismo([FromQuery] ParametrosPaginacion pp)
        {
            var _apiResponse = new APIResponse<List<OrganismoDTO>>();

            try
            {
                _logger.LogInformation("Consultadon Organismos");

                (var lista, int totalRegistros) = await _repoOrg.ConsultaOrganismo(pp);

                _apiResponse.EsExitoso = true;
                _apiResponse.TotalRegistros = totalRegistros;
                _apiResponse.Resultado = _mapper.Map<List<OrganismoDTO>>(lista);
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

        [HttpGet("Buscar/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> BuscarOrganismo(int id)
        {
            var _apiResponse = new APIResponse<OrganismoDTO>();

            try
            {
                _logger.LogInformation("Buscando organismo");

                if (id <= 0)
                {
                    _logger.LogInformation($"El id proporcionado no es correcto {id}");
                    _apiResponse.EsExitoso = false;
                    _apiResponse.CodigoEstado = HttpStatusCode.BadRequest;
                    return BadRequest(_apiResponse);
                }

                var registro = await _repoOrg.Buscar(id);

                if (registro == null)
                {
                    _logger.LogInformation($"El organismo con id: {id}, no se ha encontrado");
                    _apiResponse.EsExitoso = false;
                    _apiResponse.CodigoEstado = HttpStatusCode.NotFound;
                    return NotFound(_apiResponse);
                }

                _logger.LogInformation($"El organismo con id: {id}, ha sido encontrado");
                _apiResponse.EsExitoso = true;
                _apiResponse.Resultado = _mapper.Map<OrganismoDTO>(registro);
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

        [HttpPost("Agregar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AgregarOrganismos(OrganismoDTO dto)
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

                var org = _mapper.Map<Organismo>(dto);
                await _repoOrg.CrearOrganismo(org);

                _apiResponse.EsExitoso = true;
                _apiResponse.CodigoEstado = HttpStatusCode.Created;
                _apiResponse.Resultado = "Ejecucion Correcta";
            }
            catch (Exception ex)
            {
                _apiResponse.EsExitoso = false;
                _apiResponse.MensajeError = ex.Message;
                _apiResponse.MensajesError = new List<string>() { ex.ToString() };
            }

            return Ok(_apiResponse);
        }

        [HttpPut("Editar/{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> EditarOrganismos(OrganismoDTO dto, int id)
        {
            var _apiResponse = new APIResponse<string>();

            try
            {
                if (dto == null || id != dto.IdOrganismo)
                {
                    _apiResponse.EsExitoso = false;
                    _apiResponse.CodigoEstado = HttpStatusCode.BadRequest;
                    return BadRequest(_apiResponse);
                }

                await _repoOrg.EditarOrganismo(_mapper.Map<Organismo>(dto));

                _apiResponse.EsExitoso = true;
                _apiResponse.CodigoEstado = HttpStatusCode.NoContent;
                _apiResponse.Resultado = "Ejecucion Correcta";

                return Ok(_apiResponse);

            }
            catch (Exception ex)
            {
                _apiResponse.EsExitoso = false;
                _apiResponse.MensajeError = ex.Message;
                _apiResponse.MensajesError = new List<string>() { ex.ToString() };
            }

            return BadRequest(_apiResponse);
        }


        [HttpDelete("Eliminar/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EliminarOrganismo(int id)
        {
            var _apiResponse = new APIResponse<string>();

            try
            {
                if (id <= 0)
                {
                    _apiResponse.EsExitoso = false;
                    _apiResponse.CodigoEstado = HttpStatusCode.BadRequest;
                    return BadRequest(_apiResponse);
                }

                var registro = await _repoOrg.Buscar(id);

                if (registro == null)
                {
                    _apiResponse.EsExitoso = false;
                    _apiResponse.CodigoEstado = HttpStatusCode.NotFound;
                    return NotFound(_apiResponse);
                }

                await _repoOrg.BorrarOrganismo(registro);

                _apiResponse.EsExitoso = true;
                _apiResponse.CodigoEstado = HttpStatusCode.OK;
                _apiResponse.Resultado = "Ejecucion Correcta";

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
    }
}
