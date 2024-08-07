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

        [Required(ErrorMessage = "El Campo {0} es obligatorio.")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ ]*$", ErrorMessage = "Por favor ingrese solo letras, espacios y tildes.")]
        [StringLength(28, ErrorMessage = "La longitud debe estar entre 4 y 28 caracteres.", MinimumLength = 4)]
        public string Nombres { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Campo {0} es obligatorio.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingrese solo números.")]
        [StringLength(8, ErrorMessage = "La longitud debe estar entre 8 y 8 caracteres.", MinimumLength = 8)]
        public string Celular { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Campo {0} es obligatorio.")]
        [RegularExpression(@"^[^\s]+$", ErrorMessage = "Los espacios no están permitidos.")]
        [StringLength(28, ErrorMessage = "La longitud debe estar entre 5 y 28 caracteres.", MinimumLength = 5)]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Campo {0} es obligatorio.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingrese solo números.")]
        [StringLength(9, ErrorMessage = "La longitud debe estar entre 9 y 9 caracteres.", MinimumLength = 9)]
        public string DUI { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Campo {0} es obligatorio.")]
        [StringLength(28, ErrorMessage = "La longitud debe estar entre 4 y 28 caracteres.", MinimumLength = 4)]
        public string ComprobanteOIA { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Campo {0} es obligatorio.")]
        [StringLength(28, ErrorMessage = "La longitud debe estar entre 5 y 28 caracteres.", MinimumLength = 5)]
        [RegularExpression(@"^[^\s]+$", ErrorMessage = "Los espacios no están permitidos.")]
        public string Nickname { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Campo {0} es obligatorio.")]
        [RegularExpression(@"^[^\s]+$", ErrorMessage = "Los espacios no están permitidos.")]
        [StringLength(28, ErrorMessage = "La longitud debe estar entre 10 y 28 caracteres.", MinimumLength = 10)]
        public string Contrasena { get; set; } = string.Empty;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El Campo {0} es obligatorio.")]
        public int IdEstadoRepresentante { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El Campo {0} es obligatorio.")]
        public int IdOrganismo { get; set; }

        public virtual EstadoRepresentanteDTO? EstadoRepresentante { get; set; }

        public virtual OrganismoDTO? Organismo { get; set; }
    }
}
