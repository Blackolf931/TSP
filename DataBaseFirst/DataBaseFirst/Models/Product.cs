using System;
using System.Collections.Generic;

#nullable disable

namespace DataBaseFirst.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int? CategoryId { get; set; }
        public int? ImageId { get; set; }

        public virtual Category Category { get; set; }
    }
}
