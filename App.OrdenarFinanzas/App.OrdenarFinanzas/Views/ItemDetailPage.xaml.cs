using App.OrdenarFinanzas.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace App.OrdenarFinanzas.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}