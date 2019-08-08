using DapperExtensions;
using DapperExtensions.Mapper;
using DapperExtensions.Sql;
using dooyar.models.Enums;
using MySql.Data.MySqlClient;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Reflection;

namespace dooyar.dapper
{
    public  class ConnectionFactory
    {
        public static Database CreateConnection(string connStr,DBTypes dbType = DBTypes.MySql)
        {
            Database connection = null;
            switch (dbType)
            {
                case DBTypes.SqlServer:
                    var sqlConn = new SqlConnection(connStr);
                    var sqlconfig = new DapperExtensionsConfiguration(typeof(CustomPluralizedMapper<>), new[]{typeof(Mappings).Assembly}, new SqlServerDialect());
                    var sqlGenerator = new SqlGeneratorImpl(sqlconfig);
                    connection = new Database(sqlConn, sqlGenerator);
                    break;
                case DBTypes.MySql:
                    var mysqlConn = new MySqlConnection(connStr);
                    var mysqlconfig = new DapperExtensionsConfiguration(typeof(CustomPluralizedMapper<>), new[] { typeof(Mappings).Assembly }, new MySqlDialect());
                    var mysqlGenerator = new SqlGeneratorImpl(mysqlconfig);
                    connection = new Database(mysqlConn, mysqlGenerator);
                    break;
                case DBTypes.Sqlite:
                    var sqlliteConn = new SQLiteConnection(connStr);
                    var sqlliteconfig = new DapperExtensionsConfiguration(typeof(CustomPluralizedMapper<>), new[] { typeof(Mappings).Assembly }, new SqliteDialect());
                    var sqlliteGenerator = new SqlGeneratorImpl(sqlliteconfig);
                    connection = new Database(sqlliteConn, sqlliteGenerator);
                    break;
                case DBTypes.Oracle:
                    var orcalConn = new OracleConnection(connStr);
                    var orcaleconfig = new DapperExtensionsConfiguration(typeof(CustomPluralizedMapper<>), new[] { typeof(Mappings).Assembly }, new OracleDialect());
                    var orcaleGenerator = new SqlGeneratorImpl(orcaleconfig);
                    connection = new Database(orcalConn, orcaleGenerator);
                    break;
            }
            return connection;
        }
    }

}
