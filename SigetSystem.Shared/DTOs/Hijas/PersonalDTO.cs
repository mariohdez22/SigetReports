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

        [Required(ErrorMessage = "El Campo {0} es obligatorio.")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Por favor ingrese solo letras y espacios.")]
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
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El Campo {0} es obligatorio.")]
        [StringLength(28, ErrorMessage = "La longitud debe estar entre 5 y 28 caracteres.", MinimumLength = 5)]
        [RegularExpression(@"^[^\s]+$", ErrorMessage = "Los espacios no están permitidos.")]
        public string Nickname { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Campo {0} es obligatorio.")]
        [RegularExpression(@"^[^\s]+$", ErrorMessage = "Los espacios no están permitidos.")]
        [StringLength(28, ErrorMessage = "La longitud debe estar entre 10 y 28 caracteres.", MinimumLength = 10)]
        public string Contrasena { get; set; } = string.Empty;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El Campo Rango Personal es obligatorio.")]
        public int IdRangoPersonal { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El Campo Estado Personal es obligatorio.")]
        public int IdEstadoPersonal { get; set; }

        public virtual RangoPersonalDTO? RangoPersonal { get; set; }

        public virtual EstadoPersonalDTO? EstadoPersonal { get; set; }
    }
}
