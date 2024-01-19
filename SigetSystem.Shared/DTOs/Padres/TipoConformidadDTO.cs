using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigetSystem.Shared.DTOs.Padres
{
    public class TipoConformidadDTO
    {
        public int IdTipoConformidad { get; set; }

        [Required]
        public string Tipos { get; set; } = string.Empty;
    }
}
