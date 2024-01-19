using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SigetSystem.Server.Models.Entidades.Padres
{
    public class EstadoAcreditacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? IdEstadoAcreditacion { get; set; }

        [Required]
        public string Estados { get; set; } = string.Empty;
    }
}
