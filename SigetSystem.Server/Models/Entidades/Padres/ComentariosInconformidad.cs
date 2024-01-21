using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SigetSystem.Server.Models.Entidades.Padres
{
    public class ComentariosInconformidad
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? IdComentarioInconformidad { get; set; }

        [Required]
        public string? ComentarioInconformidad { get; set; } = string.Empty;

        [Required]
        public DateTime FechaComentario { get; set; }
    }
}
