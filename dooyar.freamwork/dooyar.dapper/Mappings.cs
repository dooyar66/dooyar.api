using DapperExtensions.Mapper;
using dooyar.models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace dooyar.dapper
{
    public static class Mappings
    {
        public class ProductMapper : ClassMapper<Product>
        {
            public ProductMapper()
            {
                Table("Products");         
                Map(t => t.Id).Column("Id").Key(KeyType.Identity); //主键类型
                AutoMap();
            }
        }

        public class UserMapper : ClassMapper<User>
        {
            public UserMapper()
            {
                Table("Users");       
                Map(t => t.Id).Column("Id").Key(KeyType.Identity); //主键类型
                Map(t => t.UserName).Column("user_name");
                AutoMap();
            }
        }
    }
}
