using App.OrdenarFinanzas.Data.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App.OrdenarFinanzas.Data.API
{
    public interface IPagoApi
    {
        [Post("/Pago/PostCrearPago")]
        Task<HttpResponseMessage> PostCrearPagoAsync(Pago pago);


        [Post("/Pago/PostObtenerPagos")]
        Task<HttpResponseMessage> PostObtenerPagosAsync();
    }
}
