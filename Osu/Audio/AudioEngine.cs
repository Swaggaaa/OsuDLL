using System;
using System.Linq;
using System.Reflection;
using ClassLibrary2.Helpers;

namespace ClassLibrary2.Osu.Audio
{
    static class AudioEngine //Class 645
    {
        public static String ClassName = "\u0023\u003DqH01_Zh1vfg_VhY1YnCESaMCGCxGa\u0024dEgSKvbVBF_KkI\u003D";
        public static String CurrentTimeInstance = "\u0023\u003DqKcLj5u_KO7gXi93_EzFeuQ\u003D\u003D";

        private static Type type;        //Obfuscated Name for Reflection
        private static object actualObject;        //Obfuscated Name for Reflection

        private static MemberInfo _currentTime;
        public static int Time
        {
            get
            {
                if (_currentTime == null)
                {
                    _currentTime = type.GetMember(CurrentTimeInstance, 
                        BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).FirstOrDefault();
                    if (_currentTime == null)
                    {
                        return -1;
                    }
                }
                return Helper.GetValue<int>(_currentTime, null);
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
            _currentTime = type.GetMember(CurrentTimeInstance, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).FirstOrDefault();
        }
    }
}
