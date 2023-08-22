using App.OrdenarFinanzas.Data.Models;
using App.OrdenarFinanzas.Resx;
using App.OrdenarFinanzas.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace App.OrdenarFinanzas.ViewModels
{
    public class MetasAhorrosViewModel : BaseViewModel
    {
        public Command GuardarCommand { get; }
        public ICommand AppearingCommand { get; set; }
        private readonly IPeriodicidadService _periodicidadService;
        private readonly IMetaAhorroService _metaAhorroService;
        public string DescripcionMetaAhorro { get => _descripcionMetaAhorro; set => SetProperty(ref _descripcionMetaAhorro, value); }
        public decimal MontoMetaAhorro { get => _montoMetaAhorro; set => SetProperty(ref _montoMetaAhorro, value); }
        public decimal MontoInicialMetaAhorro { get => _montoInicialMetaAhorro; set => SetProperty(ref _montoInicialMetaAhorro, value); }
        public decimal MontoPeriodicoMetaAhorro { get => _montoPeriodicoMetaAhorro; set => SetProperty(ref _montoPeriodicoMetaAhorro, value); }
        public ObservableRangeCollection<Periodicidad> Periodicidades { get; set; } = new ObservableRangeCollection<Periodicidad>();

        private Periodicidad _periodicidad;
        private string _descripcionMetaAhorro;
        private decimal _montoMetaAhorro;
        private decimal _montoInicialMetaAhorro;
        private decimal _montoPeriodicoMetaAhorro;
        public Periodicidad PeriodicidadGastoFijo
        {
            get { return _periodicidad; }
            set
            {
                _periodicidad = value;
                OnPropertyChanged(nameof(PeriodicidadGastoFijo));
            }
        }
        public MetasAhorrosViewModel(IPeriodicidadService periodicidadService,
            IMetaAhorroService metaAhorroService)
        {
            AppearingCommand = new AsyncCommand(async () => await OnAppearingAsync());
            GuardarCommand = new Command(OnLoginClicked);
            Title = "Periodicidades";
            _periodicidadService = periodicidadService;
            _metaAhorroService = metaAhorroService;
        }

        /*
        public MetasAhorrosViewModel()
        {
            GuardarCommand = new Command(OnLoginClicked);
        }*/

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

        private async void OnLoginClicked(object obj)
        {
            try
            {
                IsBusy = true;
                MetaAhorro metaAhorro = new MetaAhorro();
                metaAhorro.DescripcionMetaAhorro = DescripcionMetaAhorro;
                metaAhorro.MontoObjetivo = MontoMetaAhorro;
                metaAhorro.BaseInicial = MontoInicialMetaAhorro;
                metaAhorro.MontoPeriodico = MontoPeriodicoMetaAhorro;
                metaAhorro.IdPeriodicidad = PeriodicidadGastoFijo.IdPeriodicidad;
                metaAhorro.FechaInicio = DateTime.Now;
                metaAhorro.FechaProyectadaFin = DateTime.Now;

                long periodicidades = await _metaAhorroService.PostCrearMetaAhorroAsync(metaAhorro);

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
