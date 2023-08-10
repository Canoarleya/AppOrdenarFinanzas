using App.OrdenarFinanzas.Resx;
using App.OrdenarFinanzas.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App.OrdenarFinanzas.ViewModels
{
    public class GastosViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        public GastosViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }
        private async void OnLoginClicked(object obj)
        {
            await Application.Current.MainPage.DisplayAlert(
                    "GastosViewModel",
                    "Carga Pantalla Gastos",
                    AppResources.OkText);
        }

    }
}
