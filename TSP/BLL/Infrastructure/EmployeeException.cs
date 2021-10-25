using System;

namespace BLL.Infrastructure
{
    public class EmployeeException : Exception
    {
        public EmployeeException(string message)
        : base(message) {
        }
    }
}
