using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OutManager.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
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