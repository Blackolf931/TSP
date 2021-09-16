using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class OfficeEntity
    {
        [Column("OfficeId")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Office name is a required field.")]
        [MaxLength(60, ErrorMessage ="Maximum length for the Name is 60 characters")]
        public string? Name { get; set; }

        [MaxLength(50, ErrorMessage = "Maximum length for the Address is 50 characters")]
        public string? Address { get; set; }

        public string? Country { get; set; }
        public ICollection<EmployeeEntity>? Employess { get; set; }
    }
}