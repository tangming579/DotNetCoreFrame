using DotNetCoreFrame.Methods;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DotNetCoreFrame.Common
{
    public delegate JToken ExecuteMethod(JToken criteria);

    public static class RestmethodManager
    {
        public static Dictionary<string, ExecuteMethod> dic { get; private set; }

        public static void Load()
        {
            dic = new Dictionary<string, ExecuteMethod>();
            Type tp = typeof(RestMethodBase);
            var types = tp.GetTypeInfo().Assembly.GetTypes().Where(x => x.GetTypeInfo().BaseType == tp).ToList();
            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type) as RestMethodBase;
                if (instance == null) continue;
                var attribute = type.GetTypeInfo().GetCustomAttribute<MethodRestAttribute>();
                var methodName = attribute == null ? instance.MethodName : attribute.MethodName;
                if (dic.ContainsKey(methodName)) continue;
                dic.Add(methodName, instance.ExecuteMethod);
            }
        }
    }
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class MethodRestAttribute : Attribute
    {
        private string methodName;
        public MethodRestAttribute(string methodName)
        {
            this.methodName = methodName;

        }
        public string MethodName { get { return methodName; } }
    }
}
