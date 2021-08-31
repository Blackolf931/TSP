using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TSP.API.Exceptions
{
    public class OfficeException : Exception
    {
        public OfficeException(string message)
           : base(message)
        {
        }
    }
}
