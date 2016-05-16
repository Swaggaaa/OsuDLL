using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using ClassLibrary2.Helpers;
using ClassLibrary2.Osu.Enums;
using Fasterflect;

namespace ClassLibrary2.Osu.GameplayElements.Scoring
{
    class ModManager //Class 129
    {
        public static String ClassName = "\u0023\u003DqW\u0024aXrDCVn2EqZL9WJ7UAI8x4GkP_aLJs_UX9w7ZUtVmvqMwlp7YXp2KlmRZRBVK9";

        private static Type type;        //Obfuscated Name for Reflection

        public static String ModsInstance = "\u0023\u003DqqQ_yLdFbeEbzu8hQoO1h_g\u003D\u003D";
        private static MemberInfo _mods;

        private static T test<T>(object this0)
        {
            Console.WriteLine("Test Function");
            var value = this0.CallMethod(null, "\u0023\u003DqPopUZdt\u0024MElxJY8Yofx32Q\u003D\u003D");
            Console.WriteLine("test1: {0} test2: {1}", value,
                (T)value);
            return (T)value;
        }
        public static object CurrentModsRaw
        {
            get
            {
                if (_mods == null)
                {
                    _mods = type.GetMember(ModsInstance,
                        BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).FirstOrDefault();
                    if (_mods == null)
                    {
                        return null;
                    }
                }
                
                var value = Helper.GetValue<object>(_mods, null);
                test<Mods>(value);
                return value;
            }
        }
        public static Mods CurrentMods
        {
            get
            {
                return (Mods)Enum.Parse(typeof(Mods), CurrentModsRaw.ToString());
            }

        }

        public static void Init()
        {
            type = Global.Osu.GetType(ClassName);
            /*foreach (var memberInfo in type.GetMembers(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
            {
                var value = Helper.GetValue<object>(memberInfo, null);
                Console.WriteLine("Name {0} Value: {1}", memberInfo.Name, value);
            }*/
            _mods = type.GetMember(ModsInstance, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).FirstOrDefault();
        }
    }
}
