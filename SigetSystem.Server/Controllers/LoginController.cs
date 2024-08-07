using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SigetSystem.Server.Models.Entidades.Hijas;
using SigetSystem.Server.Repositorio.MetodoAplicado.Interfaces.Independientes;
using SigetSystem.Shared.DTOs.Hijas;
using SigetSystem.Shared.DTOs.Independientes;
using SigetSystem.Shared.MPPs;
using System.Net;

namespace SigetSystem.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMetodoLogin _repositorio;
        private readonly IMapper _mapper;

        public LoginController(IMetodoLogin repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        [HttpPost("Logins")]
        public async Task<IActionResult> LoginPerson(LoginDTO loginDto) 
        {
            var _tokenResponse = new TokenResponse(); 

            try
            {
                (bool IsSuccess, string Token) = await _repositorio.LoginPersonal(loginDto);

                if (IsSuccess != true || Token == "")
                {
                    _tokenResponse.MensajeError = "Credenciales invalidas o mal escritas.";
                }

                _tokenResponse.Resultado = "Logeo Exitoso";
                _tokenResponse.Token = Token;
                _tokenResponse.CodigoEstado = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _tokenResponse.MensajeError = ex.Message;
            }

            return Ok(_tokenResponse);
        }
    }
}
