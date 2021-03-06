using BLl.Interfaces;
using System.Collections.Generic;

namespace BLL.Models
{
    public class Office : IHasIdBase
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }
        public ICollection<Employee>? Employess { get; set; }
    }
}