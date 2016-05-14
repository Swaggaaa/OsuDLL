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
    public interface IMember
    {
        bool IsStatic
        {
            get;
        }
    }
    //http://stackoverflow.com/questions/16073091/is-there-a-way-to-create-a-delegate-to-get-and-set-values-for-a-fieldinfo
    public class Member<T> : IMember
    {
        private MemberInfo memberInfo;
        public Type ParentType;
        public Func<object, T> GetValue;
        public Action<object, T> SetValue;
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
            switch(memberInfo0.MemberType)
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
        private Func<object, T> CreateGetter(FieldInfo field)
        {
            string methodName = field.ReflectedType.FullName + ".get_" + field.Name;
            DynamicMethod getterMethod = new DynamicMethod(methodName, typeof(T), new Type[1] { typeof(object) }, true);
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
            return (Func<object, T>)getterMethod.CreateDelegate(typeof(Func<object, T>));
        }

        private Func<object, T> CreateGetter(PropertyInfo property)
        {
            return (Func<object, T>)Delegate.CreateDelegate(typeof(Func<object, T>),
                                             property.GetGetMethod());
        }
        #endregion


        #region CreateSetter
        private Action<object, T> CreateSetter(FieldInfo field)
        {
            string methodName = field.ReflectedType.FullName + ".set_" + field.Name;
            DynamicMethod setterMethod = new DynamicMethod(methodName, null, new Type[2] { typeof(object), typeof(T) }, true);
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
            return (Action<object, T>)setterMethod.CreateDelegate(typeof(Action<object, T>));
        }

        private Action<object, T> CreateSetter(PropertyInfo property)
        {
            return (Action<object, T>)Delegate.CreateDelegate(typeof(Action<object, T>),
                                               property.GetSetMethod());
        } 
        #endregion
    }
}
