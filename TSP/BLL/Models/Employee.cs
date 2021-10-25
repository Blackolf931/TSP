using BLl.Interfaces;

namespace BLL.Models
{
    public class Employee : IHasIdBase
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? SecondName { get; set; }
        public string? Patronymic { get; set; }
        public int Age { get; set; }
        public string? Position { get; set; }
        public Office? Office { get; set; }
        public int OfficeId { get; set; }
        public string? AdditionalInformation { get; set; }
    }
}