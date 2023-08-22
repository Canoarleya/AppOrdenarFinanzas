using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App.OrdenarFinanzas.Data.API
{
    public interface ITipoPagoApi
    {
        [Post("/TipoPago/PostObtenerTiposPago")]
        Task<HttpResponseMessage> PostObtenerTiposPagoAsync();

        [Post("/TipoPago/PostCrearTipoPago")]
        Task<HttpResponseMessage> PostCrearTipoPagoAsync();
    }
}
