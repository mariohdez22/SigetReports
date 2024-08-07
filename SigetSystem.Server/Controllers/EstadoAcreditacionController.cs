using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SigetSystem.Server.Repositorio.MetodoAplicado.Interfaces.Padres;
using SigetSystem.Shared.DTOs.Padres;
using SigetSystem.Shared.MPPs;

namespace SigetSystem.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoAcreditacionController : ControllerBase
    {
        private readonly IMetodoEstadoAcreditacion _repoAcreditacion;
        private readonly IMapper _mapper;

        public EstadoAcreditacionController(IMetodoEstadoAcreditacion repoAcreditacion, IMapper mapper)
        {
            _repoAcreditacion = repoAcreditacion;
            _mapper = mapper;
        }


        [HttpGet("Consulta")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ConsultaEstadoAcreditacion()
        {
            var _apiResponse = new APIResponse<List<EstadoAcreditacionDTO>>();

            try
            {
                var lista = await _repoAcreditacion.ConsultaEstadoAcreditacion();

                _apiResponse.Resultado = _mapper.Map<List<EstadoAcreditacionDTO>>(lista);
                _apiResponse.CodigoEstado = HttpStatusCode.OK;
                _apiResponse.EsExitoso = true;
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
