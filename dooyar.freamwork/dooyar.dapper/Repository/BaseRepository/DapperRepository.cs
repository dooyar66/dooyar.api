using Dapper;
using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace dooyar.dapper.Repository
{
    public class DapperRepository<TEntity> : IDapperRepository<TEntity> where TEntity : class
    {
        private readonly string _connStr;
        private readonly DbType _dbType;
        public DapperRepository(string connStr, DbType dbType = DbType.MySql)
        {
            _connStr = connStr;
            _dbType = dbType;
        }

        #region  entity CRUD

        public TEntity Get(Expression<Func<TEntity, bool>> expression = null)
        {
            var predicate = DapperLinqBuilder<TEntity>.FromExpression(expression);
            using (var connection = ConnectionFactory.CreateConnection(_connStr, _dbType))
            {
                return connection.GetList<TEntity>(predicate).FirstOrDefault();
            }
        }

        public TEntity GetById(dynamic primaryId)
        {
            using (var connection = ConnectionFactory.CreateConnection(_connStr, _dbType))
            {
                return connection.Get<TEntity>(primaryId as object);
            }
        }

        public Task<TEntity> GetByIdAsync(dynamic primaryId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> expression = null)
        {
            var predicate = DapperLinqBuilder<TEntity>.FromExpression(expression);
            using (var connection = ConnectionFactory.CreateConnection(_connStr, _dbType))
            {
                return connection.GetList<TEntity>(predicate);
            }
        }

        public Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> expression = null)
        {
            var predicate = DapperLinqBuilder<TEntity>.FromExpression(expression);
            using (var connection = ConnectionFactory.CreateConnection(_connStr, _dbType))
            {
                return connection.GetListAsync<TEntity>(predicate);
            }
        }


        public bool Insert(TEntity entity)
        {
            using (var connection = ConnectionFactory.CreateConnection(_connStr, _dbType))
            {
                return connection.Insert(entity);
            }
        }

        public void Insert(IEnumerable<TEntity> entitys)
        {
            using (var connection = ConnectionFactory.CreateConnection(_connStr, _dbType))
            {
                connection.Insert(entitys);
            }
        }

        public Task<dynamic> InsertAsync(TEntity entity)
        {
            using (var connection = ConnectionFactory.CreateConnection(_connStr, _dbType))
            {
              return  connection.InsertAsync(entity);
            }
        }

        public bool Update(TEntity entity)
        {
            using (var connection = ConnectionFactory.CreateConnection(_connStr, _dbType))
            {
               return connection.Update(entity);
            }
        }

        public Task<bool> UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
        public int Count(Expression<Func<TEntity, bool>> expression = null)
        {
            var predicate = DapperLinqBuilder<TEntity>.FromExpression(expression);
            using (var connection = ConnectionFactory.CreateConnection(_connStr, _dbType))
            {
                return connection.Count<TEntity>(predicate);
            }
        }

        public bool Delete(Expression<Func<TEntity, bool>> expression)
        {
            var predicate = DapperLinqBuilder<TEntity>.FromExpression(expression);
            using (var connection = ConnectionFactory.CreateConnection(_connStr, _dbType))
            {
                return connection.Delete<TEntity>(predicate);
            }
        }

        public Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> expression)
        {
            var predicate = DapperLinqBuilder<TEntity>.FromExpression(expression);
            using (var connection = ConnectionFactory.CreateConnection(_connStr, _dbType))
            {
                return connection.DeleteAsync<TEntity>(predicate);
            }
        }

        public bool Delete(dynamic primaryId)
        {
            using (var connection = ConnectionFactory.CreateConnection(_connStr, _dbType))
            {
                return connection.Delete<TEntity>(primaryId as object);
            }
        }

        public Task<bool> DeleteAsync(dynamic primaryId)
        {
            using (var connection = ConnectionFactory.CreateConnection(_connStr, _dbType))
            {
                return connection.DeleteAsync<TEntity>(primaryId as object);
            }
        }

        public bool Exists(Expression<Func<TEntity, bool>> expression)
        {
            var predicate = DapperLinqBuilder<TEntity>.FromExpression(expression);
            using (var connection = ConnectionFactory.CreateConnection(_connStr, _dbType))
            {
                return connection.Count<TEntity>(predicate) > 0;
            }
        }                
        #endregion

        public int Execute(string sql, object param = null, CommandType? commandType = null)
        {
            using (var connection = ConnectionFactory.CreateConnection(_connStr, _dbType))
            {
              return  connection.Execute(sql, param, null, null, commandType);
            }
        }

        public Task<int> ExecuteAsync(string sql, object param = null, CommandType? commandType = null)
        {
            using (var connection = ConnectionFactory.CreateConnection(_connStr, _dbType))
            {
                return connection.ExecuteAsync(sql, param, null, null, commandType);
            }
        }

        public object ExecuteScalar(string sql, object param = null)
        {
            using (var connection = ConnectionFactory.CreateConnection(_connStr, _dbType))
            {
                return connection.ExecuteScalar(sql, param);
            }
        }

        public Task<T> ExecuteScalarAsync<T>(string sql, object param = null)
        {
            using (var connection = ConnectionFactory.CreateConnection(_connStr, _dbType))
            {
                return connection.ExecuteScalarAsync<T>(sql, param);
            }
        }

    
        public IEnumerable<dynamic> Query(string sql, object param = null)
        {
            using (var connention = ConnectionFactory.CreateConnection(_connStr, _dbType))
            {
              return  connention.Query(sql, param);
            }
        }

        public IEnumerable<T> Query<T>(string sql, object param = null)
        {
            using (var connention = ConnectionFactory.CreateConnection(_connStr, _dbType))
            {
                return connention.Query<T>(sql, param);
            }
        }

        public Task<IEnumerable<dynamic>> QueryAsync(string sql, object param = null)
        {
            using (var connention = ConnectionFactory.CreateConnection(_connStr, _dbType))
            {
                return connention.QueryAsync(sql, param);
            }
        }

        public Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null)
        {
            using (var connention = ConnectionFactory.CreateConnection(_connStr, _dbType))
            {
                return connention.QueryAsync<T>(sql, param);
            }
        }

        public T QueryFirst<T>(string sql, object param = null)
        {
            using (var connention = ConnectionFactory.CreateConnection(_connStr, _dbType))
            {
                return connention.QueryFirst<T>(sql, param);
            }
        }

        public dynamic QueryFirst(string sql, object param = null)
        {
            using (var connention = ConnectionFactory.CreateConnection(_connStr, _dbType))
            {
                return connention.QueryFirst(sql, param);
            }
        }

        public Task<T> QueryFirstAsync<T>(string sql, object param = null)
        {
            using (var connention = ConnectionFactory.CreateConnection(_connStr, _dbType))
            {
                return connention.QueryFirstAsync<T>(sql, param);
            }
        }

        public Task<dynamic> QueryFirstAsync(string sql, object param = null)
        {
            using (var connention = ConnectionFactory.CreateConnection(_connStr, _dbType))
            {
                return connention.QueryFirstAsync(sql, param);
            }
        }      
    }
}
