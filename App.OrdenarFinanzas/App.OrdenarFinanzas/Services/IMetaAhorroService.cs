using App.OrdenarFinanzas.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.OrdenarFinanzas.Services
{
    public interface IMetaAhorroService
    {
        Task<List<MetaAhorro>> PostObtenerMetasAhorrosAsync();
        Task<Int64> PostCrearMetaAhorroAsync(MetaAhorro metaAhorro);
    }
}
