using OutManager.Models;
using OutManager.Services;
using OutManager.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OutManager.ViewModels
{
    public class FuncionarioViewModel : BaseViewModel
    {
        #region Declaracao
        public ObservableCollection<Restaurant> RestauranteItems { get; }

        public INavigation _navigation;

        private RestauranteDataStore _restauranteDataStore;
        #endregion

        #region Commands
        public Command CarregarRestaurantsCommand { get; }
        public Command<Restaurant> ItemTapped { get; }
        public Command CadastrarCommand { get; }
        public Command HomeCommand { get; }
        #endregion

        public FuncionarioViewModel(INavigation navigation)
        {
            RestauranteItems = new ObservableCollection<Restaurant>();
            CadastrarCommand = new Command(ComandoCadastro);
            HomeCommand = new Command(ComandoHome);

            ItemTapped = new Command<Restaurant>(OnItemSelected);

            CarregarRestaurantsCommand = new Command(async () => await ComandoCarregar());
            _navigation = navigation;
            _restauranteDataStore = new RestauranteDataStore();
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }

        async Task ComandoCarregar()
        {
            IsBusy = true;

            try
            {
                RestauranteItems.Clear();
                var items = new ObservableCollection<Restaurant>(_restauranteDataStore.GetItems().Result);
                foreach (var item in items)
                {
                    RestauranteItems.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async void ComandoHome(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }

        private async void ComandoCadastro(object obj)
        {
            await _navigation.PushAsync(new CadastroRestaurantePage());
        }

        async void OnItemSelected(Restaurant item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }
    }
}
