using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OutManager.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddItem(T item);
        Task<bool> UpdateItem(T item);
        Task<bool> DeleteItem(int id);
        Task<T> GetItem(int id);
        Task<List<T>> GetItems(bool forceRefresh = false);
    }
}
