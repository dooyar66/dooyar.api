using dooyar.ef.Data;
using dooyar.models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace dooyar.ef
{
    public class EFUnitOfWorks:IEFUnitOfWorks
    {
        private DbContext _dbContext;
        public EFUnitOfWorks(string connStr, DBTypes dbTypes = DBTypes.MySql)
        {
            _dbContext = new AppDbContent(connStr, dbTypes);
        }
        private bool SaveChanges()
        {
            return _dbContext.SaveChanges() > 0;
        }

        public  DatabaseFacade Database
        {
            get { return _dbContext.Database; }
        }

        public T Get<T>(dynamic id) where T : class
        {
          return  _dbContext.Set<T>().Find(id);
        }

        public IQueryable<T> GetList<T>(Expression<Func<T, bool>> expression = null) where T : class
        {
           return _dbContext.Set<T>().Where(expression);
        }

        public IQueryable<T> GetPage<T>(Expression<Func<T, bool>> expression, int page, int pagesize) where T : class
        {
            return _dbContext.Set<T>().Where(expression);
        }

        public bool Insert<T>(T obj) where T : class
        {
            _dbContext.Set<T>().Add(obj);
            return SaveChanges();
        }

        public int Insert<T>(IEnumerable<T> list) where T : class
        {
            _dbContext.Set<T>().AddRange(list);
            return _dbContext.SaveChanges();
        }

        public bool Update<T>(T obj) where T : class
        {
            _dbContext.Set<T>().Update(obj);
            return SaveChanges();
        }

        public int Update<T>(IEnumerable<T> list) where T : class
        {
            _dbContext.Set<T>().UpdateRange(list);
            return _dbContext.SaveChanges();
        }

        public bool Delete<T>(T obj) where T : class
        {
            _dbContext.Set<T>().Remove(obj);
            return _dbContext.SaveChanges() > 0;
        }

       
        public int  Delete<T>(IEnumerable<T> list) where T : class
        {
            _dbContext.Set<T>().RemoveRange(list);
            return _dbContext.SaveChanges();
        }     

        public List<T> Query<T>(string sql, object param = null)
        {
            throw new NotImplementedException();
        }

        public int Execute<T>(string sql, object param = null)
        {
            throw new NotImplementedException();
        }

        public IDbContextTransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            return Database.BeginTransaction(isolationLevel);
        }

        public void Commit(IDbContextTransaction tran)
        {
            tran.Commit();
        }

        public void RollBack(IDbContextTransaction tran)
        {
            tran.Rollback();
        }
        public void Dispose()
        {
            if (_dbContext != null)
            {
                _dbContext.Dispose();
            }
        }
    }
}
