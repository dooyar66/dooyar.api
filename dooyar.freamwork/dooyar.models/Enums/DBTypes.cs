using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace dooyar.models.Enums
{
    public enum DBTypes
    {
        Invalid,
        [Description("sql数据库")]
        SqlServer = 1,
        [Description("mysql数据库")]
        MySql = 2,
        [Description("Sqlite数据库")]
        Sqlite = 3,
        [Description("Oracle数据库")]
        Oracle = 4
    }

}
