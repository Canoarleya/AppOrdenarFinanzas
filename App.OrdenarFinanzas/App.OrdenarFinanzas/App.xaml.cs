﻿using App.OrdenarFinanzas.Services;
using App.OrdenarFinanzas.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.OrdenarFinanzas
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
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