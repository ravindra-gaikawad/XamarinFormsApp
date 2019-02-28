using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinFormsApp.Utilities.Extensions
{
    public static class ListExtension
    {
        public static bool IsNullOrEmpty<T>(this List<T> list)
        {
            if (list == null)
            {
                return true;
            }

            if (list.Count == 0)
            {
                return true;
            }

            return false;
        }
    }
}
