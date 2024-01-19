using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigetSystem.Shared.DTOs.Padres
{
    public class DepartamentoInstalacionDTO
    {
        public int IdDepartamentoInstalacion { get; set; }

        [Required]
        public string Departamentos { get; set; } = string.Empty;
    }
}
