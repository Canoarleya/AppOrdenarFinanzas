using App.OrdenarFinanzas.Data.API;
using App.OrdenarFinanzas.Data.Models;
using App.OrdenarFinanzas.Data.Models.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.OrdenarFinanzas.Services
{
    public class PeriodicidadService : IPeriodicidadService
    {
        private readonly IPeriodicidadApi _periodicidadApi;

        public PeriodicidadService(IPeriodicidadApi periodicidadApi)
        {
            _periodicidadApi = periodicidadApi;
        }
        /*
        public PeriodicidadService()
        {
            
        }*/

        public async Task<List<Periodicidad>> PostObtenerPeriodicidadesAsync()
        {
            var periodicidades = new List<Periodicidad>();
            var Resultperiodicidades = new ResultPeriodicidad();
            try
            {
                var response = await _periodicidadApi.PostObtenerPeriodicidadesAsync();

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    Resultperiodicidades = JsonConvert.DeserializeObject<ResultPeriodicidad>(content);
                    if (Resultperiodicidades.value != null)
                    {
                        periodicidades = Resultperiodicidades.value.ToList();
                    }
                }

                //clients = response.ToList();
                return periodicidades;
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }
            return periodicidades;
        }
        /*
        public async Task<Int64> PostCrearPeriodicidadAsync(Periodicidad periodicidad)
        {
            try
            {
                var response = await _periodicidadApi.CrearPeriodicidadAsync(periodicidad);
                //clients = response.ToList();
                return 0;
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }
            return 1;

        }*/

    }
}
