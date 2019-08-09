using DapperExtensions.Mapper;
using System;

namespace dooyar.dapper
{
    public class CustomPluralizedMapper<T> : PluralizedAutoClassMapper<T> where T : class
    {
        public override void Table(string tableName)
        {
            if (tableName.Equals("Product", StringComparison.CurrentCultureIgnoreCase))
            {
                TableName = "Products";
            }

            base.Table(tableName);
        }
    }
}
