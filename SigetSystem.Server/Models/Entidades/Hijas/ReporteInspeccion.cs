using SigetSystem.Server.Models.Entidades.Padres;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SigetSystem.Server.Models.Entidades.Hijas
{
    public class ReporteInspeccion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdReporteInspeccion { get; set; }

        public string? CodigoInspeccion { get; set; }

        public string? NombreSolicitante { get; set; }

        public string? CodigoDepartamentalInstElectrica { get; set; }

        public string? CodigoMunicipioInstalacion { get; set; }

        public string? ColoniaInstalacion { get; set; }

        public string? DireccionInstalacion { get; set; }

        public DateTime FechaDepagoSolicitante { get; set; }

        public DateTime FechaPrimeraInspeccion { get; set; }

        public DateTime FechaUltimaInspeccion { get; set; }

        public DateTime FechaEntregaConformidad { get; set; }

        public string? EspecificacionesCertificado { get; set; }

        public decimal MontoSolicitante { get; set; }

        public string? NumeroCreditoFiscal { get; set; }


        [ForeignKey(nameof(Organismo))]
        public int? IdOrganismo { get; set; }

        [ForeignKey(nameof(Representante))]
        public int? IdRepresentante { get; set; }

        [ForeignKey(nameof(DepartamentoInstalacion))]
        public int? IdDepartamentoInstalacion { get; set; }

        [ForeignKey(nameof(MunicipioInstalacion))]
        public int? IdMunicipioInstalacion { get; set; }

        [ForeignKey(nameof(CodigoConformidad))]
        public int? IdCodigoConformidad { get; set; }

        [ForeignKey(nameof(ComentariosInconformidad))]
        public int? IdComentariosInconformidad { get; set; }

        [ForeignKey(nameof(CodigoSiget))]
        public int? IdCodigoSiget { get; set; }

        [ForeignKey(nameof(RequisitoMenor))]
        public int? IdRequisitoMenor { get; set; }

        [ForeignKey(nameof(RequisitoMayor))]
        public int? IdRequisitoMayor { get; set; }

        [ForeignKey(nameof(EstadoReporte))]
        public int? IdEstadoReporte { get; set; }


        public virtual Organismo? Organismo { get; set; }

        public virtual Representante? Representante { get; set; }

        public virtual DepartamentoInstalacion? DepartamentoInstalacion { get; set; }

        public virtual MunicipioInstalacion? MunicipioInstalacion { get; set; }

        public virtual CodigoConformidad? CodigoConformidad { get; set; }

        public virtual ComentariosInconformidad? ComentariosInconformidad { get; set; }

        public virtual CodigoSiget? CodigoSiget { get; set; }

        public virtual RequisitoMenor? RequisitoMenor { get; set; }

        public virtual RequisitoMayor? RequisitoMayor { get; set; }

        public virtual EstadoReporte? EstadoReporte { get; set; }
    }
}
