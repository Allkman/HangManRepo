using System.Collections.Generic;

namespace HangManBL.Interfaces
{
    public interface ICRUDRepository<T>
    {
        List<T> GetAll();
        T Get(int key);
        void Update(T entity);
        int Add(T entity);
        void Delete(int key);
    }
}
