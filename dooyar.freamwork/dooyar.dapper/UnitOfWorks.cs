using Dapper;
using DapperExtensions;
using dooyar.models.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace dooyar.dapper
{
    public class UnitOfWorks:IUnitOfWorks
    {
        private Database Database = null;

        public UnitOfWorks(string connStr, DBTypes dbType = DBTypes.MySql)
        {
            Database = ConnectionFactory.CreateConnection(connStr, dbType);
        }
        public Database GetConnection()
        {
            return Database;
        }
        public T Get<T>(dynamic id, IDbTransaction trans = null, int? commandTimeout = null) where T : class
        {
            return Database.Get<T>(id, trans, commandTimeout);
        }

        public IEnumerable<T> GetList<T>(Expression<Func<T, bool>> expression = null, IList<ISort> sort = null, IDbTransaction trans = null, int? commandTimeout = null, bool buffered = true) where T : class
        {
            var predicate = DapperLinqBuilder<T>.FromExpression(expression);
            return Database.GetList<T>(predicate, sort, trans, commandTimeout, buffered);
        }
        public IEnumerable<T> GetPage<T>(Expression<Func<T, bool>> expression, IList<ISort> sort, int page, int pagesize, IDbTransaction trans = null, int? commandTimeout = null, bool buffered = true) where T : class
        {
            var predicate = DapperLinqBuilder<T>.FromExpression(expression);
            return Database.GetPage<T>(predicate, sort, page, pagesize, trans, commandTimeout, buffered);
        }
        public bool Delete<T>(T entity, IDbTransaction trans = null, int? commandTimeout = null) where T : class
        {

            return Database.Delete(entity, trans, commandTimeout);
        }

       public Task<bool> DeleteAsync<T>(T entity, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            return Database.Connection.DeleteAsync<T>(entity, transaction, commandTimeout);
        }

        public bool Delete<T>(IEnumerable<T> list, IDbTransaction trans = null, int? commandTimeout = null) where T : class
        {

            return Database.Delete(list, trans, commandTimeout);
        }

        public bool Delete<T>(Expression<Func<T, bool>> expression, IDbTransaction trans = null, int? commandTimeout = null) where T : class
        {
            var predicate = DapperLinqBuilder<T>.FromExpression(expression);
            return Database.Delete(predicate, trans, commandTimeout);
        }

        public dynamic Insert<T>(T entity, IDbTransaction trans = null, int? commandTimeout = null) where T : class
        {
            return Database.Insert(entity, trans, commandTimeout);
        }
        public Task<dynamic> InsertAsync<T>(T entity, IDbTransaction trans = null, int? commandTimeout = null) where T : class
        {
            return Database.Connection.InsertAsync(entity, trans, commandTimeout);
        }

        public void Insert<T>(IEnumerable<T> list, IDbTransaction trans = null, int? commandTimeout = null) where T : class
        {
            Database.Insert(list, trans, commandTimeout);
        }

        public Task InsertAsync<T>(IEnumerable<T> list, IDbTransaction trans = null, int? commandTimeout = null) where T : class
        {
            return Database.Connection.InsertAsync(list, trans, commandTimeout);
        }
        public bool Update<T>(T entity, IDbTransaction trans = null, int? commandTimeout = null, bool ignoreAllKeyProperties = true) where T : class
        {
            return Database.Update(entity, trans, commandTimeout, ignoreAllKeyProperties);
        }
        public Task<bool> UpdateAsync<T>(T entity, IDbTransaction trans = null, int? commandTimeout = null, bool ignoreAllKeyProperties = false) where T : class
        {
            return Database.Connection.UpdateAsync(entity, trans, commandTimeout, ignoreAllKeyProperties);
        }

        public bool Update<T>(IEnumerable<T> list, IDbTransaction trans = null, int? commandTimeout = null, bool ignoreAllKeyProperties = true) where T : class
        {
            return Database.Update(list, trans, commandTimeout, ignoreAllKeyProperties);
        }
       
        public List<T> Query<T>(string sql, object param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            return Database.Connection.Query<T>(sql, param, transaction, buffered, commandTimeout, commandType).AsList();
        }
        public int Execute<T>(string sql, object param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            return Database.Connection.Execute(sql, param, transaction, commandTimeout, commandType);
        }

        public IDbTransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            if (Database.Connection.State == ConnectionState.Closed)
                Database.Connection.Open();
            return Database.Connection.BeginTransaction(isolationLevel);
        }
        public void RollBack(IDbTransaction trans)
        {
            trans.Rollback();
            if (Database.Connection.State == ConnectionState.Open)
                trans.Connection.Close();
        }
        public void Commit(IDbTransaction trans)
        {
            trans.Commit();
            if (Database.Connection.State == ConnectionState.Open)
                trans.Connection.Close();
        }

        public void Dispose()
        {
            if (Database != null)
            {
                Database.Dispose();
            }
        }          
    }
}
