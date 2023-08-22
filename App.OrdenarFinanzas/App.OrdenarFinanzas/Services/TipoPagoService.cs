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
    public class TipoPagoService : ITipoPagoService
    {
        private readonly ITipoPagoApi _tipoPagoApi;

        public TipoPagoService(ITipoPagoApi tipoPagoApi)
        {
            _tipoPagoApi = tipoPagoApi;
        }
        public Task<long> PostCrearTipoPagoAsync(TipoPago tipoPago)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TipoPago>> PostObtenerTiposPagoAsync()
        {
            var tiposPago = new List<TipoPago>();
            var ResultTipoPago = new ResultTipoPago();
            try
            {
                var response = await _tipoPagoApi.PostObtenerTiposPagoAsync();

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    ResultTipoPago = JsonConvert.DeserializeObject<ResultTipoPago>(content);
                    if (ResultTipoPago.value != null)
                    {
                        tiposPago = ResultTipoPago.value.ToList();
                    }
                }

                //clients = response.ToList();
                return tiposPago;
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }
            return tiposPago;
        }
    }
}
