using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App.OrdenarFinanzas.Data.Models
{
    public class Pago
    {
        public long IdPago { get; set; }
        public string DescripcionPago { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public long IdTipoPago { get; set; }
        public virtual TipoPago TipoPago { get; set; }
        public long IdSubtipo { get; set; }
    }
}
