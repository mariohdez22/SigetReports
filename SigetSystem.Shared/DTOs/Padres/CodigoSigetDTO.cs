using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigetSystem.Shared.DTOs.Padres
{
    public class CodigoSigetDTO
    {
        public int IdCodigoSiget { get; set; }

        [Required]
        public string Codigos { get; set; } = string.Empty;
    }
}
