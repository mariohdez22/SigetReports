using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SigetSystem.Shared.DTOs.Padres;

namespace SigetSystem.Shared.DTOs.Hijas
{
    public class PersonalDTO
    {
        public int IdPersonal { get; set; }

        [Required]
        public string Nombres { get; set; } = string.Empty;

        [Required]
        public string Celular { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string DUI { get; set; } = string.Empty;

        [Required]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        public string Nickname { get; set; } = string.Empty;

        [Required]
        public string Contrasena { get; set; } = string.Empty;

        [Required]
        public int IdRangoPersonal { get; set; }

        [Required]
        public int IdEstadoPersonal { get; set; }

        public virtual RangoPersonalDTO? RangoPersonal { get; set; }

        public virtual EstadoPersonalDTO? EstadoPersonal { get; set; }
    }
}
