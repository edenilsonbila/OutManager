using OutManager.Services;
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
    public partial class LoginPage : ContentPage
    {
        private UsuarioDataStore usuarioDataStore;
        public LoginPage()
        {
            InitializeComponent();

            this.BindingContext = new LoginViewModel(Navigation);
            usuarioDataStore = new UsuarioDataStore();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            NavigationPage.SetHasBackButton(this, false);
            //valida se já esta logado
            if (Application.Current.Properties.ContainsKey("usersession"))
            {
                var userId = int.Parse(Application.Current.Properties["usersession"].ToString());
                var user = usuarioDataStore.GetItem(userId).Result;
                Navigation.PushAsync(new FuncionarioPage(user));
            }
        }


    }
}