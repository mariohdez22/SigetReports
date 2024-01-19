using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SigetSystem.Server.Repositorio.MetodoAplicado.Interfaces.Padres;
using SigetSystem.Shared.DTOs.Padres;
using SigetSystem.Shared.MPPs;

namespace SigetSystem.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoReporteController : ControllerBase
    {
        public readonly IMetodoEstadoReporte _repo;
        public readonly ILogger<EstadoReporteController> _logger;
        public readonly IMapper _mapper;

        public EstadoReporteController(IMetodoEstadoReporte repo, ILogger<EstadoReporteController> logger, IMapper mapper)
        {
            _repo = repo;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IActionResult> ConsultaEstadoReporte()
        {
            var _apiResponse = new APIResponse<List<EstadoReporteDTO>>();

            try
            {
                _logger.LogInformation("Obteniendo estado de reporte");

                var lista = await _repo.ConsultaEstadoReporte();

                _apiResponse.Resultado = _mapper.Map<List<EstadoReporteDTO>>(lista);
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
