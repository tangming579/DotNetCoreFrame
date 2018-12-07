using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreFrame.Common
{
    public class ConstsConf
    {
        public static string WWWRootPath = "";

        public static string MainDataPath = "MainData.json";

        public const string ConnectionStrings = "connectionStrings";
        public const string dataTypes = "dataTypes";
        public static class DataBase
        {
            public const string wanda = "wanda_demo";
            public const string wanda_BimComponent = "wanda_BimComponent";
        }
    }
}
