using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigetSystem.Shared.DTOs.Hijas
{
    public class RequisitoMenorDTO
    {
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

        public string? ArchivoCopiaDuiPropietario { get; set; }

        public string? ArchivoCopiaDuiRetiro { get; set; }

        public string? ArchivoCopiaDuiElectricista { get; set; }

        public string? ArchivoCopiaCarnetElectricista { get; set; }

        public DateTime FechaRegistro { get; set; }

        public int? IdOrganismo { get; set; }

        public int? IdRepresentante { get; set; }

        public virtual OrganismoDTO? Organismo { get; set; }

        public virtual RepresentanteDTO? Representante { get; set; }
    }
}
