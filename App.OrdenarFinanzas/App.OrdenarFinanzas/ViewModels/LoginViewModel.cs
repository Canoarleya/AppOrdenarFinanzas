using App.OrdenarFinanzas.Resx;
using App.OrdenarFinanzas.Services;
using App.OrdenarFinanzas.Views;
using Xamarin.Forms;

namespace App.OrdenarFinanzas.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {

        private readonly IAccountService _accountService;
        public LoginViewModel(IAccountService accountService)
        {
            _accountService = accountService;
            LoginCommand = new Command(OnLoginClicked);
        }

        private string _username;
        private string _password;
        //private bool _MostrarMensaje;
        //private string _MensajeBienvenida;
        //private Color _colorMensaje;
        public string UserName { get => _username; set => SetProperty(ref _username, value); }
        public string Password { get => _password; set => SetProperty(ref _password, value); }

        public Command LoginCommand { get; }

        //public Command LoginCommand { get; }



        /*
        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }
        */
        /*
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
        */
        /*
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
        }*/
        /*
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
        */
        /*
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
        */
        /*
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

        */
        private async void OnLoginClicked(object obj)
        {

            if (ValidarCamposLogin())
            {
                //if(!ValidarUsuarioContrasena())
                if (await _accountService.LoginAsync(UserName, Password))
                {
                    //MostrarMensaje = false;
                    //ColorMensaje = Color.Green;
                    //MensajeBienvenida = "Bienvenido " + UserName;
                    await Shell.Current.GoToAsync($"//{nameof(ListadoPagosPage)}");
                    //await Shell.Current.GoToAsync($"//{nameof(ClientsPage)}");
                    
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert(
                          AppResources.LoginPageInvalidLoginTitle,
                          AppResources.LoginPageInvalidLoginMessage,
                          AppResources.OkText);
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert(
                        AppResources.LoginPageInvalidTitleFaltanDatos,
                        AppResources.LoginPageInvalidFaltanDatos,
                        AppResources.OkText);
                /*
                MostrarMensaje = true;
                ColorMensaje = Color.Red;
                MensajeBienvenida = "Faltan datos necesarios para la autenticación";*/
            }
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one

        }

        private bool ValidarCamposLogin()
        {
            if (!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /*
        private bool ValidarUsuarioContrasena()
        {
            if (UserName == "usuario" && Password == "contrasena")
            {
                return true;
            }
            else
            {
                return false;
            }
        }*/
    }
}
