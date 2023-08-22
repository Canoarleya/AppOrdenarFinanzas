using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App.OrdenarFinanzas.Data.Models
{
    public class MetaAhorro
    {
        public long IdMetaAhorro { get; set; }
        public string DescripcionMetaAhorro { get; set; }
        public decimal MontoObjetivo { get; set; }
        public decimal BaseInicial { get; set; }
        public DateTime FechaInicio { get; set; }
        public decimal MontoPeriodico { get; set; }
        public long IdPeriodicidad { get; set; }
        public virtual Periodicidad Periodicidad { get; set; }
        public DateTime FechaProyectadaFin { get; set; }
    }

    public class ResultMetaAhorro
    {
        public object result { get; set; }
        public List<MetaAhorro> value { get; set; }
    }
}
