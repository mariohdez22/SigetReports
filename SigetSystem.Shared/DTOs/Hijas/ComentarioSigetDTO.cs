using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SigetSystem.Shared.DTOs.Padres;

namespace SigetSystem.Shared.DTOs.Hijas
{
    public class ComentarioSigetDTO
    {
        public int IdComentario { get; set; }

        public string MotivoComentario { get; set; } = string.Empty;

        public string Comentario { get; set; } = string.Empty;

        [Required]
        public int IdTipoConformidad { get; set; }      

        public int? IdReporteInspeccion { get; set; }   

        public int? IdRepresentante { get; set; }       

        public int? IdPersonal { get; set; }            

        public DateTime FechaComentario { get; set; }

        public virtual TipoConformidadDTO? TipoConformidad { get; set; }

        public virtual ReporteInspeccionDTO? ReporteInspeccion { get; set; }

        public virtual RepresentanteDTO? Representante { get; set; }

        public virtual PersonalDTO? Personal { get; set; }
    }
}
