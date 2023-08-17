using System.Collections.Generic;

namespace App.OrdenarFinanzas.Data.Models
{
    public class Periodicidad
    {
        public long IdPeriodicidad { get; set; }
        public string DescripcionPeriodicidad { get; set; }

    }

    public class ResultPeriodicidad
    {
        public object result { get; set; }
        public List<Periodicidad> value { get; set; }
    }


}
