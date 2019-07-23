using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using MySql.Data.MySqlClient;

namespace dooyar.dapper
{
    public  class ConnectionFactory
    {
        public static IDbConnection CreateConnection(string connStr,DbType dbType = DbType.MySql)
        {
            IDbConnection dbConnection;
            switch (dbType)
            {
                case DbType.SqlServer:
                    dbConnection = new SqlConnection(connStr);
                    break;
                case DbType.MySql:
                    dbConnection = new  MySqlConnection(connStr);
                    break;
                //case DbType.Oracle:
                //    break;
                default:
                    dbConnection = new MySqlConnection(connStr);
                    break;
            }
            return dbConnection;
        }
    }

    public enum DbType
    {
        Invalid,
        [Description("sql数据库")]
        SqlServer = 1,
        [Description("mysql数据库")]
        MySql = 2,
        [Description("Oracle数据库")]
        Oracle = 3
    }
}
