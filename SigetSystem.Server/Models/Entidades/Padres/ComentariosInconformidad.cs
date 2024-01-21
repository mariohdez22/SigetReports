using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SigetSystem.Server.Models.Entidades.Padres
{
    public class ComentariosInconformidad
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdComentarioInconformidad { get; set; }

        public string? ComentarioInconformidad { get; set; }

        [Required]
        public DateTime FechaComentario { get; set; }
    }
}
