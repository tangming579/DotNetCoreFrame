using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceCore.Extensions
{
    public static class EnumExtension
    {
        /// <summary>
        /// 获取枚举常数的名称。
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static string GetName(this Enum e)
        {
            string ret = Enum.GetName(e.GetType(), e);
            return ret;
        }
        /// <summary>
        /// 将枚举转换为 int 类型。
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static int ToInt32(this Enum e)
        {
            int ret = Convert.ToInt32(e);
            return ret;
        }
    }
}
