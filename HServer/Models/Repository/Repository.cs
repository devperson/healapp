using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using LinqKit;

namespace HServer.Models.Repository
{
    public class Repository<T> : IDisposable where T : class
    {
        protected DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        ~Repository()
        {
            Dispose(false);
        }

        #region Methods
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsEnumerable();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().AsExpandable().Where<T>(predicate);
        }

        public T FindOne(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().AsExpandable().FirstOrDefault<T>(predicate);
        }

        public T Add(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            return _context.Set<T>().Add(entity);
        }

        public T Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            _context.Set<T>().Attach(entity);
            _context.Entry<T>(entity).State = EntityState.Modified;
            return entity;
        }

        public void Delete(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            _context.Set<T>().Remove(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
        #endregion

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
        #endregion IDisposable
    }
}