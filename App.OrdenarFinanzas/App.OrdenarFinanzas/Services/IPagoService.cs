using App.OrdenarFinanzas.Data.Models;
using App.OrdenarFinanzas.Data.Models.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.OrdenarFinanzas.Services
{
    public interface IPagoService
    {
        Task<List<PagosDto>> PostObtenerPagosAsync();
        Task<Int64> PostCrearPagoAsync(Pago pago);
    }
}
