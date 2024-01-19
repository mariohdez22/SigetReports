using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SigetSystem.Server.Models.Entidades.Padres
{
    public class DepartamentoInstalacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? IdDepartamentoInstalacion { get; set; }

        [Required]
        public string Departamentos { get; set; } = string.Empty;
    }
}
