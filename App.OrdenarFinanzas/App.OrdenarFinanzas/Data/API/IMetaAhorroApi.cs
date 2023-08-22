using App.OrdenarFinanzas.Data.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App.OrdenarFinanzas.Data.API
{
    public interface IMetaAhorroApi
    {
        [Post("/MetaAhorro/PostCrearMetaAhorro")]
        Task<HttpResponseMessage> PostCrearMetaAhorroAsync(MetaAhorro metaAhorro);


        [Post("/MetaAhorro/PostObtenerMetasAhorros")]
        Task<HttpResponseMessage> PostObtenerMetasAhorrosAsync();
    }
}
