using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using TP_GSC_BackEnd.Data_Access.Generic;


namespace TP_GSC_BackEnd.Data_Access
{
    public class Repository<T> : IRepository<T>
        where T : PersistableEntity , new()
    {

        protected LoanDBContext context;
        internal DbSet<T> dbSet;

        public Repository(LoanDBContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

        virtual public List<T> GetAll()
        {
            return dbSet.ToList();
        }

        virtual public List<T> GetAll(Func<T,bool> condition)
        {
            return dbSet.Where(condition).ToList();
        }

        virtual public T? GetOne(int id)
        {
            return dbSet.FirstOrDefault(x => x.Id == id);
        }

        virtual public T add(T entity)
        {
            return dbSet.Add(entity).Entity;
        }

        virtual public T update(T entity)
        {
            return dbSet.Update(entity).Entity;
        }

        virtual public void Delete(T entity) 
        {
            dbSet.Remove(entity);
        }

        public void DeleteById(int id)
        {
            var entity = GetOne(id);
            if (entity is not null)
                Delete(entity);
        }
    }
}
