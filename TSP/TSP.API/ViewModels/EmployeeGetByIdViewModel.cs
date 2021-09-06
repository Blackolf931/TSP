using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TSP.API.ViewModels
{
    public class EmployeeGetByIdViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Patronomic { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }
        public int OfficeId { get; set; }

        public string AdditionalInformation { get; set; }
    }
}
