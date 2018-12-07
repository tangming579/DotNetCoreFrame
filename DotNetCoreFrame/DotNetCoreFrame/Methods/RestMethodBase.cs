using DotNetCoreFrame.Common;
using Newtonsoft.Json.Linq;
using ServiceCore.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreFrame.Methods
{
    public abstract class RestMethodBase
    {
        private string methodName;
        public string MethodName
        {
            get
            {
                if (string.IsNullOrEmpty(methodName))
                    methodName = this.GetType().Name;
                return methodName;
            }
        }

        public abstract JToken ExecuteMethod(JToken criteria);

        public JObject GetDefaultRet()
        {
            var retVal = new JObject();
            retVal[Constants.Result] = Constants.Failed;
            return retVal;
        }
        public SqlSugar.SqlSugarClient GetDb(string connectionDb = "db_default")
        {
            var db = DbExtensionsHelper.GetInstance(connectionDb);
            return db;
        }
    }
}
