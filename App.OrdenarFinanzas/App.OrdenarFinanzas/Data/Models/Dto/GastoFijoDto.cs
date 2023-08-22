using System;
using System.Collections.Generic;
using System.Text;

namespace App.OrdenarFinanzas.Data.Models.Dto
{
    public class GastoFijoDto
    {
        public long IdGastoFijo { get; set; }

        public string DescripcionGastoFijo { get; set; }
        public decimal MontoEstimado { get; set; }

        public long IdPeriodicidad { get; set; }
        public string DescripcionPeriodicidad { get; set; }

        public long IdTipoGastoFijo { get; set; }
        public string DescripcionTpoGastoFijo { get; set; }
    }
    public class ResultGastosFijosDto
    {
        public object result { get; set; }
        public List<GastoFijoDto> value { get; set; }
    }
}
