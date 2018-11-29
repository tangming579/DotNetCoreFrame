using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using SqlSugar;

namespace ServiceCore.Helpers
{
    public static class CommonHelper
    {
        public static string GetConnectionString(string database)
        {
            return PublicDatas.Configuration["connectionStrings" + ":" + database];
        }

        public static DbType GetDbType(string database)
        {
            var typeStr = PublicDatas.Configuration["dataTypes" + ":" + database];
            var dbType = (DbType)Enum.Parse(typeof(DbType), typeStr);
            return dbType;
        }

        public static string GetIPAddress()
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());

            foreach (IPAddress address in ipHostInfo.AddressList)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                    return address.ToString();
            }
            return string.Empty;
        }
    }
}
