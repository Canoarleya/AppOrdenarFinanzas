using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App.OrdenarFinanzas.Data.Models
{
    public class TipoPago
    {
        public long IdTipoPago { get; set; }
        public string DescripcionTipoPago { get; set; }

    }

    public class ResultTipoPago
    {
        public object result { get; set; }
        public List<TipoPago> value { get; set; }
    }
}
