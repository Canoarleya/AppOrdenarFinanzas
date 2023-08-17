using App.OrdenarFinanzas.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.OrdenarFinanzas.Services
{
    public interface IPeriodicidadService
    {
        Task<List<Periodicidad>> PostObtenerPeriodicidadesAsync();
        //Task<Int64> PostCrearPeriodicidadAsync(Periodicidad periodicidad);
    }
}
