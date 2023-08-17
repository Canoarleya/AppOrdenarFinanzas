using App.OrdenarFinanzas.Data.Models;
using App.OrdenarFinanzas.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace App.OrdenarFinanzas.ViewModels
{
    public class GastosFijosViewModel : BaseViewModel
    {

        //private readonly IClientService _clientService;

        //public GastosFijosViewModel(IClientService clientService)
        //{
        //    AppearingCommand = new AsyncCommand(async () => await OnAppearingAsync());
        //    Title = "Clientes";
        //    _clientService = clientService;
        //}

        //public ObservableRangeCollection<Cliente> Clients { get; set; } = new ObservableRangeCollection<Cliente>();

        //public ICommand AppearingCommand { get; set; }

        //private async Task OnAppearingAsync()
        //{
        //    await LoadData();
        //}

        //private async Task LoadData()
        //{
        //    try
        //    {
        //        IsBusy = true;
        //        var clients = await _clientService.GetClients();
        //        if (clients != null)
        //        {
        //            Clients.ReplaceRange(clients);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        var message = ex.Message;
        //    }
        //    finally
        //    {
        //        IsBusy = false;
        //    }
        //}

        public Command LoginCommand { get; }

        private readonly IPeriodicidadService _periodicidadService;
        private readonly ITipoGastoFijoService _tipoGastoFijoService;
        private string _idPeriodicidad;
        private string _idTipoGasto;
        private string _monto;
        private string _descripcion;

        public string DescripcionGastoFijo { get => _descripcion; set => SetProperty(ref _descripcion, value); }
        public string IdPeriodicidadGastoFijo { get => _idPeriodicidad; set => SetProperty(ref _idPeriodicidad, value); }
        public string IdTipoGasto { get => _idTipoGasto; set => SetProperty(ref _idTipoGasto, value); }
        public string Monto { get => _monto; set => SetProperty(ref _monto, value); }

        public GastosFijosViewModel(IPeriodicidadService periodicidadService, ITipoGastoFijoService tipoGastoFijoService)
        {
            AppearingCommand = new AsyncCommand(async () => await OnAppearingAsync());
            LoginCommand = new Command(OnLoginClicked);
            Title = "Periodicidades";
            _periodicidadService = periodicidadService;
            _tipoGastoFijoService = tipoGastoFijoService;
        }

        public ICommand AppearingCommand { get; set; }

        public ObservableRangeCollection<Periodicidad> Periodicidades { get; set; } = new ObservableRangeCollection<Periodicidad>();
        public ObservableRangeCollection<TipoGastoFijo> TiposGastostFijos { get; set; } = new ObservableRangeCollection<TipoGastoFijo>();

        private async Task OnAppearingAsync()
        {
            await LoadData();
        }


        private async Task LoadData()
        {
            try
            {
                IsBusy = true;
                var periodicidades = await _periodicidadService.PostObtenerPeriodicidadesAsync();
                if (periodicidades != null)
                {
                    Periodicidades.ReplaceRange(periodicidades);
                }

                var tiposGastosFijos = await _tipoGastoFijoService.PostObtenerTipoGastosAsync();
                if (tiposGastosFijos != null)
                {
                    TiposGastostFijos.ReplaceRange(tiposGastosFijos);
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

        ///*
        //public GastosFijosViewModel()
        //{
        //    LoginCommand = new Command(OnLoginClicked);
        //}*/

        private async void OnLoginClicked(object obj)
        {
            await Application.Current.MainPage.DisplayAlert(
                    "GastosFijosViewModel",
                    "Carga Pantalla Gastos Fijos",
                    IdPeriodicidadGastoFijo);
        }
    }
}
