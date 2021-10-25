using System;

namespace BLL.Infrastructure
{
    public class OfficeException : Exception
    {
        public OfficeException(string message)
           : base(message)
        {
        }
    }
}