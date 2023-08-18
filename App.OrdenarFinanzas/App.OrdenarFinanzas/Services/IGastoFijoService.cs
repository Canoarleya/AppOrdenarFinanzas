using App.OrdenarFinanzas.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.OrdenarFinanzas.Services
{
    public interface IGastoFijoService
    {
        Task<List<GastoFijo>> PostObtenerGastosFijosAsync();
        Task<Int64> PostCrearGastoFijoAsync(GastoFijo gastoFijo);
    }
}
