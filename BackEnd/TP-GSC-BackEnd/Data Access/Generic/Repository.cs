using Microsoft.EntityFrameworkCore;
using TP_GSC_BackEnd.Data_Access.Generic;
using TP_GSC_BackEnd.Entities;

namespace TP_GSC_BackEnd.Data_Access
{
    public class Repository<T> : IRepository<T>
        where T : PersistableEntity
    {

        protected LoanDBContext context;
        internal DbSet<T> dbSet;

        public Repository(LoanDBContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

        public List<T> GetAll()
        {
            return dbSet.ToList();
        }

        public T? GetOne(int id)
        {
            return dbSet.FirstOrDefault(x => x.Id == id);
        }

        public T add(T entity)
        {
            return dbSet.Add(entity).Entity;
        }

        public T update(T entity)
        {
            return dbSet.Update(entity).Entity;
        }
    }
}
