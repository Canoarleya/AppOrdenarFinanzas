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
    public class MetaAhorroService : IMetaAhorroService
    {
        private readonly IMetaAhorroApi _metaAhorroApi;


        public MetaAhorroService(IMetaAhorroApi metaAhorroApi)
        {
            _metaAhorroApi = metaAhorroApi;
        }
        public async Task<long> PostCrearMetaAhorroAsync(MetaAhorro metaAhorro)
        {
            try
            {
                var response = await _metaAhorroApi.PostCrearMetaAhorroAsync(metaAhorro);
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

        public async Task<List<MetaAhorro>> PostObtenerMetasAhorrosAsync()
        {
            var metasAhorro = new List<MetaAhorro>();
            var ResultMetaAhorro = new ResultMetaAhorro();
            try
            {
                var response = await _metaAhorroApi.PostObtenerMetasAhorrosAsync();

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    ResultMetaAhorro = JsonConvert.DeserializeObject<ResultMetaAhorro>(content);
                    if (ResultMetaAhorro.value != null)
                    {
                        metasAhorro = ResultMetaAhorro.value.ToList();
                    }
                }
                return metasAhorro;
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }
            return metasAhorro;
        }
    }
}
