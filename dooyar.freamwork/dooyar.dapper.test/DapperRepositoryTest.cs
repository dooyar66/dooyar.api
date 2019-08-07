using DapperExtensions;
using dooyar.models.Entities;
using dooyar.models.Enums;
using System.Linq;
using Xunit;

namespace dooyar.dapper.test
{
    public class DapperRepositoryTest
    {
        private readonly string connStr = "Server=localhost;User Id=root;Password=123456;Database=shop_demo";

        [Fact]
        public void TestInsert()
        {
            using (var dapperHelper = new DapperHelper(connStr))
            {
                var result = dapperHelper.Insert(new Product { Name = "测试商品001", Description = "测试商品001的描述" });
                Assert.True(result > 0);
                
            }
        }

        [Fact]
        public void TestGetAll()
        {
            using (var dapperHelper = new DapperHelper(connStr))
            {
                //var predicate = Predicates.Field<Product>(f => f.Id, Operator.Gt, 0);
                var allrecords = dapperHelper.GetAll<Product>(t=>t.Id > 0).ToList();
                Assert.True(allrecords.Count > 0);

            }
        }
    }
}
