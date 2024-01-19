using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SigetSystem.Server.Models.Entidades.Independientes
{
    public class Bitacora
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdBitacora {  get; set; }

        [Required]
        public string TipoAccion {  get; set; } = string.Empty;

        [Required]
        public string NombrePersonal { get; set; } = string.Empty;

        [Required]
        public DateTime FechaAccion { get; set; }
    }
}
