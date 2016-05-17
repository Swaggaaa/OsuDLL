using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary2.Helpers;
using ClassLibrary2.Osu.Enums;
using ClassLibrary2.Osu.GameModes.Play;
using ClassLibrary2.Osu.GameplayElements.Scoring;
using ClassLibrary2.Osu.Graphics;
using Fasterflect;

namespace ClassLibrary2.Osu
{
    internal sealed class AntiCheat : IDisposable // This class is a singleton
    {
        private static readonly object syncRoot = new Object(); // https://msdn.microsoft.com/en-us/library/ff650316.aspx
        private static AntiCheat _instance;

        public static AntiCheat Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncRoot)
                    {
                        _instance = new AntiCheat();

                    }
                }
                return _instance;
            }
        }
        public Dictionary<string, HookManager> HookDictionary = new Dictionary<string, HookManager>();

        #region ScreenshotTargetMethods

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
            return (byte[]) null;
        }

        #endregion


        #region PlayerTargetMethods

        public static void CheckFlashLightHaxTarget(object this0)
        {
            // Console.WriteLine("FBadFlags: {0} {1}", Player.BadFlags, ModManager.CurrentMods);
            return;
        }

        public static void HaxCheckTarget(object this0, bool arg)
        {
            if (this0 != null)
            {
                const string fieldName = Player.Fields.HaxCheckCount;
                var haxCheckCount = (int) this0.GetFieldValue(fieldName);
                this0.SetFieldValue(fieldName, haxCheckCount + 1);
                Console.WriteLine("H1BadFlags: {0} {1}", Player.BadFlags, haxCheckCount);
                //Player.BadFlags =0 ;
                return;

            }
            return;
        }

        #endregion


        #region GetProcesses

        private static readonly HashSet<string> ProcessesToOmit = new HashSet<string>
        {
            "devenv",
            "Skype",
            "SkypeHost",
            "slack",
            "firefox"
        };

        private static Process[] GetProcessesTarget()
        {
            Console.WriteLine("Topkeked");
            var object2 = (Process[]) Instance.HookDictionary["Process.GetProcesses"].CallOriginal(null);
            return object2.Where(p => !ProcessesToOmit.Contains(p.ProcessName)).ToArray();
            // return object2;
        }

        #endregion


        private AntiCheat()
        {
            HookDictionary["Screenshot.TakeDesktopScreenshot"] = new HookManager(Screenshot.TakeDesktopScreenshotInfo, ((Func<byte[]>)TakeDesktopScreenshotTarget).Method);
            HookDictionary["Player.CheckFlashLightHax"] = new HookManager(Player.CheckFlashLightHaxInfo, ((Action<object>)CheckFlashLightHaxTarget).Method);
            HookDictionary["Player.HaxCheck"] = new HookManager(Player.HackCheckInfo, ((Action<object, bool>)HaxCheckTarget).Method);
            HookDictionary["Process.GetProcesses"] = new HookManager(((Func<Process[]>)Process.GetProcesses).Method, ((Func<Process[]>)GetProcessesTarget).Method);
        }

        public void InstallHooks()
        {
            foreach (var hook in HookDictionary)
            {
                Console.WriteLine("Installing Hook on: {0}", hook.Key);
                hook.Value.Install();
            }
        }

        public void Dispose()
        {
            foreach (var hook in HookDictionary)
            {
                Console.WriteLine("Unstalling Hook on: {0}", hook.Key);
                hook.Value.Uninstall();
            }
            _instance = null;
        }

    }
}
