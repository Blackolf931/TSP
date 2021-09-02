using System;

namespace BLL.Infastructure
{
    public class EmployeeException : Exception
    {
        public EmployeeException(string message)
        : base(message) {
        }
    }
}
