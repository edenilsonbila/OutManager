using OutManager.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OutManager.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();

            BindingContext = new HomeViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var existingPages = Navigation.NavigationStack;
            foreach (var page in existingPages)
            {
                if(page != null)
                Navigation.RemovePage(page);
            }
        }
    }
}