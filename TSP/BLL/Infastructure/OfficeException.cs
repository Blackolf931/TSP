using System;

namespace BLL.Infastructure
{
    public class OfficeException : Exception
    {
        public OfficeException(string message)
           : base(message)
        {
        }
    }
}
