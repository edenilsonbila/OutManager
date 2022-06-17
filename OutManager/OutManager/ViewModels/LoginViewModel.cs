using OutManager.Models;
using OutManager.Services;
using OutManager.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace OutManager.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        #region Declaration
        private UsuarioDataStore usuarioDataStore;
        public INavigation Navigation { get; set; }
        public Command LoginCommand { get; }
        private string usuario;
        private string senha;
        #endregion

        #region Implementation
        public string Senha
        {
            get => senha;
            set => SetProperty(ref senha, value);
        }

        public string Usuario
        {
            get => usuario;
            set => SetProperty(ref usuario, value);
        }
        #endregion

        public LoginViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            LoginCommand = new Command(OnLoginClicked);
            usuarioDataStore = new UsuarioDataStore();
        }

        private async void OnLoginClicked(object obj)
        {
            var usuario = Usuario;
            var senha = Senha;

            var users = await usuarioDataStore.GetItems();
            var usuarioLocalizado = users.FirstOrDefault(e => e.Login == usuario && e.Senha == senha);

            if (usuarioLocalizado != null)
            {
                Navigation.PushAsync(new FuncionarioPage());
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Ops", "Usuário não localizado", "OK");
            }
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
        }
    }
}
