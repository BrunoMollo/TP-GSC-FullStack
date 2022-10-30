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

        public void add(T entity)
        {
            dbSet.Add(entity);
            context.SaveChanges();
        }

        public void update(T entity)
        {
            dbSet.Update(entity);//??
        }
    }
}
