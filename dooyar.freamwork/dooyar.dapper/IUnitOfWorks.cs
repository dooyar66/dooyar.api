using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace dooyar.dapper
{
    public interface IUnitOfWorks:IDisposable
    {
        Database GetConnection();
        T Get<T>(dynamic id, IDbTransaction trans = null, int? commandTimeout = null) where T : class;     
        IEnumerable<T> GetList<T>(Expression<Func<T, bool>> expression = null, IList<ISort> sort = null, IDbTransaction trans = null, int? commandTimeout = null, bool buffered = true) where T : class;
        IEnumerable<T> GetPage<T>(Expression<Func<T, bool>> expression, IList<ISort> sort, int page, int pagesize, IDbTransaction trans = null, int? commandTimeout = null, bool buffered = true) where T : class;
        dynamic Insert<T>(T obj, IDbTransaction trans = null, int? commandTimeout = null) where T : class;
        Task<dynamic> InsertAsync<T>(T entity, IDbTransaction trans = null, int? commandTimeout = null) where T : class;
        void Insert<T>(IEnumerable<T> list, IDbTransaction trans = null, int? commandTimeout = null) where T : class;
        Task InsertAsync<T>(IEnumerable<T> list, IDbTransaction trans = null, int? commandTimeout = null) where T : class;
        bool Update<T>(T entity, IDbTransaction trans = null, int? commandTimeout = null, bool ignoreAllKeyProperties = false) where T : class;
        Task<bool> UpdateAsync<T>(T entity, IDbTransaction trans = null, int? commandTimeout = null, bool ignoreAllKeyProperties = false) where T : class;
        bool Update<T>(IEnumerable<T> list, IDbTransaction trans = null, int? commandTimeout = null, bool ignoreAllKeyProperties = false) where T : class;
        bool Delete<T>(T obj, IDbTransaction trans = null, int? commandTimeout = null) where T : class;
        Task<bool> DeleteAsync<T>(T obj, IDbTransaction trans = null, int? commandTimeout = null) where T : class;
        bool Delete<T>(IEnumerable<T> list, IDbTransaction trans = null, int? commandTimeout = null) where T : class;
        bool Delete<T>(Expression<Func<T, bool>> expression, IDbTransaction trans = null, int? commandTimeout = null) where T : class;
        IDbTransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        void RollBack(IDbTransaction trans);
        void Commit(IDbTransaction trans);
        List<T> Query<T>(string sql, object param = null, IDbTransaction trans = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null);
        int Execute<T>(string sql, object param = null, IDbTransaction trans = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null);
    }
}
