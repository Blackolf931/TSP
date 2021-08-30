using Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class OfficeDto : Office
    {
        public OfficeDto(int id, string name, string address, string country)
        {
            Id = id;
            Name = name;
            Address = address;
            Country = country;
        }
    }
}
