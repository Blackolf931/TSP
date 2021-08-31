using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TSP.API.Exceptions
{
    public class EmployeeException : Exception
    {
        public EmployeeException(string message)
        : base(message) {
        }
    }
}
