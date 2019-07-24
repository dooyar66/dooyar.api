using dooyar.dapper.Model;
using dooyar.dapper.Repository;
using System;
using System.Linq;
using Xunit;

namespace dooyar.dapper.test
{
    public class DapperRepositoryTest
    {
        private readonly IDapperRepository _dapperRepository;
        public DapperRepositoryTest()
        {
            string connStr = "Server=localhost;User Id=root;Password=123456;Database=shop_demo";
            _dapperRepository = new DapperRepository(connStr,DbType.MySql);
        }

        //[Fact]
        //public void TestExecute()
        //{
        //    string sql = "insert into Products(Name,Description) values(@Name,@Description);";
        //    int result = _dapperRepository.Execute(sql, new { Name = "华为P20", Description = "华为P20采用xxxx" });
        //    Assert.Equal(1, result);
        //}
        [Fact]
        public void Query()
        {
            string sql = "select Id,Name,Description from Products;";
            var list = _dapperRepository.Query<Product>(sql);
            Assert.Single(list);
        }
    }
}
