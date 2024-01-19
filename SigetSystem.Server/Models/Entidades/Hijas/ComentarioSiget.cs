using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SigetSystem.Server.Models.Entidades.Padres;

namespace SigetSystem.Server.Models.Entidades.Hijas
{
    public class ComentarioSiget
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdComentario { get; set; }

        public string MotivoComentario { get; set; } = string.Empty;

        public string Comentario { get; set; } = string.Empty;

        [Required]
        [ForeignKey(nameof(TipoConformidad))]
        public int IdTipoConformidad { get; set; }

        [ForeignKey(nameof(ReporteInspeccion))]
        public int? IdReporteInspeccion { get; set; }

        [ForeignKey(nameof(Representante))]
        public int? IdRepresentante { get; set; }

        [ForeignKey(nameof(Personal))]
        public int? IdPersonal { get; set; }

        public DateTime FechaComentario { get; set; }

        public virtual TipoConformidad? TipoConformidad { get; set; }

        public virtual ReporteInspeccion? ReporteInspeccion { get; set; }

        public virtual Representante? Representante { get; set; }

        public virtual Personal? Personal { get; set; }
    }
}
