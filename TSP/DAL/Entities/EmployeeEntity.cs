using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class EmployeeEntity
    {
        [Column("EmployeeId")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is requared")]
        [MaxLength(20, ErrorMessage = "Maximum Length for Name is 20 characters")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "SecondName is requared")]
        [MaxLength(30, ErrorMessage = "Maximum Length for SecondName is 20 characters")]
        public string? SecondName { get; set; }

        [Required(ErrorMessage = "Patronomic is requared")]
        [MaxLength(20, ErrorMessage = "Maximum Length for Patronomic is 20 characters")]
        public string? Patronomic { get; set; }

        [Required(ErrorMessage = "Age is requared")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Position is requared")]
        public string? Position { get; set; }

        [ForeignKey(nameof(Office))]
        public virtual int OfficeId { get; set; }
        public virtual OfficeEntity? Office { get; set; }
    }
}