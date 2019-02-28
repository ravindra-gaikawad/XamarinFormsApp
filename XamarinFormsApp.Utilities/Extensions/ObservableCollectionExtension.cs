using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace XamarinFormsApp.Utilities.Extensions
{
    public static class ObservableCollectionExtension
    {
        public static void AddRange<T>(this ObservableCollection<T> collection, IEnumerable<T> items)
        {
            items.ToList().ForEach(collection.Add);
        }

        /// <summary>
        /// Adds the elements of the specified collection to the end of the <see cref="ObservableCollection<T>"/> 
        /// </summary>
        /// <typeparam name="T">The type of elements.</typeparam>
        /// <param name="collection">The collection whose elements should be added to the end of the <see cref="ObservableCollection<T>"/>. The collection itself cannot be null, but it can contain elements that are null, if type <typeparamref name="T"/> is a reference type.</param>
        /// <param name="items">collection to be added</param>
        /// <param name="clear">true to clear collection before adding elements. </param>
        public static void AddRange<T>(this ObservableCollection<T> collection, IEnumerable<T> items, bool clear)
        {
            if(clear)
            {
                collection.Clear();
            }

            items.ToList().ForEach(collection.Add);
        }
    }
}
