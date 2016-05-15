using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary2.Helpers;

namespace ClassLibrary2.Osu.Graphics
{
    public static class Screenshot
    {
        public const String ClassName = "\u0023\u003Dq9kuZAhBjpwaIdJRoNa4r9yqVMbiHH6PQP2dcbV5WBzs\u003D";

        public struct Instances
        {

        }

        public struct Methods
        {
            public const String TakeDesktopScreenshot = "\u0023\u003DqLp_KRsaIEV6vO6n\u002427EHX33lL2C4wHnXV2R_PywbI1I\u003D"; //internal static byte[]
        }

        private static Type type;        //Obfuscated Name for Reflection

        #region TakeDesktopScreenshot
        internal static HookManager TakeDesktopScreenshotHook;

        public static byte[] TakeDesktopScreenshotTarget()
        {
            Console.WriteLine("ScreenShot Rekt");
            Console.WriteLine("ScreenShot Rekt");
            Console.WriteLine("ScreenShot Rekt");
            Console.WriteLine("ScreenShot Rekt");
            Console.WriteLine("ScreenShot Rekt");
            Console.WriteLine("ScreenShot Rekt");
            Console.WriteLine("ScreenShot Rekt");
            Console.WriteLine("ScreenShot Rekt");
            Console.WriteLine("ScreenShot Rekt");
            Console.WriteLine("ScreenShot Rekt");
            Console.WriteLine("ScreenShot Rekt");
            Console.WriteLine("ScreenShot Rekt");
            Console.WriteLine("ScreenShot Rekt");
            return (byte[])null;
        }
        #endregion

        public static void Init()
        {
            type = Global.Osu.GetType(ClassName);
            var takeDesktopScreenshot = type.GetMethod(Methods.TakeDesktopScreenshot, BindingFlags.NonPublic | BindingFlags.Static);
            TakeDesktopScreenshotHook = new HookManager(takeDesktopScreenshot, ((Func<byte[]>)TakeDesktopScreenshotTarget).Method);

        }

        public static void InstallHooks()
        {
            Console.WriteLine("Detouring Screenshotter");
            TakeDesktopScreenshotHook.Install();
        }
    }
}
