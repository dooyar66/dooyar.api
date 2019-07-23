using dooyar.dapper.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace dooyar.dapper.test
{
    public class ProductRepositoryTest
    {
        private readonly IProductRepository _productRepository;
        public ProductRepositoryTest()
        {
            string connStr = "Server=localhost;User Id=root;Password=123456;Database=shop_demo";
            _productRepository = new ProductRepository(connStr, DbType.MySql);
        }

        [Fact]
        public void Insert()
        {
           int result =  _productRepository.Insert(new Model.Product { Name = "苹果笔记本Mac BookAir", Description = "苹果笔记本Mac BookAir xxx" });
            Assert.Equal(1, result);

        }

        [Fact]
        public void Get()
        {
          var product = _productRepository.Get(1);
            Assert.NotNull(product);
        }
    }
}
