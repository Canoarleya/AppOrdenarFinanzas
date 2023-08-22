using App.OrdenarFinanzas.Data.Models;
using Refit;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace App.OrdenarFinanzas.Data.API
{
    public interface IPeriodicidadApi
    {
        [Post("/Periodicidad/PostObtenerPeriodicidades")]
        Task<HttpResponseMessage> PostObtenerPeriodicidadesAsync();

        [Post("/Periodicidad/PostCrearPeriodicidad")]
        Task<HttpResponseMessage> PostCrearPeriodicidadAsync();

    }
}
