using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Reflection
{
    static class ReflectionCache
    {
        private static Dictionary<string, Type> cachedTypes; 
        private static Dictionary<string, IMember> cachedMemberInfo;

        public static Type GetTypeCache(this Assembly assembly, string className)
        {
            string key = assembly.FullName + "." + className;
            if (cachedTypes.ContainsKey(key))
            {
                return cachedTypes[key];
            }

            var type = assembly.GetType(className);
            if(type != null)
            {
                throw new Exception("Given class not found");
            }
            cachedTypes.Add(key, type);
            return type;
        }

        public static void CacheMember<T> (this Type type, string memberName)
        {
            string key = type.FullName + "." + memberName;
            if (cachedMemberInfo.ContainsKey(key))
            {
                return;
            }

            var memberInfo = type.GetMember(memberName).FirstOrDefault();
            if (memberInfo == null)
            {
                throw new Exception("Could not find given member");
            }
            var member = new Member<T>(memberInfo, type);
            cachedMemberInfo.Add(key, member);
        }
        public static T GetValue<T>(this Type type, string memberName, object thisObject = null) 
        {
            type.CacheMember<T>(memberName);
            
            var member = cachedMemberInfo[type.FullName + "." + memberName];
            return ((Member<T>)member).GetValue(thisObject);
        }

        public static void SetValue<T>(this Type type, string memberName, T value, object thisObject = null)
        {
            type.CacheMember<T>(memberName);

            var member = cachedMemberInfo[type.FullName + "." + memberName];
            ((Member<T>)member).SetValue(thisObject, value);

        }

    }
}
