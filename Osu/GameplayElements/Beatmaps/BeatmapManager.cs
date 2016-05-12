using System;
using System.Linq;
using System.Reflection;
using ClassLibrary2.Helpers;

namespace ClassLibrary2.Osu.GameplayElements.Beatmaps
{
    static class BeatmapManager //class1274
    {

        public static String ClassName = "\u0023\u003DqVcCVm8f96\u0024o5uKQDK7Lec_aGXOx6idDh8pihPm_nn43W4cnQ9X4JhAjhaA5WK1oN";
        //Members
        //public static String currentBeatMap = "\u0023\u003DqGFsRldoLa9LVFRXsJjNgkw\u003D\u003D";

        //Methods
        public static String CurrentBeatmapMethod = "\u0023\u003DqgyWBZYX9JBizxOQPvK8A7A\u003D\u003D";


        private static Type type;

        public static String Beatmap0Instance = "\u0023\u003DqPwK9UwaIwuCjfVv\u0024ilB5wg\u003D\u003D";
        private static MemberInfo _currentBeatmap0;
        public static object CurrentBeatmap0
        {
            get
            {
                if (_currentBeatmap0 == null)
                {
                    _currentBeatmap0 = type.GetMember(Beatmap0Instance,
                        BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).FirstOrDefault();
                    if (_currentBeatmap0 == null)
                    {
                        return -1;
                    }
                }
                return Helper.GetValue<object>(_currentBeatmap0, null);
            }
        }

        public static void Init()
        {
            type = Global.Osu.GetType(ClassName);
            GetCurrentBeatmap = type.GetMethod(CurrentBeatmapMethod, BindingFlags.NonPublic | BindingFlags.Static);
        }

        public static MethodInfo GetCurrentBeatmap;

    }
}
