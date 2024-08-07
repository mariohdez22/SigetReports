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

        [Required(ErrorMessage = "El Campo {0} es obligatorio.")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Por favor ingrese solo letras y espacios.")]
        [StringLength(28, ErrorMessage = "La longitud debe estar entre 4 y 28 caracteres.", MinimumLength = 4)]
        public string NombreOIA { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Campo {0} es obligatorio.")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Por favor ingrese solo letras y espacios.")]
        [StringLength(28, ErrorMessage = "La longitud debe estar entre 4 y 28 caracteres.", MinimumLength = 4)]
        public string Responsable { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Campo {0} es obligatorio.")]
        [RegularExpression(@"^[^\s]+$", ErrorMessage = "Los espacios no están permitidos.")]
        [StringLength(28, ErrorMessage = "La longitud debe estar entre 5 y 28 caracteres.", MinimumLength = 5)]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Campo {0} es obligatorio.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingrese solo números.")]
        [StringLength(8, ErrorMessage = "La longitud debe estar entre 8 y 8 caracteres.", MinimumLength = 8)]
        public string Telefono { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Campo {0} es obligatorio.")]
        [StringLength(10, ErrorMessage = "La longitud debe estar entre 6 y 10 caracteres.", MinimumLength = 6)]
        public string CodigoUnico { get; set; } = string.Empty;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El Campo {0} es obligatorio.")]
        public int IdEstadoAcreditacion { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El Campo {0} es obligatorio.")]
        public int IdPersonal { get; set; }

        public virtual EstadoAcreditacionDTO? EstadoAcreditacion { get; set; }

        public virtual PersonalDTO? Personal { get; set; }
    }
}
