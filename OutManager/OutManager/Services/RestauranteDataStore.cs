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

        public RestauranteDataStore()
        {
            IDbPathConfig dbPathConfig = DependencyService.Get<IDbPathConfig>();
            var caminho = System.IO.Path.Combine(dbPathConfig.Path, "outmanager.db");
            connection = new SQLite.SQLiteConnection(caminho);
            connection.CreateTable<Restaurant>();
        }

        Task<bool> IDataStore<Restaurant>.AddItem(Restaurant item)
        {
            var rowsInserted = connection.Insert(item);
            if (rowsInserted > 0)
                return Task.FromResult(true);
            else
                return Task.FromResult(false);
        }

        Task<bool> IDataStore<Restaurant>.DeleteItem(int id)
        {
            var rowsDeleted = connection.Delete(connection.Table<Restaurant>().FirstOrDefault(e => e.Id == id));
            if (rowsDeleted > 0)
                return Task.FromResult(true);
            else
                return Task.FromResult(false);
        }

        Task<Restaurant> IDataStore<Restaurant>.GetItem(int id)
        {
            return Task.FromResult(connection.Table<Restaurant>().FirstOrDefault(e => e.Id == id));
        }

        Task<List<Restaurant>> IDataStore<Restaurant>.GetItems(bool forceRefresh)
        {
            return Task.FromResult(connection.Table<Restaurant>().ToList());
        }

        Task<bool> IDataStore<Restaurant>.UpdateItem(Restaurant item)
        {
            var updatedRows = connection.Update(item);
            if (updatedRows > 0)
                return Task.FromResult(true);
            else
                return Task.FromResult(false);
        }
    }
}
