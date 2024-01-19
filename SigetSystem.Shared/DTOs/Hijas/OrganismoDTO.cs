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
    public class OrganismoDTO
    {
        public int IdOrganismo { get; set; }

        [Required]
        public string NombreOIA { get; set; } = string.Empty;

        [Required]
        public string Responsable { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Telefono { get; set; } = string.Empty;

        [Required]
        public string CodigoUnico { get; set; } = string.Empty;

        [Required]
        public int IdEstadoAcreditacion { get; set; }

        [Required]
        public int IdPersonal { get; set; }

        public virtual EstadoAcreditacionDTO? EstadoAcreditacion { get; set; }

        public virtual PersonalDTO? Personal { get; set; }
    }
}
