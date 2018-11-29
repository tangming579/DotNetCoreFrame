using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using ServiceCore.Helpers;

namespace ServiceCore
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
        public SqlSugar.SqlSugarClient GetDb(string connectionDb ="db_default")
        {
            var db = DbExtensionsHelper.GetInstance(connectionDb);
            return db;
        }
    }
}
