using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using XamarinFormsApp.Core.Models;
using XamarinFormsApp.Views;

namespace XamarinFormsApp.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Items { get; set; }
       
        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<Item>();
        }
    }
}