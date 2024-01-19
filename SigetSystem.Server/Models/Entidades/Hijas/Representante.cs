using Microsoft.IdentityModel.Tokens;
using SigetSystem.Server.Models.Entidades.Padres;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SigetSystem.Server.Models.Entidades.Hijas
{
    public class Representante
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRepresentante { get; set; }

        [Required]
        public string Nombres { get; set; } = string.Empty;

        [Required]
        public string Celular { get; set;} = string.Empty;

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
        [ForeignKey(nameof(EstadoRepresentante))]
        public int IdEstadoRepresentante { get; set; }

        [Required]
        [ForeignKey(nameof(Organismo))]
        public int IdOrganismo { get; set; }

        public virtual EstadoRepresentante? EstadoRepresentante { get; set; }

        public virtual Organismo? Organismo { get; set; }
    }
}
