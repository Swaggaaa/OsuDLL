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
        private static IDictionary<string, Type> cachedTypes = new ConcurrentDictionary<string, Type>();
        private static IDictionary<string, IMember> cachedMemberInfo = new ConcurrentDictionary<string, IMember>();

        public static Type GetTypeCache(this Assembly assembly, string className)
        {
            string key;
            StringBuilder sb = new StringBuilder();
            if (assembly != null)
            {
                sb.Append(assembly.GetName().Name);
            }
            sb.Append('.'); sb.Append(className);
            Type classType;
            if (cachedTypes.TryGetValue(sb.ToString(), out classType))
            {
                return classType;
            }

            classType = assembly == null ? Type.GetType(className) : assembly.GetType(className);
            if (classType == null)
            {
                throw new Exception("Given class not found");
            }
            cachedTypes.Add(sb.ToString(), classType);
            return classType;
        }

        public static void CacheMember<S, T>(this Type type, string memberName)
        {
            string key = String.Join(".", type.ToString(), memberName);// type.FullName + "." + memberName;
            if (cachedMemberInfo.ContainsKey(key))
            {
                return;
            }

            var memberInfo = type.GetMember(memberName).FirstOrDefault();
            if (memberInfo == null)
            {
                throw new Exception("Could not find given member");
            }
            var member = new Member<S, T>(memberInfo, type);
            cachedMemberInfo.Add(key, member);
        }

        public static T GetValue<S, T>(this Type type, string memberName, object thisObject = null)
        {

            type.CacheMember<S, T>(memberName);

            var member = cachedMemberInfo[type.FullName + "." + memberName];
            //return (T)(((FieldInfo)((Member<S,T>)member).memberInfo).GetValue(thisObject));
            return ((Member<S, T>)member).GetValue((S)thisObject);
        }

        public static void SetValue<S, T>(this Type type, string memberName, T value, object thisObject = null)
        {
            type.CacheMember<S, T>(memberName);

            var member = cachedMemberInfo[type.FullName + "." + memberName];
            ((Member<S, T>)member).SetValue((S)thisObject, value);

        }
    }
