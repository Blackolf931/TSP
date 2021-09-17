using BLL.Interfaces;
using BLL.Models;
namespace BLL.Services
{
    public class SetEmployeeId : GenericServiceSetId<Employee>, IEmployeeSetId
    {
        public override Employee SetId(int id, Employee model)
        {
            model.Id = id;
            return model;
        }
    }
}
