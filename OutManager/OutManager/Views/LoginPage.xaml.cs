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
        public LoginPage()
        {
            InitializeComponent();

            this.BindingContext = new LoginViewModel(Navigation);

            //valida se já esta logado
            if (Application.Current.Properties.ContainsKey("usersession"))
            {
                OpenPage(new ItemsPage());
            }

        }

        public async Task OpenPage(Page page)
        {
            await Navigation.PushAsync(page);
        }
    }
}