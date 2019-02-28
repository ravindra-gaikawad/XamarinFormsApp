using XamarinFormsApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Autofac;
using XamarinFormsApp.Core.Enums;

namespace XamarinFormsApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();

        public MainPage(ItemsPage itemsPage)
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            this.Detail = new NavigationPage(itemsPage);
            MenuPages.Add((int)MenuItemType.Browse, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Browse:
                        {
                            ItemsPage itemsPage = App.Container.Resolve<ItemsPage>();
                            MenuPages.Add(id, new NavigationPage(itemsPage));

                            break;
                        }
                    case (int)MenuItemType.About:
                        {
                            AboutPage aboutPage = App.Container.Resolve<AboutPage>();
                            MenuPages.Add(id, new NavigationPage(aboutPage));

                            break;
                        }
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}