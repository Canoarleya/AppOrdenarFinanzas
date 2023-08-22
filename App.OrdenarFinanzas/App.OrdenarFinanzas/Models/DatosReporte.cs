using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace App.OrdenarFinanzas.Models
{
    public class DatosReporte
    {
        public string TipoGasto { get; set; }
        public float Valor { get; set; }
        public string CodigoColorHex { get; set; }
        public long idTipoGasto { get; set; }
    }
}
