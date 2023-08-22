using System;
using System.Collections.Generic;
using System.Text;

namespace App.OrdenarFinanzas.Data.Models.Dto
{
    public class PagosDto
    {
        public long IdPago { get; set; }
        public string DescripcionPago { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public long IdTipoPago { get; set; }
        public string DescritipoPago { get; set; }
        public long IdSubtipo { get; set; }
        public string DescriSubtipo { get; set; }

    }

    public class ResultPagosDto
    {
        public object result { get; set; }
        public List<PagosDto> value { get; set; }
    }
}
