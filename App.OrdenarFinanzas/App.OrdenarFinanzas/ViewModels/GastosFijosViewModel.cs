using App.OrdenarFinanzas.Data.Models;
using App.OrdenarFinanzas.Resx;
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
        private readonly IGastoFijoService _gastoFijoService;

        private string _idPeriodicidad;
        private string _idTipoGasto;
        private string _monto;
        private string _descripcion;

        public string DescripcionGastoFijo { get => _descripcion; set => SetProperty(ref _descripcion, value); }
        public string Monto { get => _monto; set => SetProperty(ref _monto, value); }


        private TipoGastoFijo _tipoGastoFijo;
        public TipoGastoFijo TipoGastoFijo
        {
            get { return _tipoGastoFijo; }
            set
            {
                _tipoGastoFijo = value;
                OnPropertyChanged(nameof(_tipoGastoFijo));
            }
        }

        private Periodicidad _periodicidad;
        public Periodicidad PeriodicidadGastoFijo
        { get { return _periodicidad; }
            set
            {
                _periodicidad = value;
                OnPropertyChanged(nameof(PeriodicidadGastoFijo));
            }
        }

        public GastosFijosViewModel(IPeriodicidadService periodicidadService, 
            ITipoGastoFijoService tipoGastoFijoService,
            IGastoFijoService gastoFijoService)
        {
            AppearingCommand = new AsyncCommand(async () => await OnAppearingAsync());
            LoginCommand = new Command(OnLoginClicked);
            Title = "Periodicidades";
            _periodicidadService = periodicidadService;
            _tipoGastoFijoService = tipoGastoFijoService;
            _gastoFijoService = gastoFijoService;
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
            try
            {
                IsBusy = true;
                GastoFijo gastoFijo = new GastoFijo();
                gastoFijo.IdPeriodicidad = PeriodicidadGastoFijo.IdPeriodicidad;
                gastoFijo.IdTipoGastoFijo = TipoGastoFijo.IdTipoGastoFijo;
                gastoFijo.MontoEstimado = Convert.ToDecimal(Monto);
                gastoFijo.DescripcionGastoFijo = DescripcionGastoFijo;

                long periodicidades = await _gastoFijoService.PostCrearGastoFijoAsync(gastoFijo);
                if (periodicidades == 0)
                {
                    await Application.Current.MainPage.DisplayAlert(
                   "Crear Gastos Fijos",
                   "Gasto Fijo Registrado con éxito",
                   AppResources.OkText);
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert(
                     "Crear Gastos Fijos",
                     "Fallo el proceso de registro.",
                     AppResources.OkText);
                }

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert(
                 "Crear Gastos Fijos",
                 ex.Message,
                 AppResources.OkText);

                var message = ex.Message;
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
