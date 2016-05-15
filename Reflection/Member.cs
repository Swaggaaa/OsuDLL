using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Reflection.Emit;

namespace ClassLibrary2.Reflection
{
    //Ghetto
    internal interface IMember
    {
        bool IsStatic
        {
            get;
        }
    }
    //http://stackoverflow.com/questions/16073091/is-there-a-way-to-create-a-delegate-to-get-and-set-values-for-a-fieldinfo
    internal class Member<S, T> : IMember
    {
        public MemberInfo memberInfo;
        public Type ParentType;
        public Func<S, T> GetValue;
        public Action<S, T> SetValue;
        public bool IsStatic
        {
            get
            {
                return ((FieldInfo)memberInfo).IsStatic;
            }
        }
        public Member(MemberInfo memberInfo0, Type parentType)
        {
            this.memberInfo = memberInfo0;
            ParentType = parentType;
            Console.WriteLine("S:{0} T:{1} Parent: {2}", typeof(S), typeof(T), parentType);
            switch (memberInfo0.MemberType)
            {
                case System.Reflection.MemberTypes.Field:
                    GetValue = CreateGetter((FieldInfo)memberInfo0);
                    SetValue = CreateSetter((FieldInfo)memberInfo0);
                    break;
                case System.Reflection.MemberTypes.Property:
                    GetValue = CreateGetter((PropertyInfo)memberInfo0);
                    SetValue = CreateSetter((PropertyInfo)memberInfo0);
                    break;
                default:
                    throw new Exception("Member Info is not of type FieldInfo or PropertyInfo");
                    break;
            }
        }

        #region CreateGetter
        private Func<S, T> CreateGetter(FieldInfo field)
        {
            /*string methodName = field.ReflectedType.FullName + ".get_" + field.Name;
            DynamicMethod getterMethod = new DynamicMethod(methodName, typeof(T), new Type[1] { typeof(S) }, true);
            ILGenerator gen = getterMethod.GetILGenerator();
            if (field.IsStatic)
            {
                gen.Emit(OpCodes.Ldsfld, field);
            }
            else
            {
                gen.Emit(OpCodes.Ldarg_0);
                gen.Emit(OpCodes.Ldfld, field);
            }
            gen.Emit(OpCodes.Ret);
            return (Func<S, T>)getterMethod.CreateDelegate(typeof(Func<S, T>));*/
            Console.WriteLine(memberInfo.ReflectedType);

            var instExp = Expression.Parameter(typeof(S));
            var castToType = Expression.Convert(instExp, ParentType);
            var fieldExp = Expression.Field(castToType, field);
            var CastToRealType = Expression.Convert(fieldExp, typeof(T));

            return Expression.Lambda<Func<S, T>>(CastToRealType, instExp).Compile();
            //return (Func<S, T>)Delegate.CreateDelegate(typeof(Func<S, T>), field.??);
        }

        private Func<S, T> CreateGetter(PropertyInfo property)
        {
            return (Func<S, T>)Delegate.CreateDelegate(typeof(Func<S, T>),
                                             property.GetGetMethod());
        }
        #endregion


        #region CreateSetter
        private Action<S, T> CreateSetter(FieldInfo field)
        {
            string methodName = field.ReflectedType.FullName + ".set_" + field.Name;
            DynamicMethod setterMethod = new DynamicMethod(methodName, null, new Type[2] { typeof(S), typeof(T) }, true);
            ILGenerator gen = setterMethod.GetILGenerator();
            if (field.IsStatic)
            {
                gen.Emit(OpCodes.Ldarg_1);
                gen.Emit(OpCodes.Stsfld, field);
            }
            else
            {
                gen.Emit(OpCodes.Ldarg_0);
                gen.Emit(OpCodes.Ldarg_1);
                gen.Emit(OpCodes.Stfld, field);
            }
            gen.Emit(OpCodes.Ret);
            return (Action<S, T>)setterMethod.CreateDelegate(typeof(Action<S, T>));
        }

        private Action<S, T> CreateSetter(PropertyInfo property)
        {
            return (Action<S, T>)Delegate.CreateDelegate(typeof(Action<S, T>),
                                               property.GetSetMethod());
        }
        #endregion
    }
}
