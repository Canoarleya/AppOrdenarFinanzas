using App.OrdenarFinanzas.Data.Models;
using App.OrdenarFinanzas.Data.Models.Dto;
using App.OrdenarFinanzas.Resx;
using App.OrdenarFinanzas.Services;
using App.OrdenarFinanzas.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace App.OrdenarFinanzas.ViewModels
{
    public class PagosViewModel : BaseViewModel
    {
        public Command GuardarCommand { get; }
        public ICommand AppearingCommand { get; set; }

        private readonly ITipoPagoService _tipoPagoService;
        private readonly ITipoGastoFijoService _tipoGastoFijoService;
        private readonly IMetaAhorroService _metaAhorroService;
        private readonly IGastoFijoService _gastoFijoService;
        private readonly IPagoService _pagoService;

        private bool _pickerGastoFijoEsVisible;
        public bool PickerGastoFijoEsVisible { get => _pickerGastoFijoEsVisible; set => SetProperty(ref _pickerGastoFijoEsVisible, value); }
        public ObservableRangeCollection<TipoPago> TiposPago { get; set; } = new ObservableRangeCollection<TipoPago>();
        public ObservableRangeCollection<Subtipos> ListSubtiposPago { get; set; } = new ObservableRangeCollection<Subtipos>();
        public ObservableRangeCollection<Subtipos> ListaSubtipoGastosFijos { get; set; } = new ObservableRangeCollection<Subtipos>();
        public string DescripcionPago { get => _descripcionPago; set => SetProperty(ref _descripcionPago, value); }
        private string _descripcionPago;

        public decimal Monto { get => _monto; set => SetProperty(ref _monto, value); }
        private decimal _monto;

        public DateTime FechaPago { get => _fechaPago; set => SetProperty(ref _fechaPago, value); }
        private DateTime _fechaPago = DateTime.Now;

        
        private TipoPago _tipoPago;
        public TipoPago TipoPago
        {
            get { return _tipoPago; }
            set
            {
                _tipoPago = value;
                OnPropertyChanged(nameof(_tipoPago));
                CargarSubTipos(_tipoPago.IdTipoPago);
            }
        }

        private Subtipos _subtipos;
        public Subtipos Subtipos
        {
            get { return _subtipos; }
            set
            {
                _subtipos = value;
                OnPropertyChanged(nameof(_subtipos));
                CargarGastosFijo(_subtipos.IdSubtipo);
            }
        }

        private GastoFijo _gastoFijo;
        public GastoFijo GastoFijo
        {
            get { return _gastoFijo; }
            set
            {
                _gastoFijo = value;
                OnPropertyChanged(nameof(_gastoFijo));
            }
        }



        public PagosViewModel(ITipoPagoService tipoPagoService,
            ITipoGastoFijoService tipoGastoFijoService,
            IMetaAhorroService metaAhorroService,
            IGastoFijoService gastoFijoService, 
            IPagoService pagoService)
        {
            AppearingCommand = new AsyncCommand(async () => await OnAppearingAsync());
            GuardarCommand = new Command(OnGuardarClicked);
            Title = "Periodicidades";
            _tipoPagoService = tipoPagoService;
            _tipoGastoFijoService = tipoGastoFijoService;
            _metaAhorroService = metaAhorroService;
            _gastoFijoService = gastoFijoService;
            _pagoService = pagoService;

        }
        private async void OnGuardarClicked(object obj)
        {
            try
            {
                IsBusy = true;
                Pago pago = new Pago();
                pago.DescripcionPago = DescripcionPago;
                pago.Fecha = FechaPago;
                pago.Monto = Monto;
                pago.IdTipoPago = TipoPago.IdTipoPago;
                pago.IdSubtipo = 1;//PeriodicidadGastoFijo.IdPeriodicidad;

                long pagos = await _pagoService.PostCrearPagoAsync(pago);

                if (pagos == 0)
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
        private async Task OnAppearingAsync()
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            try
            {
                IsBusy = true;
                var tiposPago = await _tipoPagoService.PostObtenerTiposPagoAsync();
                if (tiposPago != null)
                {
                    TiposPago.ReplaceRange(tiposPago);
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

        private async Task CargarSubTipos(long TipoPago)
        {
            try
            {
                IsBusy = true;

                switch (TipoPago)
                {
                    case 2:
                        var tipoGastoFijo = await _tipoGastoFijoService.PostObtenerTipoGastosAsync();
                        if (tipoGastoFijo != null)
                        {
                            List<Subtipos> ListaSubtiposPago = tipoGastoFijo.Select(a => new Subtipos()
                            {
                                IdSubtipo = a.IdTipoGastoFijo,
                                DescripcionSubtipo = a.DescripcionTipoGastoFijo
                            }).ToList();

                            if (ListaSubtiposPago != null)
                            {
                                ListSubtiposPago.ReplaceRange(ListaSubtiposPago);
                                _pickerGastoFijoEsVisible = true;
                            }
                            else
                            {
                                _pickerGastoFijoEsVisible = false;
                            }
                        }
                        else
                        {
                            _pickerGastoFijoEsVisible = false;
                        }
                        break;
                    case 1:
                        var metaAhorros = await _metaAhorroService.PostObtenerMetasAhorrosAsync();
                        if (metaAhorros != null)
                        {
                            List<Subtipos> ListaSubtiposPago = metaAhorros.Select(a => new Subtipos()
                            {
                                IdSubtipo = a.IdMetaAhorro,
                                DescripcionSubtipo = a.DescripcionMetaAhorro
                            }).ToList();

                            if (ListaSubtiposPago != null)
                            {
                                ListSubtiposPago.ReplaceRange(ListaSubtiposPago);
                                _pickerGastoFijoEsVisible = true;
                            }
                            else
                            {
                                _pickerGastoFijoEsVisible = false;
                            }
                        }
                        else
                        {
                            _pickerGastoFijoEsVisible = false;
                        }
                        break;
                    default:
                        _pickerGastoFijoEsVisible = false;
                        break;
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
            //OnPropertyChanged(nameof(_subtipos));
        }

        private async Task CargarGastosFijo(long idTipoGastoFijo)
        {
            try
            {
                IsBusy = true;
                var GastoFijo = await _gastoFijoService.PostConsultarGastosFijosPorTipoAsync(idTipoGastoFijo);
                if (GastoFijo != null)
                {
                    List<Subtipos> ListaGastosFijos = GastoFijo.Select(a => new Subtipos()
                    {
                        IdSubtipo = a.IdGastoFijo,
                        DescripcionSubtipo = a.DescripcionGastoFijo
                    }).ToList();

                    if (ListaGastosFijos != null)
                    {
                        ListaSubtipoGastosFijos.ReplaceRange(ListaGastosFijos);
                        _pickerGastoFijoEsVisible = true;
                    }
                    else
                    {
                        _pickerGastoFijoEsVisible = false;
                    }
                }
                else
                {
                    _pickerGastoFijoEsVisible = false;
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
           //OnPropertyChanged(nameof(_gastoFijo));
        }

    }
}
