using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App.OrdenarFinanzas.Data.API
{
    public interface ITipoGastoFijoApi
    {
        [Post("/TipoGasto/PostObtenerTipoGastos")]
        Task<HttpResponseMessage> PostObtenerTipoGastosAsync();

        [Post("/TipoGasto/PostCrearTipoGasto")]
        Task<HttpResponseMessage> PostCrearTipoGastoAsync();
    }
}
