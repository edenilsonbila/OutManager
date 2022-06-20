using OutManager.ViewModels;
using OutManager.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace OutManager
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(RestaurantDetailPage), typeof(RestaurantDetailPage));
            Routing.RegisterRoute(nameof(InformarLotacao), typeof(InformarLotacao));
            Routing.RegisterRoute(nameof(CadastroRestaurantePage), typeof(CadastroRestaurantePage));
            Application.Current.Properties.Clear();
        }

        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            Application.Current.Properties.Clear();
            await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        }

    }
}
