using System;
using System.Reflection;
using ClassLibrary2.Helpers;
using ClassLibrary2.Osu.Enums;

namespace ClassLibrary2.Osu.Classes
{
    public class InterProcessOsu
    {
        public object ClassObject;
        public InterProcessOsu()
        {
            var oType = Global.Osu.GetType("osu.Helpers.InterProcessOsu");
            ClassObject = Activator.CreateInstance(oType);
            WakeUp = oType.GetMethod("WakeUp");
            Quit = oType.GetMethod("Quit");
            GetCurrentMode =  oType.GetMethod("GetCurrentMode");
            GetSpectatingId =  oType.GetMethod("GetSpectatingId");

        }

        public bool IsPlaying()
        {
            var mode = (OsuModes)GetCurrentMode.Invoke(ClassObject, null);
            return mode == OsuModes.Play;

        }

        public MethodInfo WakeUp;
        public MethodInfo Quit;
        public MethodInfo GetCurrentMode;
        public MethodInfo GetSpectatingId;
    }
}
