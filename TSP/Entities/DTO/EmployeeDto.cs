using Entities.Model;
namespace Entities.DTO
{
    public class EmployeeDto : Employee
    {
        public EmployeeDto(int id, string name, string secondName, string patronomic, int age, string position, int officeId)
        {
            Id = id;
            Name = name;
            SecondName = secondName;
            Patronomic = patronomic;
            Age = age;
            Position = position;
            OfficeId = officeId;
        }
    }
}
