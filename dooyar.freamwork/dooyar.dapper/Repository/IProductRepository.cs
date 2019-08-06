using dooyar.freamwork.model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dooyar.dapper.Repository
{
    public interface IProductRepository
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
