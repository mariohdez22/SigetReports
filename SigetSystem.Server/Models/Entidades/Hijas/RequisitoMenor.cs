using SigetSystem.Server.Models.Entidades.Padres;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace SigetSystem.Server.Models.Entidades.Hijas
{
    public class RequisitoMenor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMenores { get; set; }

        public string? CodigoRequisito { get; set; }

        public bool? Factibilidad { get; set; }  

        public bool? TotalFormularios { get; set; }

        public bool? CopiaDuiPropietario { get; set; }

        public bool? CopiaDuiRetiro { get; set; }

        public bool? CopiaTarjetaIvaEmpresa { get; set; }

        public bool? CopiaDuiElectricista { get; set; }

        public bool? CopiaCarnetElectricista { get; set; }

        public bool? CuadroDeCarga { get; set; }

        public bool? CroquisDeUbicacion { get; set; }

        public bool? EsquemaDeInstalacionElectrica { get; set; }

        public bool? ComprobanteDepago { get; set; }

        public string? ArchivoCopiaDuiPropietario {get; set;}

        public string? ArchivoCopiaDuiRetiro { get; set; }

        public string? ArchivoCopiaDuiElectricista { get; set; }

        public string? ArchivoCopiaCarnetElectricista { get; set; }

        public DateTime FechaRegistro { get; set; }

        [ForeignKey(nameof(Organismo))]
        public int? IdOrganismo { get; set; }

        [ForeignKey(nameof(Representante))]
        public int? IdRepresentante { get; set; }

        public virtual Organismo? Organismo { get; set; }

        public virtual Representante? Representante { get; set; }
    }
}
