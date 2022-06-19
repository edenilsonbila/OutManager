using OutManager.Models;
using OutManager.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace OutManager.ViewModels
{
    public class CadastroRestauranteViewModel : BaseViewModel
    {
        #region Declaração
        private string _nome;
        private string _endereco;
        private RestauranteDataStore _restaurantDataStore;
        #endregion

        #region Implementacao
        public string Nome
        {
            get => _nome;
            set => SetProperty(ref _nome, value);
        }

        public string Endereco
        {
            get => _endereco;
            set => SetProperty(ref _endereco, value);
        }
        #endregion

        #region Commands
        public Command CancelCommand { get; }
        public Command SaveCommand { get; }
        #endregion

        public CadastroRestauranteViewModel()
        {
            CancelCommand = new Command(OnCancel);
            SaveCommand = new Command(OnSave);
            _restaurantDataStore = new RestauranteDataStore();
        }

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            if (string.IsNullOrEmpty(Nome))
            {
                await App.Current.MainPage.DisplayAlert("Alerta", "Favor informar o nome do restaurante", "OK");
                return;
            }
            if (string.IsNullOrEmpty(Endereco))
            {
                await App.Current.MainPage.DisplayAlert("Alerta", "Favor informar o endereco do restaurante", "OK");
                return;
            }

            var restaurant = new Restaurant()
            {
                Nome = Nome,
                Endereco = Endereco
            };

            await _restaurantDataStore.AddItem(restaurant);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
