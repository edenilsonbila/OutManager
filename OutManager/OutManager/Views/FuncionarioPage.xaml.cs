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
        FuncionarioViewModel _viewModel;

        public FuncionarioPage(Usuario user)
        {
            InitializeComponent();

            BindingContext = _viewModel = new FuncionarioViewModel(Navigation);
            //userLogado.Text = user.Nome.ToTitleCase();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            //Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }

        private void ContentPage_Focused(object sender, FocusEventArgs e)
        {
            //valida se já esta logado
            if (!Application.Current.Properties.ContainsKey("usersession"))
            {
                Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            }
        }
    }
}