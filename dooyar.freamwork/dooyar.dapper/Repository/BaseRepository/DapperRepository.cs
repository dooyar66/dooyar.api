using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace dooyar.dapper.Repository
{
    public class DapperRepository : IDapperRepository 
    {
        private readonly string _connStr;
        private readonly DbType _dbType;
        public DapperRepository(string connStr, DbType dbType = DbType.MySql)
        {
            _connStr = connStr;
            _dbType = dbType;
        }
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
