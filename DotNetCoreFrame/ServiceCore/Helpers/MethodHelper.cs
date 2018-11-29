using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Newtonsoft.Json.Linq;

namespace ServiceCore.Helpers
{
    public class MethodHelper
    {
        //如果对象中某个属性没有被标记为可空但是是空值，则返回
        public static CoreMessage EmsOperateCheck<T>(T t) where T : class
        {
            var msg = new CoreMessage();
            var type = t.GetType();
            foreach (var propertyInfo in type.GetProperties())
            {
                var attribute = propertyInfo.GetCustomAttribute<CorePropertyAttribute>();
                if ((attribute == null || !attribute.IsNullable) &&
                    string.IsNullOrWhiteSpace(propertyInfo.GetValue(t) + ""))
                {
                    msg.Message = $"{propertyInfo.Name}不能为空！";
                    return msg;
                };
            }
            msg.IsSuccess = true;
            return msg;
        }
        //对象中的值和前台传过来的参数对比，找出变化的属性————目前还不完善
        public static JObject GetChangeProperties<T>(T newData, T originalData) where T : class
        {
            var obj = new JObject();
            var originalProperties = originalData.GetType().GetProperties();
            var newProperties = newData.GetType().GetProperties();
            foreach (var propertyInfo in originalProperties)
            {
                var item = newProperties.FirstOrDefault(x => string.Equals(x.Name, propertyInfo.Name));
                if (item == null) continue;
                var newDataValue = item.GetValue(newData);
                var originalDataValue = propertyInfo.GetValue(originalData);
                if (string.Equals(newDataValue, originalDataValue)) continue;
                obj[propertyInfo.Name] = newDataValue + "";
            }
            return obj;
        }


    }

    public class CoreMessage
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }
    }
}
