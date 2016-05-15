using System;
using System.Linq;
using System.Reflection;
using ClassLibrary2.Helpers;
using ClassLibrary2.Osu.Enums;

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
        private static object actualObject;        //Obfuscated Name for Reflection
        public bool IsValid
        {
            get { return actualObject != null; }
        }

        private static MemberInfo _unk;

        private int unkVar
        {
            get
            {
                if (_unk == null)
                {
                    _unk = type.GetMember(unkInstance,
                    BindingFlags.Public | BindingFlags.Instance).FirstOrDefault();
                    if (_type == null)
                    {
                        return 1;
                    }
                }
                return Helper.GetValue<int>(_unk, actualObject);
            }
        }
        public int UnkVar;


        private static MemberInfo _type;
        private HitObjectType hitObjectType
        {
            get
            {
                if (_type == null)
                {
                    _type = type.GetMember(TypeInstance,
                    BindingFlags.Public | BindingFlags.Instance).FirstOrDefault();
                    if (_type == null)
                    {
                        return HitObjectType.None;
                    }
                }
                return Helper.GetValue<HitObjectType>(_type, actualObject);
            }
        }

        public HitObjectType HitObjectType;

        private static MemberInfo _startTime;
        private int startTime
        {
            get
            {
                if (_startTime == null)
                {
                    _startTime = type.GetMember(StartTimeInstance,
                    BindingFlags.Public | BindingFlags.Instance).FirstOrDefault();
                    if (_startTime == null)
                    {
                        return -1;
                    }
                }
                return Helper.GetValue<int>(_startTime, actualObject);
            }
        }
        public int StartTime;

        private static MemberInfo _endTime;
        private int endTime
        {
            get
            {
                if (_endTime == null)
                {
                    _endTime = type.GetMember(EndTimeInstance,
                    BindingFlags.Public | BindingFlags.Instance).FirstOrDefault();
                    if (_endTime == null)
                    {
                        return -1;
                    }
                }
                return Helper.GetValue<int>(_endTime, actualObject);
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

            actualObject = classObject;
            type = classObject.GetType();

            UnkVar = unkVar;
            this.HitObjectType = hitObjectType;
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
