using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Fasterflect;

namespace ClassLibrary2.Osu.Helpers
{
    class ObfuscatedValue<T>
    {
        private const string GetMethod = "\u0023\u003DqPopUZdt\u0024MElxJY8Yofx32Q\u003D\u003D";
        private const string SetMethod = "\u0023\u003Dq4II3BhqaH310bQ3TR0JAuA\u003D\u003D";

        public object this0;
        public ObfuscatedValue(object this0)
        {
            SetValueInfo = this0.GetType().GetMethod(SetMethod, BindingFlags.Public | BindingFlags.Instance);
            Console.WriteLine("{0}.{1}", this0.GetType(), SetValueInfo.Name);
            this.this0 = this0;
        }

        public T GetValue()
        {
            return (T)this0.CallMethod(null, GetMethod);
        }

        //Fasteflct is bugged for public void Obfuscated<T>.SetValue(T v)
        private MethodInfo SetValueInfo = null; 
        public void SetValue(T value)
        {
            SetValueInfo.Call(this0, value);
            //this0.CallMethod(GetMethod, new Type[] {this0.GetType()}, value);
        }
    }
}
