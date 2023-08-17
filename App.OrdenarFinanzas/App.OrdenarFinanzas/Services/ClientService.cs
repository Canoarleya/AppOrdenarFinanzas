using App.OrdenarFinanzas.Data.API;
using App.OrdenarFinanzas.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.OrdenarFinanzas.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientApi _clientApi;

        public ClientService(IClientApi clientApi)
        {
            _clientApi = clientApi;
        }

        public async Task<List<Cliente>> GetClients()
        {
            var clients = new List<Cliente>();

            try
            {
                var response = await _clientApi.GetClients();
                clients = response.ToList();
                return clients;
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }
            return clients;
        }
    }

}
