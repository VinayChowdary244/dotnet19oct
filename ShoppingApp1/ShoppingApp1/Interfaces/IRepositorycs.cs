using ShoppingApp1.Models;

namespace ShoppingApp1.Interfaces
{
    public interface IRepository<K, T>
    {
        T GetById(K key);
        IList<T> GetAll();
        T Add(T entity);
        T Update(T entity);
        T Delete(K key);
       
    }
}
