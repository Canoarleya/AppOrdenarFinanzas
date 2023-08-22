using App.OrdenarFinanzas.Data.Models;
using App.OrdenarFinanzas.Data.Models.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.OrdenarFinanzas.Services
{
    public interface IGastoFijoService
    {
        Task<List<GastoFijo>> PostObtenerGastosFijosAsync();
        Task<List<GastoFijoDto>> PostConsultarGastosFijosPorTipoAsync(long IdTipoGasto);
        Task<Int64> PostCrearGastoFijoAsync(GastoFijo gastoFijo);
    }
}
