using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using dooyar.dapper.Model;

namespace dooyar.dapper.Repository
{
    public class ProductRepository : DapperRepository, IProductRepository
    {
        public ProductRepository(string connStr, DbType dbType = DbType.MySql):base(connStr,dbType)
        {

        }

        public int Delete(int id)
        {
            string sql = "delete from Products where Id = @Id;";
            return Execute(sql, new { Id = id }, System.Data.CommandType.Text);
        }

        public Task<int> DeleteAsync(int id)
        {
            string sql = "delete from Products where Id = @Id;";
            return ExecuteAsync(sql, new { Id = id }, System.Data.CommandType.Text);
        }

        public Product Get(int id)
        {
            string sql = "select Id,Name,Description from Products where Id = @Id;";
            return QueryFirst<Product>(sql, new { Id = id });
        }

        public Task<Product> GetAsync(int id)
        {
            string sql = "select Id,Name,Description from Products where Id = @Id;";
            return QueryFirstAsync<Product>(sql, new { Id = id });
        }

        public IEnumerable<Product> GetList()
        {
            string sql = "select Id,Name,Description from Products;";
            return Query<Product>(sql);
        }

        public Task<IEnumerable<Product>> GetListAsync()
        {
            string sql = "select Id,Name,Description from Products;";
            return QueryAsync<Product>(sql);
        }

        public int Insert(Product entity)
        {
            string sql = "Insert into Products(Id,Name,Description) values (@Id,@Name,@Description);";
            return Execute(sql, entity, System.Data.CommandType.Text);
        }

        public Task<int> InsertAsync(Product entity)
        {
            string sql = "Insert into Products(Id,Name,Description) values (@Id,@Name,@Description);";
            return ExecuteAsync(sql, entity, System.Data.CommandType.Text);
        }

        public int Update(Product entity)
        {
            string sql = "update Products set Name=@Name,Description=@Description where Id=@Id;";
            return Execute(sql, entity, System.Data.CommandType.Text);
        }

        public Task<int> UpdateAsync(Product entity)
        {
            string sql = "update Products set Name=@Name,Description=@Description where Id=@Id;";
            return ExecuteAsync(sql, entity, System.Data.CommandType.Text);
        }
    }
}
