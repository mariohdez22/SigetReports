using SigetSystem.Server.Models.Entidades.Padres;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace SigetSystem.Server.Models.Entidades.Hijas
{
    public class Personal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        [ForeignKey(nameof(RangoPersonal))]
        public int IdRangoPersonal { get; set; }

        [Required]
        [ForeignKey(nameof(EstadoPersonal))]
        public int IdEstadoPersonal { get; set; }

        public virtual RangoPersonal? RangoPersonal { get; set; }

        public virtual EstadoPersonal? EstadoPersonal { get; set;}
    }
}
