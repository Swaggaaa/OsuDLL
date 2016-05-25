using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using ClassLibrary2.Helpers;
using ClassLibrary2.Osu.Enums;
using ClassLibrary2.Osu.GameplayElements;
using ClassLibrary2.Osu.GameplayElements.Scoring;
using ClassLibrary2.Osu.Graphics;
using Fasterflect;

namespace ClassLibrary2.Osu.GameModes.Play
{
    //Beatmap Class -> PlayModes.Osu 1k
    //Remember has  anti hax
    class Player : IDisposable
    {
        private static readonly object syncRoot = new Object(); // https://msdn.microsoft.com/en-us/library/ff650316.aspx
        private Player _instance;
        /*public static Player Instance
        {
            get
            {
                return _instance ?? null;
            }
        }*/

        public static Dictionary<string, HookManager> HookDictionary = new Dictionary<string, HookManager>();

        #region Reflection
        public const String ClassName = "\u0023\u003DqSlWqg3cfqJsfZMmenE72gTkrz6nscXy\u0024UiWgJV5mTcc\u003D";

        public struct Fields
        {
            public const String player = "\u0023\u003Dq_cmKLagmWsTVBRRJvYnOBg\u003D\u003D"; //Line 47
            public const String RelaxActive = "\u0023\u003DqZ8ckBsDksNaTFmNVXVO07g\u003D\u003D"; //Line 57
            public const String Relax2Active = "\u0023\u003DqKpA4QhwoCZU7sN4F05q8cg\u003D\u003D"; //Line 58
            public const String hitObjectManager = "\u0023\u003Dq0zeis057NV5Rh4S9MV_OGF1JCTM5_NHXZXnbTosFcJk\u003D"; //Line 75
            public const String BadFlags = "\u0023\u003DqhQznIpd\u0024av\u0024N63tkWTlHjg\u003D\u003D"; //Line 159
            public const String HaxCheckCount = "\u0023\u003DqtpEFiR4izLciG9jsqPj0bw\u003D\u003D"; //Line 166
        }

        public struct Methods
        {
            public const String OnLoadComplete = "\u0023\u003Dq\u0024V\u002489d4X6fsuDtcm0DAfPg\u003D\u003D"; //Protected virtual bool OnLoadComplete(bool success) - Circa Line 577
            public const String CheckFlashLightHax = "\u0023\u003Dqz1ZT8ZVf1YAT0UyJg2NVecg3VM5n52QZSV81oXhIrv4\u003D"; //Private void Search for PlayModes.Taiko: Circa Line 3206
            public const String HaxCheck = "\u0023\u003DqjrrNPYyYOByILkFjWTjBKg\u003D\u003D"; //Internal void (bool ForceFail) Second Function After ^
            public const String HaxCheckAudio = "\u0023\u003DqMKUU6FDxfAzDWGFi2jpApQ\u003D\u003D"; //Private void - Right after ^
            public const String HaxCheckMouse = "\u0023\u003DqPDMkb18ASxUip2dzrnSi0w\u003D\u003D"; //Internal static void (Vector2, Vector2) Right after ^
            public const String Dispose = "\u0023\u003Dq3_5x0YAbglIR\u0024BhglarPtw\u003D\u003D"; //protected override void Dispose(bool disposing)
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
        public object classObject { get; private set; }
        #endregion


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
                 Helper.SetValue(_badFlags, value);
            }
        }

        #endregion

        #region haxCheckCount

        private static MemberInfo _haxCheckCount;

        public static int GetHaxCheckCount(object sender)
        {
            return (int) sender.GetFieldValue(Fields.HaxCheckCount);
        }
        public static void SetHaxCheckCount(object sender, int value)
        {
            sender.SetFieldValue(Fields.HaxCheckCount, value);
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

        #region OnLoadCompleted
        public static event EventHandler OnLoadCompleteEvent;
        public static MethodInfo OnLoadCompleteInfo
        {
            get
            {
                return Type.Method(Methods.OnLoadComplete, Flags.AllMembers); //This is cached
            }
        }
        private static bool OnLoadComplete(object sender, bool success)
        {
            var failed = (bool) HookDictionary["OnLoadComplete"].CallOriginal(sender, success);
            if (!failed)
            {
                if (OnLoadCompleteEvent == null)
                {
                    return false;
                }

                var eventListeners = OnLoadCompleteEvent.GetInvocationList();
                for (int index = 0; index < eventListeners.Count(); index++)
                {
                    var methodToInvoke = (EventHandler)eventListeners[index];
                    methodToInvoke.BeginInvoke(sender, EventArgs.Empty, EndAsyncEvent, null);
                }
            }
            return failed;
        }
        #endregion

        #region Dispose
        public static event EventHandler DisposeEvent;
        public static MethodInfo DisposeInfo
        {
            get
            {
                return Type.Method(Methods.Dispose, Flags.AllMembers); //This is cached
            }
        }
        private static void OnDispose(object sender, bool disposing)
        {
            if (DisposeEvent != null) DisposeEvent.Invoke(sender, EventArgs.Empty);
            HookDictionary["Dispose"].CallOriginal(sender, disposing);

            return;
        }
        #endregion

        private static void EndAsyncEvent(IAsyncResult iar)
        {
            var ar = (System.Runtime.Remoting.Messaging.AsyncResult)iar;
            var invokedMethod = (EventHandler)ar.AsyncDelegate;

            try
            {
                invokedMethod.EndInvoke(iar);
            }
            catch (Exception e)
            {
                // Handle any exceptions that were thrown by the invoked method
                Console.WriteLine("An event listener went kaboom!: " + e);
            }
        }

        #endregion

        public static void HookMethods()
        {
            HookDictionary["OnLoadComplete"]    = new HookManager(OnLoadCompleteInfo, ((Func<object, bool, bool>)(OnLoadComplete)).Method);
            HookDictionary["Dispose"]           = new HookManager(DisposeInfo, ((Action<object, bool>)(OnDispose)).Method);


            foreach (var hookManager in HookDictionary)
            {
                Console.WriteLine("Hooking Player.{0}", hookManager.Key);
                hookManager.Value.Install();
            }
        }

        public Player()
        {
            //_class757_0 = type.GetMember(class757_0Instance, BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault();
        }
        public Player(object sender)
        {
            classObject = sender;
            //_class757_0 = type.GetMember(class757_0Instance, BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault();
        }

        public void Dispose()
        {
            _instance = null;
            BadFlags = BadFlags.Clean;
            Console.WriteLine("Disposed...");

        }
    }
}
