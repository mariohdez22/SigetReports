using System.ComponentModel;
using System.Net;
using AutoMapper;
using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SigetSystem.Server.Models.Entidades.Hijas;
using SigetSystem.Server.Repositorio.MetodoAplicado.Interfaces.Hijas;
using SigetSystem.Server.Repositorio.MetodoAplicado.Interfaces.Independientes;
using SigetSystem.Shared.DTOs.Hijas;
using SigetSystem.Shared.MPPs;

namespace SigetSystem.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteInspeccionController : ControllerBase
    {
        private readonly IMetodoReporteInspeccion _repo;
        private readonly ILogger<ReporteInspeccionController> _logger;
        private readonly IMapper _mapper;
        private readonly IMetodoJobReporte _job;

        public ReporteInspeccionController(IMetodoReporteInspeccion repo, ILogger<ReporteInspeccionController> logger, IMapper mapper, IMetodoJobReporte job)
        {
            _repo = repo;
            _logger = logger;
            _mapper = mapper;
            _job = job;
        }

        [HttpGet("Consulta")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ConsultaReporteInspeccion([FromQuery] ParametrosPaginacion pp)
        {
            var _apiResponse = new APIResponse<List<ReporteInspeccionDTO>>();

            try
            {
                _logger.LogInformation("Obteniendo los reportes de inspeccion");

                (var lista, int totalRegistro) = await _repo.ConsultaReporteInspeccion(pp);

                _apiResponse.Resultado = _mapper.Map<List<ReporteInspeccionDTO>>(lista);
                _apiResponse.TotalRegistros = totalRegistro;
                _apiResponse.EsExitoso = true;
                _apiResponse.CodigoEstado = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _apiResponse.EsExitoso = false;
                _apiResponse.MensajeError = ex.Message;
                _apiResponse.MensajesError = new List<string>() { ex.Message };
            }

            return Ok(_apiResponse);
        }

        [HttpGet("Obtener/{id:int}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> BuscarReporteInspeccion(int id)
        {
            var _apiResponse = new APIResponse<ReporteInspeccionDTO>();

            try
            {
                if (id <= 0)
                {
                    _logger.LogInformation($"El id proporcionado no es correcto: {id}");
                    _apiResponse.EsExitoso = false;
                    _apiResponse.CodigoEstado = HttpStatusCode.BadRequest;
                    return BadRequest(_apiResponse);
                }

                var resultado = await _repo.BuscarReporte(id);

                if (resultado == null)
                {
                    _logger.LogInformation($"El reporte inspeccion con id: {id}, no se ha encontrado");
                    _apiResponse.EsExitoso = false;
                    _apiResponse.CodigoEstado = HttpStatusCode.NotFound;
                    return NotFound(_apiResponse);
                }

                _apiResponse.EsExitoso = true;
                _apiResponse.CodigoEstado = HttpStatusCode.OK;
                _apiResponse.Resultado = _mapper.Map<ReporteInspeccionDTO>(resultado);

            }
            catch (Exception ex)
            {
                _apiResponse.EsExitoso = false;
                _apiResponse.MensajeError = ex.Message;
                _apiResponse.MensajesError = new List<string>() { ex.Message };
            }

            return Ok(_apiResponse);
        }

        [HttpPost("Agregar")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CrearReporteInspeccion(ReporteInspeccionDTO dto)
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

                var reporte = _mapper.Map<ReporteInspeccion>(dto);
                await _repo.CrearReporte(reporte);


                (int id, string token) = await _repo.GenerarEdicionPrograma(reporte.IdReporteInspeccion);


                await _job.GuardarJobReporte(id, token);

                _apiResponse.Resultado = "Programa en ejecucion";
                _apiResponse.EsExitoso = true;
                _apiResponse.CodigoEstado = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _apiResponse.EsExitoso = false;
                _apiResponse.MensajeError = ex.Message;
                _apiResponse.MensajesError = new List<string>() { ex.Message };
            }

            return Ok(_apiResponse);
        }


        [HttpPut("Editar/{id:int}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> EditarReporteInspeccion(ReporteInspeccionDTO dto, int id)
        {
            var _apiResponse = new APIResponse<string>();

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (dto == null || id != dto.IdReporteInspeccion)
                {
                    _apiResponse.CodigoEstado = HttpStatusCode.BadRequest;
                    _apiResponse.EsExitoso = false;
                    return BadRequest(_apiResponse);
                }

                var repoJob = await _job.BuscarJobReporte(id);
                var reporte = _mapper.Map<ReporteInspeccion>(dto);

                if (repoJob != null && reporte.IdEstadoReporte == 1 || reporte.IdEstadoReporte != 2)
                {
                    _job.BorrarJobReporte(repoJob.TokenJob);
                    await _repo.EditarReporte(reporte);

                    _apiResponse.Resultado = "Ejecucion correcta";
                }
                else if (repoJob != null && reporte.IdEstadoReporte == 2)
                {
                    await _repo.EditarReporte(reporte);

                    _apiResponse.Resultado = "Ejercucion correcta, el job no ha sido eliminado";
                }

                _apiResponse.EsExitoso = true;
                _apiResponse.CodigoEstado = HttpStatusCode.NoContent;

                return Ok(_apiResponse);
            }
            catch (Exception ex)
            {
                _apiResponse.EsExitoso = false;
                _apiResponse.MensajeError = ex.Message;
                _apiResponse.MensajesError = new List<string>() { ex.Message };
            }

            return BadRequest(_apiResponse);
        }

        [HttpDelete("Eliminar/{id:int}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> EliminarReporteInspeccion(int id)
        {
            var _apiResponse = new APIResponse<string>();

            try
            {
                if (id <= 0)
                {
                    _apiResponse.CodigoEstado = HttpStatusCode.BadRequest;
                    _apiResponse.EsExitoso = false;
                    return BadRequest(_apiResponse);
                }

                var reporte = await _repo.BuscarReporte(id);

                if (reporte == null)
                {
                    _apiResponse.CodigoEstado = HttpStatusCode.NotFound;
                    _apiResponse.EsExitoso = false;
                    return NotFound(_apiResponse);
                }

                await _repo.BorrarReporte(reporte);

                _apiResponse.Resultado = "Ha sido eliminado";
                _apiResponse.EsExitoso = true;
                _apiResponse.CodigoEstado = HttpStatusCode.OK;
                return Ok(_apiResponse);
            }
            catch (Exception ex)
            {
                _apiResponse.EsExitoso = false;
                _apiResponse.MensajeError = ex.Message;
                _apiResponse.MensajesError = new List<string>() { ex.Message };
            }

            return BadRequest(_apiResponse);
        }

        //----------------------------------------------------------------------------------------------------

        [HttpGet("ConsultaSimple")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ConsultaReporteSimple()
        {
            var _apiResponse = new APIResponse<List<ReporteInspeccionDTO>>();

            try
            {
                _logger.LogInformation("Obteniendo los reportes de inspeccion");

                var lista = await _repo.ConsultaReporteSimple();

                _apiResponse.Resultado = _mapper.Map<List<ReporteInspeccionDTO>>(lista);
                _apiResponse.EsExitoso = true;
                _apiResponse.CodigoEstado = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _apiResponse.EsExitoso = false;
                _apiResponse.MensajeError = ex.Message;
                _apiResponse.MensajesError = new List<string>() { ex.Message };
            }

            return Ok(_apiResponse);
        }

    }
}
