using mvc_CRUD.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace mvc_CRUD.Abstract
{
    public abstract class RepositoryBase<T> where T: class
    {
        protected EmployeeContext _context;
        protected DbSet<T> dbSet ;

        public RepositoryBase()
        {
            this._context = new EmployeeContext();
            dbSet = _context.Set<T>();
        }

        public RepositoryBase(EmployeeContext _dataContext)
        {
            this._context = _dataContext;
            dbSet = _dataContext.Set<T>();
        }
        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

      public T  FindBy(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Add(T obj)
        {
            dbSet.Add(obj);
        }

        public virtual void Update(T obj)
        {
            dbSet.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        public virtual void Delete(object id)
        {
            T existing = dbSet.Find(id);
            dbSet.Remove(existing);
        }

        public virtual void Save()
        {
                _context.SaveChanges();
        }
    }
}