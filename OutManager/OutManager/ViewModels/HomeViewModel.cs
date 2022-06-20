using OutManager.Models;
using OutManager.Services;
using OutManager.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace OutManager.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        #region Declaracao
        public ObservableCollection<Restaurant> RestauranteItems { get; }

        private RestauranteDataStore _restauranteDataStore;
        #endregion

        #region Commands
        public Command CarregarRestaurantsCommand { get; }
        public Command<Restaurant> ItemTapped { get; }
        #endregion

        public HomeViewModel()
        {
            RestauranteItems = new ObservableCollection<Restaurant>();

            ItemTapped = new Command<Restaurant>(OnItemSelected);

            CarregarRestaurantsCommand = new Command(async () => await ComandoCarregarProximos());
            _restauranteDataStore = new RestauranteDataStore();
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }

        async Task ComandoCarregarProximos()
        {
            IsBusy = true;

            //Obtem a localização atual
            var location = await Geolocation.GetLastKnownLocationAsync();

            try
            {
                RestauranteItems.Clear();
                //Busca restaurantes próximos
                var items = new ObservableCollection<Restaurant>(_restauranteDataStore.GetItems().Result);

                foreach (var item in items)
                {
                    //Valida a lotação
                    item.Lotacao = GetLotacao(item.Id.ToString());

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

        async void OnItemSelected(Restaurant item)
        {
            if (item == null)
                return;

            // This will push the RestaurantDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(InformarLotacao)}?{nameof(InformeLotacaoViewModel.ItemId)}={item.Id.ToString()}");
        }

        public string GetLotacao(string restaurantId)
        {
            //ultimas lotacoes informadas
            var lotacoes = _restauranteDataStore.GetLotacoesPorRestaurante(restaurantId).Result;

            if (lotacoes.Count == 0)
                return "VAZIO";

            //faz a media
            var ultimas = lotacoes.OrderByDescending(e => e.Horario).Take(10).Sum(e => e.IndiceLotacao);

            decimal lotacao = ultimas / lotacoes.Count;
            lotacao = Math.Round(lotacao);

            return lotacao < 4 ? "VAZIO" : lotacao > 7 ? "CHEIO" : "MÉDIO";


        }
    }
}
