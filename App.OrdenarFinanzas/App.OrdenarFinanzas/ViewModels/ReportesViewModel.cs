using App.OrdenarFinanzas.Data.Models;
using App.OrdenarFinanzas.Models;
using App.OrdenarFinanzas.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Text;
using Xamarin.CommunityToolkit.ObjectModel;
using Microcharts;
using SkiaSharp;
using Xamarin.Forms;
using App.OrdenarFinanzas.Extensions;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using System.Linq;
using App.OrdenarFinanzas.Data.Models.Dto;

namespace App.OrdenarFinanzas.ViewModels
{
    public class ReportesViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private Chart _barChart;
        public Chart BarChart
        {
            get { return _barChart; }
            set {  SetProperty(ref _barChart, value);}
        }

        private readonly IPagoService _pagoService;
        public ReportesViewModel(IPagoService pagoService)
        {
            Title = "Reporte Gastos";
            _pagoService = pagoService;
            GenerarReporteCommand = new Command(GenerarReporte);
        }

        public Command GenerarReporteCommand { get; set; }
        private async void GenerarReporte()
        {
            try
            {
                IsBusy = true;

                var listadopagos = await _pagoService.PostObtenerPagosAsync();
                List<DatosReporte> ListadoDatosReporte = new List<DatosReporte>();
                if (listadopagos != null)
                {
                    ListadoDatosReporte = listadopagos
                                        .GroupBy(a => a.IdTipoPago)
                                        .Select(DR => new DatosReporte
                                                            {
                                                                TipoGasto = DR.First().DescritipoPago,
                                                                idTipoGasto = DR.First().IdTipoPago,
                                                                Valor = (float)DR.Sum(c => c.Monto),
                                                            }).ToList();
                }

                string colorhex = string.Empty;
                List<ChartEntry> entries = new List<ChartEntry>();
                foreach (DatosReporte item in ListadoDatosReporte)
                {
                    colorhex = string.Empty;
                    switch (item.idTipoGasto)
                    {
                        case 1:
                            colorhex = ExtensionMethods.GetHexString(Xamarin.Forms.Color.Green);
                            break;
                            case 2:
                            colorhex = ExtensionMethods.GetHexString(Xamarin.Forms.Color.Blue);
                            break;
                        default:
                            colorhex = ExtensionMethods.GetHexString(Xamarin.Forms.Color.Red);
                            break;

                    }
                    entries.Add(new ChartEntry(item.Valor)
                    {
                        Label = item.TipoGasto,
                        ValueLabel = item.Valor.ToString(),
                        Color = SKColor.Parse(colorhex)
                    });
                }

                BarChart = new BarChart
                {
                    Entries = entries,
                    LabelTextSize = 30,
                    ValueLabelOrientation = Orientation.Horizontal,
                    AnimationProgress = 10,
                    LabelOrientation = Orientation.Horizontal
                };
                OnPropertyChanged(nameof(BarChart));
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
