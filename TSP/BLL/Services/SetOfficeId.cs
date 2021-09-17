using BLL.Interfaces;
using BLL.Models;

namespace BLL.Services
{
    public class SetOfficeId : GenericServiceSetId<Office>, IOfficeSetId
    {
        public override Office SetId(int id, Office model)
        {
            model.Id = id;
            return model;
        }
    }
}
