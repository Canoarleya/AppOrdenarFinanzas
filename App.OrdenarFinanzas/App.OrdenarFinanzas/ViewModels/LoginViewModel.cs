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
        public string UserName { get => _username; set => SetProperty(ref _username, value); }
        public string Password { get => _password; set => SetProperty(ref _password, value); }

        public Command LoginCommand { get; }

        private async void OnLoginClicked(object obj)
        {

            if (ValidarCamposLogin())
            {
                if (await _accountService.LoginAsync(UserName, Password))
                {
                    await Shell.Current.GoToAsync($"//{nameof(ListadoPagosPage)}");
                    
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
            }
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
    }
}
