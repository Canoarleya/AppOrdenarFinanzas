using App.OrdenarFinanzas.Data.Models.Dto;
using App.OrdenarFinanzas.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.OrdenarFinanzas.Services
{
    public interface ITipoPagoService
    {
        Task<List<TipoPago>> PostObtenerTiposPagoAsync();
        Task<Int64> PostCrearTipoPagoAsync(TipoPago tipoPago);
    }
}
