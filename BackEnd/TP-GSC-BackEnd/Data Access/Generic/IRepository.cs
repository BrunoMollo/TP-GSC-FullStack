using TP_GSC_BackEnd.Data_Access.Generic;

namespace TP_GSC_BackEnd.Data_Access
{
    public interface IRepository<T>
        where T : PersistableEntity
    {
        public T? GetOne(int id);

        public List<T> GetAll();

        public List<T> GetAll(Func<T, bool> condition);

        public T add(T entity);

        public T update(T entity);

        public void Delete(T entity);

        public void DeleteById(int id);


    }
}
