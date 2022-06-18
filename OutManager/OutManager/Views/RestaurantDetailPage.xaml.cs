using OutManager.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace OutManager.Views
{
    public partial class RestaurantDetailPage : ContentPage
    {
        public RestaurantDetailPage()
        {
            InitializeComponent();
            BindingContext = new RestaurantDetailViewModel();
        }
    }
}