using App.OrdenarFinanzas.Data.API;
using App.OrdenarFinanzas.Data.Models;
using App.OrdenarFinanzas.Data.Models.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.OrdenarFinanzas.Services
{
    public class PagoService : IPagoService
    {
        private readonly IPagoApi _pagoApi;

        public PagoService(IPagoApi pagoApi)
        {
            _pagoApi = pagoApi;
        }

        public async Task<long> PostCrearPagoAsync(Pago pago)
        {
            try
            {
                var response = await _pagoApi.PostCrearPagoAsync(pago);
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

        public async Task<List<PagosDto>> PostObtenerPagosAsync()
        {
            var listaPagos = new List<PagosDto>();
            var ResultPagosDto = new ResultPagosDto();
            try
            {
                var response = await _pagoApi.PostObtenerPagosAsync();

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    ResultPagosDto = JsonConvert.DeserializeObject<ResultPagosDto>(content);
                    if (ResultPagosDto.value != null)
                    {
                        listaPagos = ResultPagosDto.value.ToList();
                    }
                }
                return listaPagos;
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }
            return listaPagos;
        }
    }
}
