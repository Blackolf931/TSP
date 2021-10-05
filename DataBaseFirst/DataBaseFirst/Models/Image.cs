#nullable disable

namespace DataBaseFirst.Models
{
    public partial class Image
    {
        public byte[] Image1 { get; set; }
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
