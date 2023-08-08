using App.OrdenarFinanzas.Data.Models;
using App.OrdenarFinanzas.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;

namespace App.OrdenarFinanzas.ViewModels
{
    public class ClientsViewModel : BaseViewModel
    {
        private readonly IClientService _clientService;

        public ClientsViewModel(IClientService clientService)
        {
            AppearingCommand = new AsyncCommand(async () => await OnAppearingAsync());
            Title = "Clientes";
            _clientService = clientService;
        }

        public ObservableRangeCollection<Cliente> Clients { get; set; } = new ObservableRangeCollection<Cliente>();

        public ICommand AppearingCommand { get; set; }

        private async Task OnAppearingAsync()
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            try
            {
                IsBusy = true;
                var clients = await _clientService.GetClients();
                if (clients != null)
                {
                    Clients.ReplaceRange(clients);
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }
            finally
            {
                IsBusy = false;
            }
        }
    }

}
