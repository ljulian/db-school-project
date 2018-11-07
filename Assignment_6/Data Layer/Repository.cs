using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_6.Data_Layer
{
    public class Repository<T>: IRepository<T> where T: class
    {
        protected DbContext context;
        protected DbSet<T> dbset;
        //private SchoolDBEntities schoolDBEntities;

        public Repository(DbContext datacontext)
        {
            this.context = datacontext;
            dbset = context.Set<T>();
        }
        /**
        public Repository(SchoolDBEntities schoolDBEntities)
        {
            this.schoolDBEntities = schoolDBEntities;
        }
        */
        public void Insert(T entity)
        {
            context.Entry(entity).State = EntityState.Added;
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            context.Entry(entity).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().Where(predicate);
        }

        // Student can be specified to get a collection of
        // students from the context?
        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public T GetSingle(Func<T, bool> whereExp, params Expression<Func<T, 
                           object>>[] navigationProperties)
        {
            T item = null;
            // returns the set of all entities of type T in context?
            IQueryable<T> dbQuery = context.Set<T>();
            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
            {
                // loop through each navigation property in the context?
                dbQuery = dbset.Include<T, object>(navigationProperty);
            }
            item = dbQuery.AsNoTracking().FirstOrDefault(whereExp);
            return item;
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
