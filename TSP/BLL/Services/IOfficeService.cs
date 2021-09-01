using BLL.DTO;
using System.Collections.Generic;

namespace BLL.Services
{
    public interface IOfficeService
    {
        IEnumerable<Office> GetAll();
    }
}