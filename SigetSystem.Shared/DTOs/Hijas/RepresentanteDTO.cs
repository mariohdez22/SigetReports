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
    public class RepresentanteDTO
    {
        public int IdRepresentante { get; set; }

        [Required]
        public string Nombres { get; set; } = string.Empty;

        [Required]
        public string Celular { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string DUI { get; set; } = string.Empty;

        [Required]
        public string ComprobanteOIA { get; set; } = string.Empty;

        [Required]
        public string Nickname { get; set; } = string.Empty;

        [Required]
        public string Contrasena { get; set; } = string.Empty;

        [Required]
        public int IdEstadoRepresentante { get; set; }

        [Required]
        public int IdOrganismo { get; set; }

        public virtual EstadoRepresentanteDTO? EstadoRepresentante { get; set; }

        public virtual OrganismoDTO? Organismo { get; set; }
    }
}
