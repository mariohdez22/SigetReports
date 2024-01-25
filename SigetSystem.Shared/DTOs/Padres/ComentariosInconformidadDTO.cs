using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigetSystem.Shared.DTOs.Padres
{
    public class ComentariosInconformidadDTO
    {
        public int IdComentarioInconformidad { get; set; }

        public string? ComentarioInconformidad { get; set; } = string.Empty;

        public DateTime FechaComentario { get; set; }
    }
}
