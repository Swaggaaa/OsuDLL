using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary2.Helpers;
using Fasterflect;

namespace ClassLibrary2.Osu.Graphics
{
    public static class Screenshot
    {
        public const String ClassName = "\u0023\u003Dqb8P_\u0024avevToHFVHXyr_l3_Cxn7Vdu2F1g4OFlht27sY\u003D";

        public struct Members
        {

        }

        public struct Methods
        {
            //Removed from game after drama
            public const String TakeDesktopScreenshot = "\u0023\u003DqLp_KRsaIEV6vO6n\u002427EHX33lL2C4wHnXV2R_PywbI1I\u003D"; //internal static byte[]
        }

        private static Type type;
        public static Type Type
        {
            get
            {
                if (type == null)
                {
                    type = Global.Osu.GetType(ClassName);
                }
                return type;
            }   
        }        //Obfuscated Name for Reflection

        public static MethodInfo TakeDesktopScreenshotInfo
        {
            get
            {
                var value = Type.Method(Methods.TakeDesktopScreenshot);
                return Type.Method(Methods.TakeDesktopScreenshot, Flags.StaticAnyVisibility); //This is cached
            }
        }
        public delegate byte[] TakeDesktopScreenshotDelegate(); //Keep or remove?
        public static TakeDesktopScreenshotDelegate TakeDesktopScreenshot;



        public static void Init()
        {
            //TakeDesktopScreenshot = (TakeDesktopScreenshotDelegate)Delegate.CreateDelegate(typeof (TakeDesktopScreenshotDelegate), TakeDesktopScreenshotInfo);

        }
    }
}
