﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32.SafeHandles;
//using BMAPI.v1;
//using BMAPI.v1.HitObjects;
using ClassLibrary2.Helpers;
using ClassLibrary2.Osu.Audio;
using ClassLibrary2.Osu.Classes;
using ClassLibrary2.Osu.Classes.MKeyHandlers;
using ClassLibrary2.Osu.Enums;
using ClassLibrary2.Osu.Online;
using ClassLibrary2.Osu.GameModes.Play;
using ClassLibrary2.Osu.GameplayElements.Beatmaps;
using ClassLibrary2.Osu.GameplayElements.Scoring;
using ClassLibrary2.Osu.Graphics;
using ClassLibrary2.Osu;
using Fasterflect;
using ButtonState = Microsoft.Xna.Framework.Input.ButtonState;

namespace ClassLibrary2
{
    public static class Class1
    {
            [DllImport("kernel32.dll",
        EntryPoint = "GetStdHandle",
        SetLastError = true,
        CharSet = CharSet.Auto,
        CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr GetStdHandle(int nStdHandle);
        [DllImport("kernel32.dll",
            EntryPoint = "AllocConsole",
            SetLastError = true,
            CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.StdCall)]
        private static extern int AllocConsole();

        private const int STD_OUTPUT_HANDLE = -11;
        private const int MY_CODE_PAGE = 437;

        public static bool Started = false;
        private static String ah = null;

        
        static Class1()
        {
                DllMain("Constructor");
        }

        [Obfuscation]
        private static int DllMain(String pwzArgument)
        {
            if (Started)
            {
                Console.WriteLine("Second function call " + pwzArgument);
                return 1;
            }
            InitConsole();
            Console.WriteLine(pwzArgument);

            /* Console.WriteLine("Testing");
             try
             {
                 hookTest = new HookManager(typeof(Process).GetMethod("GetProcesses", new Type[] { }), typeof(ClassLibrary2.Class1).GetMethod("detourProcess", BindingFlags.Static | BindingFlags.NonPublic));
                 hookTest.CheckBytes();
                 Console.WriteLine("Install Hook");
                 hookTest.Install();
                 Console.WriteLine("Installed Hook");
                 hookTest.CheckBytes();
             }
             catch (Exception exception)
             {
                 Console.WriteLine(exception.Message);   
                 throw;
             }*/


            ah = pwzArgument;
            Started = true;
            try
            {
                //var t = new Thread(hack);
                //t.Start();
                Task.Run((Action)hack);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return 1;
        }

        public static void InitClasses()
        {
            Console.WriteLine("Loading Classes");
            try
            {
                BeatmapManager.Init();
                AudioEngine.Init();
                Class925.Init();
                Class370.Init();
                Screenshot.Init();
                //Osu.Classes.Player.Init(assembly);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            Console.WriteLine("Classes Loaded");
        }

        public const int offset = 25;

        static void InitConsole()
        {
            AllocConsole();
            IntPtr stdHandle = GetStdHandle(STD_OUTPUT_HANDLE);
            SafeFileHandle safeFileHandle = new SafeFileHandle(stdHandle, true);
            FileStream fileStream = new FileStream(safeFileHandle, FileAccess.Write);
            Encoding encoding = System.Text.Encoding.GetEncoding(MY_CODE_PAGE);
            StreamWriter standardOutput = new StreamWriter(fileStream, encoding);
            standardOutput.AutoFlush = true;
            Console.SetOut(standardOutput);
            Console.WriteLine("{0} - {1}", Process.GetCurrentProcess().MainModule.FileName, ah);
        }

        private static HookManager stringFormatHook;
        public static string OwnFormat(string stringToFormat, object arg0, object arg1, object arg2)
        {
            try
            {
                if (stringToFormat == "{1}")
                {
                    //Console.WriteLine("FODASS");
                    return arg1.ToString();
                }
               // Console.WriteLine("'{0}' '{1}' '{2}' '{3}'", stringToFormat, arg0, arg1, arg2);
                var val = (string)stringFormatHook.CallOriginal(null, stringToFormat, arg0, arg1, arg2);
                if (val.StartsWith(@"https://osu.ppy.sh/d/"))
                {
                    int pos = val.IndexOf("?u");
                    val = val.Substring(0, pos);
                    val = val.Replace("https://osu.ppy.sh", @"http://ripple.moe");
                }
                val = val.Normalize();
                //Console.WriteLine(val);
                return val;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        private static HookManager CtorHook;

        public static object ctorKek(object sender, string filename, string url)
        {
           // Console.WriteLine("{0}", sender);
            //Console.WriteLine("{0} {1}", filename, url);
            try
            {
                if (url.StartsWith(@"https://osu.ppy.sh/d/"))
                {
                   // Console.WriteLine("Starts with: {0}", url);
                    int pos = url.IndexOf("?u");
                    url = url.Substring(0, pos);
                    url = url.Replace("https://osu.ppy.sh/d", @"https://m.zxq.co");
                    url += ".osz";
                   // Console.WriteLine("{0} {1}", filename, url);

                }
                CtorHook.Uninstall();
                var val = sender.GetType().CreateInstance(filename, url);
                CtorHook.Install();
                //var val = CtorHook.CallOriginal(sender, filename, url);
                return val;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return sender;

        }

        private static  HookManager CreateWebRequestHook;

        private static HttpWebRequest CreateWebRequest(object sender)
        {
            //Console.WriteLine(sender.GetType());
            try
            {

                var url = (string)sender
    .GetFieldValue("\u0023\u003DqNGWS8qlH2PX27M7JwGE1Dg\u003D\u003D", Flags.AllMembers);

                if (url.StartsWith(@"https://osu.ppy.sh/d/"))
                {
                    Console.WriteLine("Starts with: {0}", url);
                    int pos = url.IndexOf("?u");
                    url = url.Substring(0, pos);
                    url = url.Replace("https://osu.ppy.sh/d", @"https://m.zxq.co");
                    url += ".osz";
                    Console.WriteLine("{0}", url);
                    sender
                    .SetFieldValue("\u0023\u003DqNGWS8qlH2PX27M7JwGE1Dg\u003D\u003D", url, Flags.AllMembers);
                    return WebRequest.Create(url) as HttpWebRequest;

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return (HttpWebRequest) CreateWebRequestHook.CallOriginal(sender);
        }

        private static HookManager CompleteHook;


        private static void Complete(object sender, Exception e)
        {
            if (e != null)
            {
                Console.WriteLine(e);
            }
            CompleteHook.CallOriginal(sender, e);
            return;
        }

        private static HookManager BullShitHook;
        private static void BullShit(object sender)
        {
            Console.WriteLine("Go fuck yourself bullshit function");
            return;
        }


        async static void hack()
        {

            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            Console.WriteLine("Looking for osu");
            foreach (var a in AppDomain.CurrentDomain.GetAssemblies())
            {
                Console.WriteLine(a.FullName);
                if (a.FullName.Contains("osu!,"))
                {
                    Console.Write("Found Assembly\n");
                    Global.Osu = a;
                    break;
                }
            }
            Console.WriteLine("Finished looking");

            var t = (Func<string, object, object, object, string>)String.Format;
            /*stringFormatHook = new HookManager( (((Func<string, object, object, object, string>)String.Format).Method),
                (((Func<string, object, object, object, string>)OwnFormat).Method));
            stringFormatHook.Install();*/
            Console.WriteLine("HERE COMES THE BOOM");


            try
            {
                if (Global.Osu == null)
                {
                    throw new Exception("Could not find osu! assembly");
                }
                Global.OriginalPermissions = BanchoClient.Permission;
                /*var s = Global.Osu.GetType("\u0023\u003DqF9lOzry\u002443uN7Mz3KKueq2UVAsFBN5CACqLCMJjVNbkxC2mo_QSpjwhYV0yjUud8");
                CtorHook = new HookManager(s.GetConstructors().FirstOrDefault(), ((Func<object, string, string, object>)ctorKek).Method);
                CtorHook.Install();
                foreach (var method in s.GetMethods(BindingFlags.CreateInstance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
                {
                    Console.WriteLine(method.Name);
                }*/
                var s = Global.Osu.GetType("\u0023\u003DqH68yGQ_EReUmIBPEnkIdZD\u0024jf33JdJ8aCFK8gofb7Ac\u003D");

                CreateWebRequestHook = new HookManager(s.Method("\u0023\u003Dqkx3lh2NrhIV8x0UECfx3An\u0024xe2_fqRu9oyX3ZVoKKjA\u003D"), 
                    ((Func<object, HttpWebRequest>)CreateWebRequest).Method);
                CreateWebRequestHook.Install();

                CompleteHook = new HookManager(s.Method("\u0023\u003Dqc_txPs0IWOLuyOEyikGQWA\u003D\u003D"),
                    ((Action<object, Exception>)Complete).Method);
                CompleteHook.Install();

                BullShitHook = new HookManager(s.Method("\u0023\u003DqPvYEtTTvu6tgnGLCZ_l8QNgIHSkamAySHSNBbKC5V7w\u003D"),
                    ((Action<object>)BullShit).Method);
                BullShitHook.Install();

                Score.Hook();

                //ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
                BanchoClient.Permission |= Permissions.Supporter;

                AntiCheat.Instance.InstallHooks();
                Player.HookMethods();
                Player.OnLoadCompleteEvent += Hack.Relax.OnLoadComplete;
                InitClasses();
                Global.InterProcess = new InterProcessOsu();
                /*while (true)
                {
                    var mode = (OsuModes)Global.InterProcess.GetCurrentMode.Invoke(Global.InterProcess.ClassObject, null);

                    switch (mode)
                    {
                        case OsuModes.Play:
                            Console.WriteLine("Play");
                            Thread.Sleep(100);

                            try
                            {
                                /*
                                using (var player = new Player())
                                {
                                    if (player.IsValid && player.HitObjectManager0.IsValid)
                                    {

                                        var list = player.HitObjectManager0.HitObjects;
                                        Console.WriteLine("HitObject Count: {0}", list.Count);
                                        if (list.Count > 0)
                                        {
                                            var relax =
                                                new Hack.Relax(
                                                    new Beatmap(
                                                        BeatmapManager.GetCurrentBeatmap.Invoke(null, null), list),
                                                    offset);
                                            relax.Run();
                                            // BanchoClient.Permission |= Permissions.Supporter;
                                        }
                                        else
                                        {
                                            Thread.Sleep(500);
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("played invalid or hitobject isnvalid");
                                    }

                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.ToString());
                            }


                            //Console.WriteLine("Playing");

                            /*var beatmap =
                                new Osu.Classes.Beatmap(Osu.Classes.BeatmapManager.GetCurrentBeatmap.Invoke(null, null), c);
                            var osu = Process.GetCurrentProcess();
                            var path = osu.MainModule.FileName.Replace(osu.MainModule.ModuleName, "") + 
                                "Songs\\" + beatmap.Folder + "\\" + beatmap.FileName;
                            Console.WriteLine("Loading: {0}", path);
                            PlayBeatmap(new Beatmap(path), interProcessOsu);
                            //Osu.Classes.Player.ActiveRelax = true;
                            //Osu.Classes.Player.ActiveRelax2 = true;
                            break;
                        case OsuModes.Exit:
                            return;
                    }
                    Thread.Sleep(50);
                }*/
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return;
        }
        
    }
}
