using System.Collections.Generic;

namespace App.OrdenarFinanzas.Data.Models
{
    public class GastoFijo
    {
        public long IdGastoFijo { get; set; }
        public string DescripcionGastoFijo { get; set; }
        public decimal MontoEstimado { get; set; }
        public long IdPeriodicidad { get; set; }
        public virtual Periodicidad Periodicidad { get; set; }
        public long IdTipoGastoFijo { get; set; }
        public virtual TipoGastoFijo TipoGastoFijo { get; set; }

    }

    public class ResultGastosFijos
    {
        public object result { get; set; }
        public List<GastoFijo> value { get; set; }
    }


}
