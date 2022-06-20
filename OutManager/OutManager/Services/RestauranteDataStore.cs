using OutManager.Config;
using OutManager.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OutManager.Services
{
    public class RestauranteDataStore : IDataStore<Restaurant>
    {
        private SQLite.SQLiteConnection connection;
        private SQLite.SQLiteConnection connectionLotacao;

        public RestauranteDataStore()
        {
            IDbPathConfig dbPathConfig = DependencyService.Get<IDbPathConfig>();
            var caminho = System.IO.Path.Combine(dbPathConfig.Path, "outmanager.db");
            connection = new SQLite.SQLiteConnection(caminho);
            connection.CreateTable<Restaurant>();
            connectionLotacao = new SQLite.SQLiteConnection(caminho);
            connectionLotacao.CreateTable<RestauranteLotacao>();
        }

        public async Task<bool> AddItem(Restaurant item)
        {
            var rowsInserted = connection.Insert(item);
            if (rowsInserted > 0)
                return await Task.FromResult(true);
            else
                return await Task.FromResult(false);
        }

        public Task<bool> DeleteItem(int id)
        {
            var itemToDelete = connection.Table<Restaurant>().FirstOrDefault(e => e.Id == id);
            if(itemToDelete == null)
                return Task.FromResult(true);

            var rowsDeleted = connection.Delete(itemToDelete);
            if (rowsDeleted > 0)
                return Task.FromResult(true);
            else
                return Task.FromResult(false);
        }

        public Task<Restaurant> GetItem(int id)
        {
            return Task.FromResult(connection.Table<Restaurant>().FirstOrDefault(e => e.Id == id));
        }

        public Task<List<Restaurant>> GetItems(bool forceRefresh = false)
        {
            return Task.FromResult(connection.Table<Restaurant>().ToList());
        }

        public Task<bool> UpdateItem(Restaurant item)
        {
            var updatedRows = connection.Update(item);
            if (updatedRows > 0)
                return Task.FromResult(true);
            else
                return Task.FromResult(false);
        }

        public Task<bool> InformarLotacao(RestauranteLotacao item)
        {
            var updatedRows = connectionLotacao.Insert(item);
            if (updatedRows > 0)
                return Task.FromResult(true);
            else
                return Task.FromResult(false);
        }

        public Task<List<RestauranteLotacao>> GetLotacoesPorRestaurante(string id)
        {
            return Task.FromResult(connectionLotacao.Table<RestauranteLotacao>().Where(e => e.RestaurantId == id).ToList());
        }
    }
}
