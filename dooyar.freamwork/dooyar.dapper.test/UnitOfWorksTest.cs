using dooyar.models.Entities;
using System.Linq;
using Xunit;

namespace dooyar.dapper.test
{
    public class UnitOfWorksTest
    {
        private readonly string connStr = "Server=localhost;User Id=root;Password=123456;Database=shop_demo";

        [Fact]
        public void TestInsert()
        {
            using (var unitOfWorks = new UnitOfWorks(connStr))
            {
                //var result = unitOfWorks.Insert(new Product { Name = "测试商品001", Description = "测试商品001的描述" });
                //var result = unitOfWorks.Insert(new User { UserName = "alice", Account = "15300153009", Pwd = "123456" });            
                //Assert.True(result > 0);               
            }
        }

        [Fact]
        public void TestGetAll()
        {
            using (var unitOfWorks = new UnitOfWorks(connStr))
            {
                //var predicate = Predicates.Field<Product>(f => f.Id, Operator.Gt, 0);
                var productList = unitOfWorks.GetList<Product>(t=>t.Id > 0).ToList();
                Assert.True(productList.Count > 0);

            }
        }

        [Fact]
        public void TestTrans()
        {
            using (var unitOfWorks = new UnitOfWorks(connStr))
            {
                var trans = unitOfWorks.BeginTransaction();
                try
                {

                    unitOfWorks.Insert(new Product { Name = "测试商品002", Description = "测试商品002的描述" }, trans);
                    unitOfWorks.Insert(new User { UserName = "alice", Account = "15300153009", Pwd = "123456" }, trans);//之前已插入该记录，将引发唯一索引报错
                    unitOfWorks.Commit(trans);
                }
                catch (System.Exception)
                {
                    unitOfWorks.RollBack(trans);
                }
                var productList = unitOfWorks.GetList<Product>(t => t.Name == "测试商品002").ToList();
                Assert.True(productList.Count == 0);
            }
        }
    }
}
