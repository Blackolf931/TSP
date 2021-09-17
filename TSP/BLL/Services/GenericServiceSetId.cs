using BLL.Interfaces;

namespace BLL.Services
{
    public class GenericServiceSetId<T> : ISetId<T>
    {
        public virtual T SetId(int id, T model)
        {
            return model;
        }
    }
}