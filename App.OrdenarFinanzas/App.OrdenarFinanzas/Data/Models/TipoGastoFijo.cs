using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App.OrdenarFinanzas.Data.Models
{
    public class TipoGastoFijo
    {
        public long IdTipoGastoFijo { get; set; }

        public string DescripcionTipoGastoFijo { get; set; }

        public long UserId { get; set; }

        //public virtual User? User { get; set; }

    }


    public class ResultTipoGastoFijo
    {
        public object result { get; set; }
        public List<TipoGastoFijo> value { get; set; }
    }
}
