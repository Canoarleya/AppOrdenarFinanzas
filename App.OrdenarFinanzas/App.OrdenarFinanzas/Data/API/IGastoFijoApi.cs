using App.OrdenarFinanzas.Data.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App.OrdenarFinanzas.Data.API
{
    public interface IGastoFijoApi
    {
        [Post("/GastoFijo/PostCrearGastoFijo")]
        Task<HttpResponseMessage> PostCrearGastoFijoAsync(GastoFijo gastoFijo);


        [Post("/GastoFijo/PostObtenerGastosFijos")]
        Task<HttpResponseMessage> PostObtenerGastosFijosAsync();
    }
}
