using App.OrdenarFinanzas.Data.Models.Dto;
using App.OrdenarFinanzas.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;

namespace App.OrdenarFinanzas.ViewModels
{
    public class ListadoPagosViewModel : BaseViewModel
    {
        private readonly IPagoService _pagoService;

        public ListadoPagosViewModel(IPagoService pagoService)
        {
            AppearingCommand = new AsyncCommand(async () => await OnAppearingAsync());
            Title = "Clientes";
            _pagoService = pagoService;

        }
        public ObservableRangeCollection<PagosDto> ListadoPagos { get; set; } = new ObservableRangeCollection<PagosDto>();

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
                var listadopagos = await _pagoService.PostObtenerPagosAsync();
                if (listadopagos != null)
                {
                    ListadoPagos.ReplaceRange(listadopagos);
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
