using dooyar.ef;
using dooyar.models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace dooyar.dapper.test
{

    public class EFUnitOfWorksTest
    {
        private readonly string connStr = "Server=localhost;User Id=root;Password=123456;Database=shop_demo";
        [Fact]
        public void TestInsert()
        {
            using (var unitOfWorks = new EFUnitOfWorks(connStr))
            {
               // var result = unitOfWorks.Insert(new Product { Name = "测试商品003", Description = "测试商品003的描述" });
                var result = unitOfWorks.Insert(new User { UserName = "lucy", Account = "15300153005", Pwd = "123456" });            
                Assert.True(result);               
            }
        }

        [Fact]
        public void TestTrans()
        {
            using (var unitOfWorks = new EFUnitOfWorks(connStr))
            {
                var trans = unitOfWorks.BeginTransaction();
                try
                {

                    unitOfWorks.Insert(new Product { Name = "测试商品004", Description = "测试商品004的描述" });
                    unitOfWorks.Insert(new User { UserName = "lily", Account = "15300153005", Pwd = "123456" });//之前已插入该记录，将引发唯一索引报错
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
