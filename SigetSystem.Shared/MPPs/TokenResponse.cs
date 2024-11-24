using SigetSystem.Shared.DTOs.Hijas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
#pragma warning disable

namespace SigetSystem.Shared.MPPs
{
    public class TokenResponse
    {
        public string Token { get; set; }

        public HttpStatusCode CodigoEstado { get; set; }

        public string Resultado {  get; set; }

        //_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-|

        public string MensajeError { get; set; }
    }
}
