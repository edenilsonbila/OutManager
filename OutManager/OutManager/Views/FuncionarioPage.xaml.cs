using OutManager.Helpers;
using OutManager.Models;
using OutManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OutManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FuncionarioPage : ContentPage
    {
        public FuncionarioPage(Usuario user)
        {
            InitializeComponent();

            BindingContext = new FuncionarioViewModel();
            userLogado.Text = user.Nome.ToTitleCase();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }
    }
}