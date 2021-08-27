using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Model
{
    public class Office
    {
        [Column("OfficeId")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Office name is a required field.")]
        [MaxLength(60, ErrorMessage ="Maximum length for the Name is 60 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Office address is a required field.")]
        [MaxLength(50, ErrorMessage = "Maximum length for the Address is 50 characters")]
        public string Address { get; set; }

        public string Country { get; set; }
        public ICollection<Employee> Employess { get; set; }
    }
}
