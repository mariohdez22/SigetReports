using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigetSystem.Shared.DTOs.Padres
{
    public class MunicipioInstalacionDTO
    {
        public int IdMunicipioInstalacion { get; set; }

        [Required]
        public string Municipios { get; set; } = string.Empty;
    }
}
