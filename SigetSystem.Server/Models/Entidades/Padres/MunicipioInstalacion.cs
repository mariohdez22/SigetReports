using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SigetSystem.Server.Models.Entidades.Padres
{
    public class MunicipioInstalacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? IdMunicipioInstalacion { get; set; }

        [Required]
        public string Municipios { get; set; } = string.Empty;
    }
}
