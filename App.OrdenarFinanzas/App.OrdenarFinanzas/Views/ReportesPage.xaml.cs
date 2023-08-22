using Microcharts;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.OrdenarFinanzas.ViewModels;
using System.Drawing;
using Xamarin.Essentials;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.OrdenarFinanzas.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ReportesPage : ContentPage
	{
        private ReportesViewModel _viewModel;
        private bool estaIniciado = false;
        public ReportesPage ()
		{
			InitializeComponent ();
        }
    }
}