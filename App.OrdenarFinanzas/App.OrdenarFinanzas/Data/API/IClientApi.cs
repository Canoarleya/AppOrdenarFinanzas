using App.OrdenarFinanzas.Data.Models;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.OrdenarFinanzas.Data.API
{
    public interface IClientApi
    {
        [Get("/Clients")]
        Task<List<Cliente>> GetClients();
    }

}
