namespace DBTools.EntityFramework.Abstract.Interfaces
{
    public interface ISyncable<T>
    {
        bool EqualsInDb(T obj);
        T Map();
    }
}