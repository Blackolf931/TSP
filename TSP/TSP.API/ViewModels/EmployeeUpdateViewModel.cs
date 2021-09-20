using TSP.API.Interfaces;

namespace TSP.API.ViewModels
{
#nullable disable
    public class EmployeeUpdateViewModel : IHasIdBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Patronomic { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }
        public int OfficeId { get; set; }
    }
#nullable enable
}