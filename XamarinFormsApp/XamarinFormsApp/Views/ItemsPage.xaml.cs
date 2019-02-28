using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using XamarinFormsApp.Core.Models;
using XamarinFormsApp.Views;
using XamarinFormsApp.ViewModels;
using XamarinFormsApp.Services.Definitions;
using XamarinFormsApp.Utilities.Extensions;

namespace XamarinFormsApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsPage : ContentPage
    {
        private readonly IItemService itemService;
        private readonly ItemsViewModel itemsViewModel;
        
        // Todo: Remove this after,able to resolve DI in MainPage Detail XAML code.
        public ItemsPage()
        {

        }

        public ItemsPage(IItemService itemService, ItemsViewModel itemsViewModel)
        {
            InitializeComponent();

            this.itemService = itemService;
            this.itemsViewModel = itemsViewModel;

            BindingContext = itemsViewModel;

            MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Item;
                await this.itemService.SaveAsync(newItem);
            });
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var items = await itemService.GetAsync();
            itemsViewModel.Items.AddRange<Item>(items);
        }
    }
}