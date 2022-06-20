using OutManager.Models;
using OutManager.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;


namespace OutManager.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class InformeLotacaoViewModel : BaseViewModel
    {
        #region Declaração
        private string _lotacao;
        private string itemId;
        private RestauranteDataStore _restaurantDataStore;
        #endregion

        #region Implementacao

        public string Lotacao
        {
            get => _lotacao;
            set => SetProperty(ref _lotacao, value);
        }

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
            }
        }
        #endregion

        #region Commands
        public Command CancelCommand { get; }
        public Command SaveCommand { get; }
        #endregion

        public InformeLotacaoViewModel()
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
            if (string.IsNullOrEmpty(Lotacao))
            {
                await App.Current.MainPage.DisplayAlert("Alerta", "Favor informar a lotação do restaurante", "OK");
                return;
            }

            var restaurant = new RestauranteLotacao()
            {
                RestaurantId = ItemId,
                IndiceLotacao = int.Parse(Lotacao),
                Horario = DateTime.Now
            };

            await _restaurantDataStore.InformarLotacao(restaurant);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
