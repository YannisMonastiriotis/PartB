using System.Collections.Generic;

namespace PartBMain
{
    internal interface ICrudable<T> where T : class
    {
        List<T> GetAll();

        void Create(T entity);

        void Update(T entity);

        void Delete(int id);
    }
}