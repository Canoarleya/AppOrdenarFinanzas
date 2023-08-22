//using App.OrdenarFinanzas.Services;
using App.OrdenarFinanzas.Views;
using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.OrdenarFinanzas
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            var culture = new CultureInfo("es-CO");
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
            Startup.Initialize();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
