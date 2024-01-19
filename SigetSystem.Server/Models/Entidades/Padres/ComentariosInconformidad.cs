using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SigetSystem.Server.Models.Entidades.Padres
{
    public class ComentariosInconformidad
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? IdCodigoInconformidad { get; set; }

        [Required]
        public string Codigos { get; set; } = string.Empty;
    }
}
