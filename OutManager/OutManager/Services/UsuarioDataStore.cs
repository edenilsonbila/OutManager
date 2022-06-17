using OutManager.Config;
using OutManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OutManager.Services
{
    public class UsuarioDataStore : IDataStore<Usuario>
    {
        private SQLite.SQLiteConnection connection;

        public UsuarioDataStore()
        {
            IDbPathConfig dbPathConfig = DependencyService.Get<IDbPathConfig>();
            var caminho = System.IO.Path.Combine(dbPathConfig.Path, "outmanager.db");
            connection = new SQLite.SQLiteConnection(caminho);
            connection.CreateTable<Usuario>();

            //valida se existe usuario master e insere
            if(!connection.Table<Usuario>().Any(e => e.Login == "master" && e.Senha == "master"))
            {
                AddItem(new Usuario() { 
                    Login = "master",
                    Senha = "master",
                    Nome = "master"
                }).Wait();
            }
        }

        public async Task<bool> AddItem(Usuario item)
        {
            var rowsInserted = connection.Insert(item);
            if (rowsInserted > 0)
                return await Task.FromResult(true);
            else
                return await Task.FromResult(false);
        }

        public Task<bool> DeleteItem(int id)
        {
            var rowsDeleted = connection.Delete(connection.Table<Usuario>().FirstOrDefault(e => e.Id == id));
            if (rowsDeleted > 0)
                return Task.FromResult(true);
            else
                return Task.FromResult(false);
        }

        public Task<Usuario> GetItem(int id)
        {
            return Task.FromResult(connection.Table<Usuario>().FirstOrDefault(e => e.Id == id));
        }

        public Task<List<Usuario>> GetItems(bool forceRefresh = false)
        {
            return Task.FromResult(connection.Table<Usuario>().ToList());
        }

        public Task<bool> UpdateItem(Usuario item)
        {
            var updatedRows = connection.Update(item);
            if (updatedRows > 0)
                return Task.FromResult(true);
            else
                return Task.FromResult(false);
        }
    }
}
