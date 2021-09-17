namespace BLL.Interfaces
{
    public interface ISetId<T>
    {
        T SetId(int id, T model);
    }
}
