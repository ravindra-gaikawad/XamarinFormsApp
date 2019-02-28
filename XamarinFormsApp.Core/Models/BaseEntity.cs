using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinFormsApp.Core.Models
{
    public abstract class BaseEntity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
}
