using System.ComponentModel.DataAnnotations;

namespace SigetSystem.Server.Models.Entidades.Independientes
{
    public class JobReporte
    {
        [Key]
        public int IdJob { get; set; }

        [Required]
        public int IdReporteInspeccion { get; set; }

        [Required]
        public string TokenJob { get; set; } = null!;
    }
}
