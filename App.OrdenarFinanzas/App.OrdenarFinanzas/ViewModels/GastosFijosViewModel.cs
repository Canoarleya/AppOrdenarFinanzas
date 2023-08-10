using App.OrdenarFinanzas.Resx;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App.OrdenarFinanzas.ViewModels
{
    public class GastosFijosViewModel : BaseViewModel
    {

        public Command LoginCommand { get; }
        public GastosFijosViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }
        private async void OnLoginClicked(object obj)
        {
            await Application.Current.MainPage.DisplayAlert(
                    "GastosFijosViewModel",
                    "Carga Pantalla Gastos Fijos",
                    AppResources.OkText);
        }
    }
}
