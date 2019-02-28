using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinFormsApp.Core.Models;

namespace XamarinFormsApp.Services.Definitions
{
    public interface IItemService
    {
        Task<List<Item>> GetAsync();

        Task<int> SaveAsync(Item item);
    }
}
