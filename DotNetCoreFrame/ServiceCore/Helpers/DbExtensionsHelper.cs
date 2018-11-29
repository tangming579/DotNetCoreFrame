using System;
using System.Collections.Generic;
using System.Text;
using SqlSugar;

namespace ServiceCore.Helpers
{
    public static class DbExtensionsHelper
    {
        public static SqlSugarClient GetInstance(string connectionDb = "db_default")
        {
            var ConnectionString = CommonHelper.GetConnectionString(connectionDb);
            var dbType = CommonHelper.GetDbType(connectionDb);
            var db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = ConnectionString,
                DbType = dbType,
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.Attribute
            });
            db.Ado.IsEnableLogEvent = true;
            db.Ado.LogEventStarting = (sql, pars) =>
            {
                Console.WriteLine(sql + "\r\n" + db.RewritableMethods.SerializeObject(pars));
                Console.WriteLine();
            };
            return db;
        }
    }
}
