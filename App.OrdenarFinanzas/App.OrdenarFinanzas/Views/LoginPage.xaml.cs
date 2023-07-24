using App.OrdenarFinanzas.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.OrdenarFinanzas.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            //this.BindingContext = new LoginViewModel();
        }
        //private void OnLoginButtonClicked(object sender, EventArgs e)
        //{
        //    string username = UsernameEntry.Text;
        //    string password = PasswordEntry.Text;

        //    // Aquí puedes agregar la lógica para verificar las credenciales ingresadas
        //    // y autenticar al usuario. Por ejemplo, puedes comparar con credenciales almacenadas en una base de datos o servicio.

        //    if (username == "usuarioEjemplo" && password == "contraseñaEjemplo")
        //    {
        //        // Usuario autenticado con éxito, muestra un mensaje de inicio de sesión exitoso.
        //        // Aquí puedes navegar a otra página después del inicio de sesión exitoso.
        //        // Navigation.PushAsync(new OtraPagina());
        //    }
        //    else
        //    {
        //        // Autenticación fallida, muestra un mensaje de error en el Label.
        //        ErrorMessageLabel.Text = "Usuario o contraseña incorrectos";
        //        ErrorMessageLabel.IsVisible = true;
        //    }
        //}
    }
}