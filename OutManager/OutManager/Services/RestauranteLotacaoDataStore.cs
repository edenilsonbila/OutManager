using OutManager.Config;
using OutManager.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OutManager.Services
{
    public class RestauranteLotacaoeLotacaoDataStore : IDataStore<RestauranteLotacao>
    {
        private SQLite.SQLiteConnection connection;

        public RestauranteLotacaoeLotacaoDataStore()
        {
            IDbPathConfig dbPathConfig = DependencyService.Get<IDbPathConfig>();
            var caminho = System.IO.Path.Combine(dbPathConfig.Path, "outmanager.db");
            connection = new SQLite.SQLiteConnection(caminho);
            connection.CreateTable<RestauranteLotacao>();
        }

        public async Task<bool> AddItem(RestauranteLotacao item)
        {
            var rowsInserted = connection.Insert(item);
            if (rowsInserted > 0)
                return await Task.FromResult(true);
            else
                return await Task.FromResult(false);
        }

        public Task<bool> DeleteItem(int id)
        {
            throw new NotImplementedException();
        }

        public Task<RestauranteLotacao> GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<RestauranteLotacao>> GetItems(bool forceRefresh = false)
        {
            return Task.FromResult(connection.Table<RestauranteLotacao>().ToList());
        }

        public Task<bool> UpdateItem(RestauranteLotacao item)
        {
            throw new NotImplementedException();
        }
    }
}
