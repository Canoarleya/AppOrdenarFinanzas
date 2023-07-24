using App.OrdenarFinanzas.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App.OrdenarFinanzas.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        private string _username;
        private string _password;
        private bool _MostrarMensaje;
        private string _MensajeBienvenida;
        private Color _colorMensaje;

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }


        public Color ColorMensaje
        {
            get { return _colorMensaje; }
            set
            {
                if (_colorMensaje != value)
                {
                    _colorMensaje = value;
                    OnPropertyChanged(nameof(ColorMensaje));
                }
            }
        }

        public string Username
        {
            get { return _username; }
            set
            {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanged(nameof(Username));
                }
            }
        }

        public string MensajeBienvenida
        {
            get { return _MensajeBienvenida; }
            set
            {
                if (_MensajeBienvenida != value)
                {
                    _MensajeBienvenida = value;
                    OnPropertyChanged(nameof(MensajeBienvenida));
                }
            }
        }

        public bool MostrarMensaje
        {
            get { return _MostrarMensaje; }
            set
            {
                if (_MostrarMensaje != value)
                {
                    _MostrarMensaje = value;
                    OnPropertyChanged(nameof(MostrarMensaje));
                }
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }


        private async void OnLoginClicked(object obj)
        {

            if (ValidarCamposLogin())
            {

                if(!ValidarUsuarioContrasena())
                {
                    MostrarMensaje = true;
                    ColorMensaje = Color.Red;
                    MensajeBienvenida = "Usuario o Clave invalida";
                }
                else
                {
                    MostrarMensaje = false;
                    ColorMensaje = Color.Green;
                    MensajeBienvenida = "Bienvenido " + Username;
                    await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
                }    
            }
            else
            {
                MostrarMensaje = true;
                ColorMensaje = Color.Red;
                MensajeBienvenida = "Faltan datos necesarios para la autenticación";
            }
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            
        }

        private bool ValidarCamposLogin()
        { 
            if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password)) 
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidarUsuarioContrasena()
        {
            if (Username == "usuario" && Password == "contrasena")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
