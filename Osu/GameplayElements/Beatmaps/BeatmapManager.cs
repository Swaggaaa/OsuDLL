using System;
using System.Linq;
using System.Reflection;
using ClassLibrary2.Helpers;

namespace ClassLibrary2.Osu.GameplayElements.Beatmaps
{
    static class BeatmapManager //class1274
    {

        public static String ClassName = "\u0023\u003DqlqRriC_uvERTBApxxSjfjRX3tAMhvJd5Pruq5_O51suGtY6xTzez8tjn0aotcg02";
        //Members
        //public static String currentBeatMap = "\u0023\u003DqGFsRldoLa9LVFRXsJjNgkw\u003D\u003D";

        //Methods
        struct Methods
        {
            //public const String DatabaseSerialize = "\u0023\u003Dqn32KQ5r\u0024MA2Mllut29c1zXP3lSYV3dJLSOH5wF7XfBQ\u003D";
            public const String CurrentBeatmap = "\u0023\u003DqjC\u0024BX0mXG5znGpS65nNNkw\u003D\u003D";
        }


        private static Type type;

        public static String Beatmap0Instance = "\u0023\u003Dqxfn\u00243evVf9ot53ih2t5\u00242Q\u003D\u003D";
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
            GetCurrentBeatmap = type.GetMethod(Methods.CurrentBeatmap, BindingFlags.NonPublic | BindingFlags.Static);
        }

        public static MethodInfo GetCurrentBeatmap;

    }
}
