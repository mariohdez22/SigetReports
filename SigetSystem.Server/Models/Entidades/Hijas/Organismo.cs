using SigetSystem.Server.Models.Entidades.Padres;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SigetSystem.Server.Models.Entidades.Hijas
{
    public class Organismo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        [ForeignKey(nameof(EstadoAcreditacion))]
        public int IdEstadoAcreditacion { get; set; }

        [Required]
        [ForeignKey(nameof(Personal))]
        public int IdPersonal { get; set; }

        public virtual EstadoAcreditacion? EstadoAcreditacion { get; set; }

        public virtual Personal? Personal { get; set; }
    }
}
