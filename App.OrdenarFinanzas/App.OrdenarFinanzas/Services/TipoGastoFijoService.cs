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
    public class TipoGastoFijoService : ITipoGastoFijoService
    {
        private readonly ITipoGastoFijoApi _tipoGastoFijoApi;

        public TipoGastoFijoService(ITipoGastoFijoApi tipoGastoFijoApi)
        {
            _tipoGastoFijoApi = tipoGastoFijoApi;
        }
        public async Task<List<TipoGastoFijo>> PostObtenerTipoGastosAsync()
        {
            var tiposGastosFijos = new List<TipoGastoFijo>();
            var ResulttiposGastosFijos = new ResultTipoGastoFijo();
            try
            {
                var response = await _tipoGastoFijoApi.PostObtenerTipoGastosAsync();

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    ResulttiposGastosFijos = JsonConvert.DeserializeObject<ResultTipoGastoFijo>(content);
                    if (ResulttiposGastosFijos.value != null)
                    {
                        tiposGastosFijos = ResulttiposGastosFijos.value.ToList();
                    }
                }
                return tiposGastosFijos;
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }
            return tiposGastosFijos;
        }
    }
}
