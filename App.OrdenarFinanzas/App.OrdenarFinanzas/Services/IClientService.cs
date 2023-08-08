using App.OrdenarFinanzas.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace App.OrdenarFinanzas.Services
{
    public interface IClientService
    {
        Task<List<Cliente>> GetClients();
    }

}
