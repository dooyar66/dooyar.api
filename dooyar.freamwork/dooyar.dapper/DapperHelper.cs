using Dapper;
using DapperExtensions;
using dooyar.models.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Text;

namespace dooyar.dapper
{
    public class DapperHelper : IDapperHelper, IDisposable
    {
        private Database Connection = null;

        public DapperHelper(string connStr, DBTypes dbType = DBTypes.MySql)
        {       
            Connection = ConnectionFactory.CreateConnection(connStr, dbType);
        }
        public Database GetConnection()
        {
            return Connection;
        }
        public T Get<T>(dynamic id, IDbTransaction tran = null, int? commandTimeout = null) where T : class
        {
            return Connection.Get<T>(id, tran, commandTimeout);
        }
        public IEnumerable<T> GetAll<T>(Expression<Func<T, bool>> expression = null, IList<ISort> sort = null, IDbTransaction tran = null, int? commandTimeout = null, bool buffered = true) where T : class
        {
            var predicate = DapperLinqBuilder<T>.FromExpression(expression);
            return Connection.GetList<T>(predicate, sort, tran, commandTimeout, buffered);
        }
        public IEnumerable<T> GetPage<T>(Expression<Func<T, bool>> expression, IList<ISort> sort, int page, int pagesize, IDbTransaction tran = null, int? commandTimeout = null, bool buffered = true) where T : class
        {
            var predicate = DapperLinqBuilder<T>.FromExpression(expression);
            return Connection.GetPage<T>(predicate, sort, page, pagesize, tran, commandTimeout, buffered);
        }
        public bool Delete<T>(T obj, IDbTransaction tran = null, int? commandTimeout = null) where T : class
        {

            return Connection.Delete(obj, tran, commandTimeout);
        }

        public bool Delete<T>(IEnumerable<T> list, IDbTransaction tran = null, int? commandTimeout = null) where T : class
        {

            return Connection.Delete(list, tran, commandTimeout);
        }      
       
        public dynamic Insert<T>(T obj, IDbTransaction tran = null, int? commandTimeout = null) where T : class
        {
            return Connection.Insert(obj, tran, commandTimeout);
        }

        public void Insert<T>(IEnumerable<T> list, IDbTransaction tran = null, int? commandTimeout = null) where T : class
        {
            Connection.Insert(list, tran, commandTimeout);
        }
        public bool Update<T>(T obj, IDbTransaction tran = null, int? commandTimeout = null, bool ignoreAllKeyProperties = true) where T : class
        {
            return Connection.Update(obj, tran, commandTimeout, ignoreAllKeyProperties);
        }

        public bool Update<T>(IEnumerable<T> list, IDbTransaction tran = null, int? commandTimeout = null, bool ignoreAllKeyProperties = true) where T : class
        {
            return Connection.Update(list, tran, commandTimeout, ignoreAllKeyProperties);
        }
        public List<T> Query<T>(string sql, object param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            return Connection.Connection.Query<T>(sql, param, transaction, buffered, commandTimeout, commandType).AsList();
        }
        public int Execute<T>(string sql, object param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            return Connection.Connection.Execute(sql, param, transaction, commandTimeout, commandType);
        }

        public IDbTransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            if (Connection.Connection.State == ConnectionState.Closed)
                Connection.Connection.Open();
            return Connection.Connection.BeginTransaction(isolationLevel);
        }
        public void RollBack(IDbTransaction tran)
        {
            tran.Rollback();
            if (Connection.Connection.State == ConnectionState.Open)
                tran.Connection.Close();
        }
        public void Commit(IDbTransaction tran)
        {
            tran.Commit();
            if (Connection.Connection.State == ConnectionState.Open)
                tran.Connection.Close();
        }

        public void Dispose()
        {
            if (Connection != null)
            {
                Connection.Dispose();
            }
        }
    }
}
