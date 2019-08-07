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
            /// <summary>
            /// 
            /// </summary>
            public ProductMapper()
            {
                Table("Products"); //DuPotoUsers         
                Map(t => t.Id).Column("Id").Key(KeyType.Identity); //主键类型
                //Map(Ducel => Ducel.UserName).Column("UserName");
                //Map(Ducel => Ducel.FirstName).Column("FirstName");
                //Map(Ducel => Ducel.LastName).Column("LastName");
                //Map(Ducel => Ducel.MiddleName).Column("MiddleName");
                //Map(Ducel => Ducel.EmailID).Column("EmailID");
                //Map(Ducel => Ducel.Adddate).Column("Adddate");
                AutoMap();
            }
        }
    }
}
