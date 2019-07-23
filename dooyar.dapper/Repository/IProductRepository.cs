using dooyar.dapper.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace dooyar.dapper.Repository
{
    public interface IProductRepository:IDapperRepository
    {
        int Insert(Product entity);

       Task<int> InsertAsync(Product entity);

        Product Get(int id);

        Task<Product> GetAsync(int id);

        IEnumerable<Product> GetList();

        Task<IEnumerable<Product>> GetListAsync();

        int Update(Product entity);

        Task<int> UpdateAsync(Product entity);

        int Delete(int id);

        Task<int> DeleteAsync(int id);
    }
}
