using System;
using System.Linq;
using System.Reflection;
using ClassLibrary2.Helpers;
using ClassLibrary2.Helpers.ClassLibrary2;
using ClassLibrary2.Osu.Enums;
using ClassLibrary2.Osu.GameplayElements;
using ClassLibrary2.Osu.GameplayElements.Scoring;

namespace ClassLibrary2.Osu.GameModes.Play
{
    //Beatmap Class -> PlayModes.Osu 1k
    //Remember has  anti hax
    class Player : IDisposable
    {
        public const String ClassName = "\u0023\u003DqJOMMiVfXoKIKzCijFD0e1LPJiJCYikVcbnfexQ3_ueU\u003D";

        public struct Instances
        {
            public const String player = "\u0023\u003DqbW6U0wGbJEI7G4XkW5s70A\u003D\u003D";
            public const String hitObjectManager = "\u0023\u003DqP7N9vjLG9aQ7RbwgKXCa4tk4WyO5VNRSruo5WWPR0OA\u003D";
            public const String RelaxActive = "\u0023\u003DqrQzHW7AFskWPCYLOGV9mUw\u003D\u003D";
            public const String Relax2Active = "\u0023\u003Dq2e6Wqswux2IZfO98e1r1gA\u003D\u003D";
            public const String BadFlags = "\u0023\u003DqfhXu7CKFrOWNlffGKHD_xA\u003D\u003D";
            public const String HaxCheckCount = "\u0023\u003Dqvm3yXMmUs5JK7WvfV1wOrQ\u003D\u003D";
        }

        public struct Methods
        {
            public const String CheckFlashLightHax = "\u0023\u003Dqs4Kl4qjkJXjyL5WEDJP3OI2iWuR\u0024P83rRSqPYzleoEI\u003D"; //Private void
            public const String HaxCheck = "\u0023\u003DqXL1QBYJXP8Q4QjEk0A84ng\u003D\u003D"; //Internal void (bool ForceFail)
            public const String HaxCheckAudio = "\u0023\u003DqoVYhf\u0024JZKjXUIGitB5qyhg\u003D\u003D"; //Private void
            public const String HaxCheckMouse = "\u0023\u003DqGXTUKI67bvCUeoRkWXkNgw\u003D\u003D"; //Internal void
        }


        private static Type type;        //Obfuscated Name for Reflection

        private static MemberInfo _classObject;
        private static object classObject
        {
            get
            {
                if (_classObject == null)
                {
                    _classObject = type.GetMember(Instances.player,
                        BindingFlags.NonPublic | BindingFlags.Static).FirstOrDefault();
                    if (_classObject == null)
                    {
                        return Enums.BadFlags.Clean;
                    }
                }
                var value = Helper.GetValue<object>(_classObject, null);
                return value;
            }
        }        //Obfuscated Name for Reflection

        public bool IsValid
        {
            get { return classObject != null; }
        }


        #region ActiveRelax

        private static MemberInfo _activeRelax;

        public static bool ActiveRelax
        {
            get
            {
                if (_activeRelax == null)
                {
                    _activeRelax = type.GetMember(Instances.RelaxActive,
                        BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static).FirstOrDefault();
                    if (_activeRelax == null)
                    {
                        return false;
                    }
                }
                var value = Helper.GetValue<bool>(_activeRelax, null);
                return value;
            }
            set
            {
                if (_activeRelax == null)
                {
                    _activeRelax = type.GetMember(Instances.RelaxActive,
                        BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static).FirstOrDefault();
                    if (_activeRelax == null)
                    {
                        return;
                    }
                }
                Helper.SetValue(_activeRelax, value);
            }
        }

        #endregion

        #region ActiveRelax2

        private static MemberInfo _activeRelax2;

        public static bool ActiveRelax2
        {
            get
            {
                if (_activeRelax2 == null)
                {
                    _activeRelax2 = type.GetMember(Instances.Relax2Active,
                        BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static).FirstOrDefault();
                    if (_activeRelax2 == null)
                    {
                        return false;
                    }
                }
                var value = Helper.GetValue<bool>(_activeRelax2, null);
                return value;
            }
            set
            {
                if (_activeRelax2 == null)
                {
                    _activeRelax2 = type.GetMember(Instances.Relax2Active,
                        BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static).FirstOrDefault();
                    if (_activeRelax2 == null)
                    {
                        return;
                    }
                }
                Helper.SetValue(_activeRelax2, value);
            }
        }

        #endregion

        #region HitObjectManager

        private MemberInfo _hitObjectManager;

        public HitObjectManager HitObjectManager0
        {
            get
            {
                if (_hitObjectManager == null)
                {
                    _hitObjectManager = type.GetMember(Instances.hitObjectManager,
                        BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault();
                    if (_hitObjectManager == null)
                    {
                        return new HitObjectManager(null);
                    }
                }
                var value = Helper.GetValue<object>(_hitObjectManager, classObject);
                return new HitObjectManager(value);
            }
        }

        #endregion

        #region BadFlags

        private static MemberInfo _badFlags;

        public static BadFlags BadFlags
        {
            get
            {
                if (_badFlags == null)
                {
                    _badFlags = type.GetMember(Instances.BadFlags,
                        BindingFlags.NonPublic | BindingFlags.Static).FirstOrDefault();
                    if (_badFlags == null)
                    {
                        return Enums.BadFlags.Clean;
                    }
                }
                var value = Helper.GetValue<object>(_badFlags, null);
                return (BadFlags)value;
            }
            set
            {
                if (_badFlags == null)
                {
                    _badFlags = type.GetMember(Instances.BadFlags,
                        BindingFlags.NonPublic | BindingFlags.Static).FirstOrDefault();
                    if (_badFlags == null)
                    {
                        return;
                    }
                }
                 Helper.SetValue(_badFlags, BadFlags.IncorrectModValue);
            }
        }

        #endregion

        #region haxCheckCount

        private static MemberInfo _haxCheckCount;

        private static int HaxCheckCount
        {
            get
            {
                if (_haxCheckCount == null)
                {
                    _haxCheckCount = type.GetMember(Instances.HaxCheckCount,
                        BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault();
                    if (_haxCheckCount == null)
                    {
                        Console.WriteLine("Fucking Null");
                        return  -1;
                    }
                }
                var value = Helper.GetValue<int>(_haxCheckCount, classObject);
                return value;
            }
            set
            {
                if (_haxCheckCount == null)
                {
                    _haxCheckCount = type.GetMember(Instances.HaxCheckCount,
                        BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault();
                    if (_haxCheckCount == null)
                    {
                        return;
                    }
                }
                Helper.SetValue(_haxCheckCount, value, classObject);
            }
        }

        #endregion


        #region CheckFlashLightHax
        public HookManager checkFlashLightHaxHook;

        public void CheckFlashLightHaxTarget()
        {
           // Console.WriteLine("FBadFlags: {0} {1}", Player.BadFlags, ModManager.CurrentMods);
            return;
        }
        #endregion

        #region HaxCheck
        public HookManager haxCheckHook;

        public static void HaxCheckTarget(object this0, bool arg)
        {
            if(this0 != null)
            {
                Console.WriteLine("this0: {0} type: {1}", this0, this0.GetType());
            }
            if (arg != null)
            {
                Console.WriteLine("arg: " + arg.ToString());
            }
            if (classObject != null)
            {
                var kek = HaxCheckCount;
                HaxCheckCount = kek +1;

                Console.WriteLine("H1BadFlags: {0} {1} {2}", Player.BadFlags, ModManager.CurrentMods, kek);

            }
            //haxCheckHook.Uninstall();
            //haxCheckHook.OriginalMethodInfo.Invoke(classObject, new object[] {forceFail});
            //haxCheckHook.Install();
            //Console.WriteLine("H2BadFlags: {0} {1}", Player.BadFlags, ModManager.CurrentMods);
            /*Console.WriteLine("HBadFlags: {0} {1}", Player.BadFlags, ModManager.CurrentMods);
            BadFlags |= BadFlags.IncorrectModValue;*/
            return;
        }
        #endregion


        public static void Init()
        {
            type = Global.Osu.GetType(ClassName);

            //_activeRelax = type.GetMember(RelaxActiveInstance, BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static).FirstOrDefault();
            //_activeRelax2 = type.GetMember(Relax2ActiveInstance, BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static).FirstOrDefault();
        }

        public void InitMethods()
        {
            var checkFlashLightHax = type.GetMethod(Methods.CheckFlashLightHax, BindingFlags.NonPublic | BindingFlags.Instance);
            checkFlashLightHaxHook = 
                new HookManager(checkFlashLightHax, CheckFlashLightHaxTarget, classObject);
            
            var haxCheck = type.GetMethod(Methods.HaxCheck, BindingFlags.NonPublic | BindingFlags.Instance);
            haxCheckHook =
                new HookManager(haxCheck, ((Action<object, bool>)HaxCheckTarget).Method, classObject);
            

        }

        public void InstallHooks()
        {
            Console.WriteLine("Installing hooks");
            checkFlashLightHaxHook.Install();
            haxCheckHook.Install();
        }
        public Player()
        {
            Init();
            InitMethods();
            //_class757_0 = type.GetMember(class757_0Instance, BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault();



        }

        public void Dispose()
        {
            Console.WriteLine("Disposing...");
            checkFlashLightHaxHook.Uninstall();
            Console.WriteLine("Disposing1...");
            haxCheckHook.Uninstall();
            Console.WriteLine("Disposing2...");
            BadFlags = BadFlags.Clean;
            Console.WriteLine("Disposed...");

        }
    }
}
