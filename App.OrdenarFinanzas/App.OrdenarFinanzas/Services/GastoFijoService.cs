using App.OrdenarFinanzas.Data.API;
using App.OrdenarFinanzas.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.OrdenarFinanzas.Services
{
    public class GastoFijoService : IGastoFijoService
    {

        private readonly IGastoFijoApi _gastoFijoApi;

        public GastoFijoService(IGastoFijoApi gastoFijoApi)
        {
            _gastoFijoApi = gastoFijoApi;
        }

        public async Task<long> PostCrearGastoFijoAsync(GastoFijo gastoFijo)
        {
            try
            {
                var response = await _gastoFijoApi.PostCrearGastoFijoAsync(gastoFijo);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return 0;
                }
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }
            return 1;
        }

        public async Task<List<GastoFijo>> PostObtenerGastosFijosAsync()
        {
            var gastosFijos = new List<GastoFijo>();
            var ResultGastosFijos = new ResultGastosFijos();
            try
            {
                var response = await _gastoFijoApi.PostObtenerGastosFijosAsync();

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    ResultGastosFijos = JsonConvert.DeserializeObject<ResultGastosFijos>(content);
                    if (ResultGastosFijos.value != null)
                    {
                        gastosFijos = ResultGastosFijos.value.ToList();
                    }
                }

                //clients = response.ToList();
                return gastosFijos;
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }
            return gastosFijos;
        }


        

    }
}
