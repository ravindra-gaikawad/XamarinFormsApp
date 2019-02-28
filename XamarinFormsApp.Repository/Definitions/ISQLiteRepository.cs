using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinFormsApp.Core.Models;

namespace XamarinFormsApp.Repository.Definitions
{
    public interface ISQLiteRepository
    {
        Task<List<T>> GetAsync<T>() where T : BaseEntity, new();

        Task<T> GetAsync<T>(int id) where T : BaseEntity, new();

        Task<int> SaveAsync<T>(T item) where T : BaseEntity;

        Task<int> DeleteAsync<T>(T item) where T : BaseEntity;
    }
}
