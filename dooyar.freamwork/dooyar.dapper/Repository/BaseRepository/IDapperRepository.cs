using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace dooyar.dapper.Repository
{
    public interface IDapperRepository<TEntity>: IDapperEntityRepository<TEntity> where TEntity : class
    {
        IEnumerable<dynamic> Query(string sql, object param = null);

        IEnumerable<T> Query<T>(string sql, object param = null);

        Task<IEnumerable<dynamic>> QueryAsync(string sql, object param = null);

        Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null);

        T QueryFirst<T>(string sql, object param = null);

        dynamic QueryFirst(string sql, object param = null);

        Task<T> QueryFirstAsync<T>(string sql, object param = null);

        Task<dynamic> QueryFirstAsync(string sql, object param = null);

        int Execute(string sql, object param = null, CommandType? commandType = null);

        Task<int> ExecuteAsync(string sql, object param = null, CommandType? commandType = null);

        object ExecuteScalar(string sql, object param = null);

        Task<T> ExecuteScalarAsync<T>(string sql, object param = null);
    }
}
