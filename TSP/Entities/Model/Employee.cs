using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Model
{
    public class Employee
    {

        [Column("EmployeeId")]
       
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is requared")]
        [MaxLength(20,ErrorMessage = "Maximum Length for Name is 20 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "SecondName is requared")]
        [MaxLength(30, ErrorMessage = "Maximum Length for SecondName is 20 characters")]
        public string SecondName { get; set; }

        [Required(ErrorMessage = "Patronomic is requared")]
        [MaxLength(20, ErrorMessage = "Maximum Length for Patronomic is 20 characters")]
        public string Patronomic { get; set; }

        [Required(ErrorMessage ="Age is requared")]
        public int Age { get; set; }

        [Required(ErrorMessage ="Position is requared")]
        public string Position { get; set; }

        [ForeignKey(nameof(Office))]
        public int OfficeId { get; set; }
        public Office Office { get; set; }
    }
}
