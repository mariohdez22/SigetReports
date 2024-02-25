using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SigetSystem.Shared.MPPs
{
    public class ReporteFiltro
    {

        //padre
        public int? IdDepartamentoInstalacion { get; set; } = 0;

        //padre
        public int? IdMunicipioInstalacion { get; set; } = 0;

        //padre
        public int? IdCodigoConformidad { get; set; } = 0;

        //padre
        public int? IdCodigoSiget { get; set; } = 0;

        //padre
        public int? IdEstadoReporte { get; set; } = 0;

        //metodo para resetear el filtro
        public void ReiniciarFiltro()
        {
            IdDepartamentoInstalacion = 0;
            IdMunicipioInstalacion = 0;
            IdCodigoConformidad = 0;
            IdCodigoSiget = 0;
            IdEstadoReporte = 0;
        }

    }
}
