using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using XamarinFormsApp.Core;
using XamarinFormsApp.Core.Models;
using XamarinFormsApp.Repository.Definitions;
using XamarinFormsApp.Utilities.Extensions;

namespace XamarinFormsApp.Repository.Implementations
{
    public class SQLiteRepository : ISQLiteRepository
    {
        private readonly SQLiteAsyncConnection sqLiteAsyncConnection;

        public SQLiteRepository()
        {
            sqLiteAsyncConnection = GetAsyncConnection();
            Type[] types = new Type[] { typeof(Item) };
            sqLiteAsyncConnection.CreateTablesAsync(CreateFlags.None, types).Wait();
        }

        async Task<int> ISQLiteRepository.DeleteAsync<T>(T item)
        {
            return await sqLiteAsyncConnection.DeleteAsync<T>(item);
        }

        async Task<List<T>> ISQLiteRepository.GetAsync<T>()
        {
            var items = await sqLiteAsyncConnection.QueryAsync<T>($"SELECT * FROM [{typeof(T).Name}]");

            if (items.IsNullOrEmpty())
            {
                return new List<T>();
            }

            return items;
        }

        async Task<T> ISQLiteRepository.GetAsync<T>(int id)
        {
            return await sqLiteAsyncConnection.FindAsync<T>(x => x.Id == id);
        }

        async Task<int> ISQLiteRepository.SaveAsync<T>(T item)
        {
            if (item.Id != 0)
            {
                return await sqLiteAsyncConnection.UpdateAsync(item);
            }
            else
            {
                return await sqLiteAsyncConnection.InsertAsync(item);
            }
        }

        private SQLiteAsyncConnection GetAsyncConnection()
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Constants.SqliteDbName);
            return new SQLiteAsyncConnection(path);
        }
    }
}
