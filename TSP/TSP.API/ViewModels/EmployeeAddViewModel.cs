using TSP.API.Interfaces;

namespace TSP.API.ViewModels
{
#nullable disable
    public class EmployeeAddViewModel : IHasIdBase
    {
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Patronomic { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }
        public int OfficeId { get; set; }
        public int Id { get; set; }
    }
#nullable enable
}