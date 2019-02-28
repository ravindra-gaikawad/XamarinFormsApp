using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinFormsApp.Core.Models;
using XamarinFormsApp.Repository.Definitions;
using XamarinFormsApp.Services.Definitions;
using XamarinFormsApp.Utilities.Extensions;

namespace XamarinFormsApp.Services.Implementations
{
    public class ItemService : IItemService
    {
        private readonly IHttpService httpService;
        private readonly ISQLiteRepository sqLiteRepository;

        public ItemService(IHttpService httpService, ISQLiteRepository sqLiteRepository )
        {
            this.httpService = httpService;
            this.sqLiteRepository = sqLiteRepository;
        }

        async Task<List<Item>> IItemService.GetAsync()
        {
            return await sqLiteRepository.GetAsync<Item>();
        }

        async Task<int> IItemService.SaveAsync(Item item)
        {
            return await sqLiteRepository.SaveAsync<Item>(item);
        }
    }
}
