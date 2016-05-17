using System;
using System.Linq;
using System.Reflection;
using ClassLibrary2.Helpers;
using ClassLibrary2.Osu.Enums;
using ClassLibrary2.Osu.GameplayElements;
using ClassLibrary2.Osu.GameplayElements.Scoring;
using Fasterflect;

namespace ClassLibrary2.Osu.GameModes.Play
{
    //Beatmap Class -> PlayModes.Osu 1k
    //Remember has  anti hax
    class Player : IDisposable
    {
        public const String ClassName = "\u0023\u003DqJOMMiVfXoKIKzCijFD0e1LPJiJCYikVcbnfexQ3_ueU\u003D";

        public struct Fields
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
        }       

        private static MemberInfo _classObject;
        private static object classObject
        {
            get
            {
                if (_classObject == null)
                {
                    _classObject = type.GetMember(Fields.player,
                        BindingFlags.NonPublic | BindingFlags.Static).FirstOrDefault();
                    if (_classObject == null)
                    {
                        return null;
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
                    _activeRelax = type.GetMember(Fields.RelaxActive,
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
                    _activeRelax = type.GetMember(Fields.RelaxActive,
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
                    _activeRelax2 = type.GetMember(Fields.Relax2Active,
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
                    _activeRelax2 = type.GetMember(Fields.Relax2Active,
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
                    _hitObjectManager = type.GetMember(Fields.hitObjectManager,
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
                    _badFlags = type.GetMember(Fields.BadFlags,
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
                    _badFlags = type.GetMember(Fields.BadFlags,
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
                    _haxCheckCount = type.GetMember(Fields.HaxCheckCount,
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
                    _haxCheckCount = type.GetMember(Fields.HaxCheckCount,
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


        #region Methods

        #region CheckFlashLightHax

        public static MethodInfo CheckFlashLightHaxInfo
        {
            get { return Type.Method(Methods.CheckFlashLightHax, Flags.InstanceAnyVisibility); //This is cached
            }
        }

        #endregion

        #region HaxCheck

        public static MethodInfo HackCheckInfo
        {
            get
            {
                return Type.Method(Methods.HaxCheck, Flags.InstanceAnyVisibility); //This is cached
            }
        }

        #endregion

        #endregion

        public Player()
        {
            //_class757_0 = type.GetMember(class757_0Instance, BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault();
        }

        public void Dispose()
        {
            BadFlags = BadFlags.Clean;
            Console.WriteLine("Disposed...");

        }
    }
}
