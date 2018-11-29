using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceCore.Extensions
{
    public static class JsonExtension
    {
        public static bool IsNullOrEmpty(this JToken token)
        {
            return (token == null) ||
                (token.Type == JTokenType.Array && !token.HasValues) ||
                (token.Type == JTokenType.Object && !token.HasValues) ||
                (token.Type == JTokenType.String && token.ToString() == string.Empty) ||
                (token.Type == JTokenType.Null);
        }
        /// <summary>
        /// 命名规则转换
        /// </summary>
        /// <param name="token"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static JToken GetToken(this JToken token, string key)
        {
            // TODO 命令规则替换
            var rst = token.SelectToken(key);
            if (rst == null)
            {
                var newKey = string.Concat(key.Substring(0, 1).ToLower(), key.Substring(1, key.Length - 1));
                rst = token.SelectToken(newKey);
            }
            return rst;
        }

        public static T GetValue<T>(this JToken token, string key)
        {
            if (token == null) return default(T);
            var tk = token.SelectToken(key);
            if (tk.IsNullOrEmpty())
                return default(T);
            return tk.ToObject<T>();
        }
        /// <summary>
        /// 将Json字符串转换为对象
        /// </summary>
        /// <param name="json">Json字符串</param>
        public static T ToObject<T>(this string json)
        {
            if (string.IsNullOrWhiteSpace(json))
                return default(T);
            return JsonConvert.DeserializeObject<T>(json);
        }

        /// <summary>
        /// 将对象转换为Json字符串
        /// </summary>
        /// <param name="target">目标对象</param>
        public static string ToJson(this object target)
        {
            if (target == null)
                return "{}";
            var result = JsonConvert.SerializeObject(target);
            return result;
        }

        public static JArray AddRange(this JArray list, JArray items)
        {
            if (list == null) list = new JArray();
            if (items.IsNullOrEmpty()) return list;
            foreach (var item in items)
            {
                if (item.IsNullOrEmpty()) continue;
                list.Add(item);
            }

            return list;
        }
    }
}
