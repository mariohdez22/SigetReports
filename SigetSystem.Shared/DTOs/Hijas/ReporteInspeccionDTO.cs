using SigetSystem.Shared.DTOs.Padres;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigetSystem.Shared.DTOs.Hijas
{
    public class ReporteInspeccionDTO
    {
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


        public int? IdOrganismo { get; set; }

        public int? IdRepresentante { get; set; }

        public int? IdDepartamentoInstalacion { get; set; }

        public int? IdMunicipioInstalacion { get; set; }

        public int? IdCodigoConformidad { get; set; }

        public int? IdComentariosInconformidad { get; set; }

        public int? IdCodigoSiget { get; set; }

        public int? IdRequisitoMenor { get; set; }

        public int? IdRequisitoMayor { get; set; }

        public int? IdEstadoReporte { get; set; }


        public virtual OrganismoDTO? Organismo { get; set; } //hija

        public virtual RepresentanteDTO? Representante { get; set; } //hija 

        public virtual DepartamentoInstalacionDTO? DepartamentoInstalacion { get; set; } //padre 

        public virtual MunicipioInstalacionDTO? MunicipioInstalacion { get; set; } //padre 

        public virtual CodigoConformidadDTO? CodigoConformidad { get; set; } //padre 

        public virtual ComentariosInconformidadDTO? ComentariosInconformidad { get; set; } //hija 

        public virtual CodigoSigetDTO? CodigoSiget { get; set; } //padre 

        public virtual RequisitoMenorDTO? RequisitoMenor { get; set; } //hija 

        public virtual RequisitoMayorDTO? RequisitoMayor { get; set; } //hija 

        public virtual EstadoReporteDTO? EstadoReporte { get; set; } //padre 
    }
}
