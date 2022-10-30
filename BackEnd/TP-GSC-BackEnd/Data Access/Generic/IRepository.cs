using TP_GSC_BackEnd.Data_Access.Generic;

namespace TP_GSC_BackEnd.Data_Access
{
    public interface IRepository<T>
        where T : PersistableEntity
    {
        public T? GetOne(int id);

        public List<T> GetAll();

        public void insert(T entity);

        public void update(T entity);
    }
}
