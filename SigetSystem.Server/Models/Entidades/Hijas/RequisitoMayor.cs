using System.Numerics;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SigetSystem.Server.Models.Entidades.Hijas
{
    public class RequisitoMayor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMayores { get; set; }

        public string? CodigoRequisito { get; set; }

        public bool? Factibilidad { get; set; }

        public bool? TotalFormularios { get; set; }

        public bool? CopiaDuiPropietario { get; set; }

        public bool? CopiaDuiRetiro { get; set; }

        public bool? CopiaDuiElectricista { get; set; }

        public bool? CopiaCarnetElectricista { get; set; }

        public bool? PlanosDualesDeDiseñoMinimo { get; set; }

        public bool? PlanosDualesDeConstruccion { get; set; }

        public bool? CopiaFacturaDeMateriales { get; set; }

        public bool? CopiaGarantiaDeTransformador { get; set; }

        public bool? ComprobanteDePago { get; set; }

        public bool? MemoriaDecalculo { get; set; }

        public bool? AutocadCD { get; set; }

        public string? ArchivoCopiaDuiPropietario { get; set; }

        public string? ArchivoCopiaDuiRetiro { get; set; }

        public string? ArchivoCopiaDuiElectricista { get; set; }

        public string? ArchivoCopiaCarnetElectricista { get; set; }

        public string? ArchivoPlanosDualesDeDiseñoMinimo { get; set; }

        public string? ArchivoPlanosDualesDeConstruccion { get; set; }

        public string? ArchivoCopiaFacturaDeMateriales { get; set; }

        public string? ArchivoCopiaGarantiaDeTransformador { get; set; }

        public DateTime FechaRegistro { get; set; }

        [ForeignKey(nameof(Organismo))]
        public int? IdOrganismo { get; set; }

        [ForeignKey(nameof(Representante))]
        public int? IdRepresentante { get; set; }

        public virtual Organismo? Organismo { get; set; }

        public virtual Representante? Representante { get; set; }
    }
}
