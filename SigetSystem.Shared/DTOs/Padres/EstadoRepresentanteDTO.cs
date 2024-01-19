﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigetSystem.Shared.DTOs.Padres
{
    public class EstadoRepresentanteDTO
    {
        public int IdEstadoRepresentante { get; set; }

        [Required]
        public string Estados { get; set; } = string.Empty;
    }
}
