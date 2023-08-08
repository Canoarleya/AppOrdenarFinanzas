using System.Threading.Tasks;

namespace App.OrdenarFinanzas.Services
{
    public interface IAccountService
    {
        Task<bool> LoginAsync(string userName, string password);
    }

}
