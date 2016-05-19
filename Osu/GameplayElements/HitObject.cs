using System;
using System.Linq;
using System.Reflection;
using ClassLibrary2.Helpers;
using ClassLibrary2.Osu.Enums;
using Fasterflect;

namespace ClassLibrary2.Osu.GameplayElements
{
    public class HitObject : EventArgs
    {
        public const String unkInstance = "\u0023\u003DqtVdlywU9QJFAwEKKz1jWmQ\u003D\u003D";
        public const String TypeInstance = "\u0023\u003DqQX9p0s1YHUgJSgPBx7oyaw\u003D\u003D";
        public const String StartTimeInstance = "\u0023\u003DqgKY2HiQ5DrxwT8DbSBchig\u003D\u003D";
        public const String EndTimeInstance = "\u0023\u003DqubrbLs_ESmzhKNZXFXab5A\u003D\u003D";
        public const String StackInstance = "\u0023\u003DqxZdyo0TkMAS4FccK9r7rpw\u003D\u003D";

        private static Type type;        //Obfuscated Name for Reflection
        public object sender;        //Obfuscated Name for Reflection


        public HitObjectType Type
        {
            get
            {
                return (HitObjectType) sender.GetFieldValue(TypeInstance);
            }
        }
        public int startTime
        {
            get
            {
                return (int) sender.GetFieldValue(StartTimeInstance);
            }
        }

        public int StartTime;

        public int endTime
        {
            get
            {
                return (int) sender.GetFieldValue(EndTimeInstance);
            }
        }
        public int EndTime;
        public int Duration
        {
            get { return EndTime - StartTime; }
        }

        public HitObject(object classObject)
        {
            if (classObject == null) return;

            sender = classObject;
            type = classObject.GetType();
            StartTime = startTime;
            EndTime = endTime;

            //Console.WriteLine("hitObject: {0}",this.StartTime);
            /*foreach (var memberInfo in actualType.GetMembers(BindingFlags.NonPublic | BindingFlags.Instance))  
            {
                var value = Helpers.Helper.GetValue<object>(memberInfo, actualObject);
                Console.WriteLine("Name: {0}. Value: {1} ", memberInfo.Name, value);
            }*/
        }
    }
}
