using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Office
    {
        [Column("OfficeId")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
    }
}