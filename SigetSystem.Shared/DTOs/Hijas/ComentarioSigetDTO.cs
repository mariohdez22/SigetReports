using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SigetSystem.Shared.DTOs.Padres;
using System.Diagnostics.CodeAnalysis;

namespace SigetSystem.Shared.DTOs.Hijas
{
    public class ComentarioSigetDTO
    {
        public int IdComentario { get; set; }

        [Required(ErrorMessage = "El Campo {0} es obligatorio.")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Por favor ingrese solo letras y espacios.")]
        [StringLength(50, ErrorMessage = "La longitud debe estar entre 10 y 50 caracteres.", MinimumLength = 10)]
        public string MotivoComentario { get; set; } = string.Empty; // ya

        [Required(ErrorMessage = "El Campo {0} es obligatorio.")]
        [StringLength(700, ErrorMessage = "La longitud debe estar entre 15 y 700 caracteres.", MinimumLength = 15)]
        public string Comentario { get; set; } = string.Empty; // ya

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El Campo Tipo Conformidad es obligatorio.")]
        public int IdTipoConformidad { get; set; }

        [AllowNull]
        public int? IdReporteInspeccion { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El Campo Representante es obligatorio.")]
        public int IdRepresentante { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El Campo Personal es obligatorio.")]
        public int IdPersonal { get; set; }            


        public DateTime FechaComentario { get; set; }

        public virtual TipoConformidadDTO? TipoConformidad { get; set; } 

        public virtual ReporteInspeccionDTO? ReporteInspeccion { get; set; } 

        public virtual RepresentanteDTO? Representante { get; set; } 

        public virtual PersonalDTO? Personal { get; set; } 
    }
}
