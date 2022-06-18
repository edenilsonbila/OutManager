using OutManager.Models;
using OutManager.Services;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OutManager.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class RestaurantDetailViewModel : BaseViewModel
    {
        public Command DeleteCommand { get; }

        private RestauranteDataStore _restauranteDataStore;
        public RestaurantDetailViewModel()
        {
            DeleteCommand = new Command(ComandoDelete);
            _restauranteDataStore = new RestauranteDataStore();
        }
        private string itemId;
        private string nome;
        private string endereco;
        public int Id { get; set; }

        public string Nome
        {
            get => nome;
            set => SetProperty(ref nome, value);
        }

        public string Endereco
        {
            get => endereco;
            set => SetProperty(ref endereco, value);
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
                LoadItemId(value);
            }
        }

        public async void ComandoDelete()
        {
            try
            {
                var item = await _restauranteDataStore.DeleteItem(int.Parse(itemId));
                await App.Current.MainPage.DisplayAlert("Info", "Excluido com sucesso!", "OK");
                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to Load Item" + ex.Message);
            }
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await _restauranteDataStore.GetItem(int.Parse(itemId));
                Id = item.Id;
                Nome = item.Nome;
                Endereco = item.Endereco;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
