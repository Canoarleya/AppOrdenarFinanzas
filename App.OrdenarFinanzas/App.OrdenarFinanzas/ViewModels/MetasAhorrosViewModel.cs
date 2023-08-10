using App.OrdenarFinanzas.Resx;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App.OrdenarFinanzas.ViewModels
{
    public class MetasAhorrosViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        public MetasAhorrosViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }
        private async void OnLoginClicked(object obj)
        {
            await Application.Current.MainPage.DisplayAlert(
                    "MetasAhorrosViewModel",
                    "Carga Pantalla Metas Ahorros",
                    AppResources.OkText);
        }
    }
}
