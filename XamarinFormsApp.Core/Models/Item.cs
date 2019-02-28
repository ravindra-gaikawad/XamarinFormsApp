using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinFormsApp.Core.Models
{
    public class Item : BaseEntity
    {
        public string Text { get; set; }

        public string Description { get; set; }
    }
}
