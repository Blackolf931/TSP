using TSP.API.Interfaces;

namespace TSP.API.ViewModels
{
#nullable disable
    public class OfficeAddViewModel : IHasIdBase
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public int Id { get; set; }
    }
#nullable enable
}