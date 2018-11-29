using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceCore
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class CorePropertyAttribute : Attribute
    {
        public CorePropertyAttribute() { }

        public bool IsNullable { get; set; }
        public string Description { get; set; }
        public bool IsIgnore { get; set; }
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
