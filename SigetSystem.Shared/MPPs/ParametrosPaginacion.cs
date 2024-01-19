using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigetSystem.Shared.MPPs
{
    public class ParametrosPaginacion
    {
        public int NumeroPagina { get; set; }

        public int TamañoPagina { get; set; }

        public string? Orden { get; set; }

        public string? Buscar { get; set; }

        //---------------------------------------

        public int ID1 { get; set; }

        public int ID2 { get; set; }
    }
}
