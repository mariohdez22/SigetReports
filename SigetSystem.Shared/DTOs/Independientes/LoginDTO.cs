using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigetSystem.Shared.DTOs.Independientes
{
    public class LoginDTO
    {
        public string Email { get; set; } = string.Empty;

        public string Contrasena { get; set; } = string.Empty;
    }
}
