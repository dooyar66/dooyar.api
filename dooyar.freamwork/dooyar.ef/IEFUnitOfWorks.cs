using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace dooyar.ef
{
   public interface IEFUnitOfWorks: IDisposable
    {
        T Get<T>(dynamic id) where T : class;
        IQueryable<T> GetList<T>(Expression<Func<T, bool>> expression = null) where T : class;
        IQueryable<T> GetPage<T>(Expression<Func<T, bool>> expression, int page, int pagesize) where T : class;
        bool Insert<T>(T obj) where T : class;
        int Insert<T>(IEnumerable<T> list) where T : class;
        bool Update<T>(T obj) where T : class;
        int Update<T>(IEnumerable<T> list) where T : class;
        bool Delete<T>(T obj) where T : class;
        int Delete<T>(IEnumerable<T> list) where T : class;
        IDbContextTransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        void RollBack(IDbContextTransaction tran);
        void Commit(IDbContextTransaction tran);
        List<T> Query<T>(string sql, object param = null);
        int Execute<T>(string sql, object param = null);
    }
}
