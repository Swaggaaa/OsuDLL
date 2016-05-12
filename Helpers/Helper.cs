using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Helpers
{
    public static class Helper
    {
        public static T GetValue<T>(MemberInfo member, object classObject = null)
        {
            object value = null;
            switch (member.MemberType)
            {
                case System.Reflection.MemberTypes.Field:
                    value = ((System.Reflection.FieldInfo)member).GetValue(classObject);
                    break;
                case System.Reflection.MemberTypes.Property:
                    value = ((System.Reflection.PropertyInfo)member).GetValue(classObject, null);
                    break;
            }
            return (T)value;
        }
        public static void SetValue(MemberInfo member, object value,  object classObject = null)
        {
            switch (member.MemberType)
            {
                case System.Reflection.MemberTypes.Field:
                     ((System.Reflection.FieldInfo)member).SetValue(classObject, value);
                    break;
                case System.Reflection.MemberTypes.Property:
                    ((System.Reflection.PropertyInfo)member).SetValue(classObject, value);
                    break;
            }
        }
    }
}
