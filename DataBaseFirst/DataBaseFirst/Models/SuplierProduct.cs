#nullable disable

namespace DataBaseFirst.Models
{
    public partial class SuplierProduct
    {
        public int SupplierId { get; set; }
        public int ProductsId { get; set; }

        public virtual Product Products { get; set; }
        public virtual Suplier Supplier { get; set; }
    }
}
