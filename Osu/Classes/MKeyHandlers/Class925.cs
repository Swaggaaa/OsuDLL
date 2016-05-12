using System;
using System.Linq;
using System.Reflection;
using ClassLibrary2.Helpers;
using Microsoft.Xna.Framework.Input;

namespace ClassLibrary2.Osu.Classes.MKeyHandlers
{
    //Class 28 -> Mods.Target twice
    static class Class925
    {
        public static String ClassName = "\u0023\u003DqthwP2Fmvx6QB6dD8Cqt12CX7AODLn6sRg_ZzEyrZLI4\u003D";
        //useless
        public static String ButtonState0Instance = "\u0023\u003DqGsJ0w2gTWUtaOYXm25gbDQ\u003D\u003D";
        public static String ButtonState1Instance = "\u0023\u003DqN7pMCmDbCe\u00249fZfyE6iG4g\u003D\u003D";
        public static String ButtonState2Instance = "\u0023\u003DqhYonRzQJKuc4HCIR49F\u0024Hsw96cmJFISvCEt_yebef1E\u003D";
        public static String ButtonState3Instance = "\u0023\u003Dq2jec_EJbIkW6kfveMcPLdr0DiEOvBdQsXxCx\u0024ZAAGiU\u003D";
        public static String ButtonState4Instance = "\u0023\u003Dq73sbGNKxKDMINsGpBZAdn4zGai8eSF9KsGk6tJG0o\u0024o\u003D";
        public static String ButtonState5Instance = "\u0023\u003DqsxKOo1y278P8kQ1CbbOPsg\u003D\u003D";
        public static String ButtonState6Instance = "\u0023\u003DqShm9madIQrbrpTmlFGEdCPIQOXEVYQ4Q7vaXXhlqO7I\u003D";


        private static Type type;        //Obfuscated Name for Reflection
        private static object actualObject;        //Obfuscated Name for Reflection

        #region ButtonState0

        private static MemberInfo _buttonState0;

        public static ButtonState ButtonState0
        {
            get
            {
                if (_buttonState0 == null)
                {
                    _buttonState0 = type.GetMember(ButtonState0Instance,
                        BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).FirstOrDefault();
                    if (_buttonState0 == null)
                    {
                        return ButtonState.Released;
                    }
                }
                return Helper.GetValue<ButtonState>(_buttonState0, null);
            }
            set
            {
                if (_buttonState0 == null)
                {
                    _buttonState0 = type.GetMember(ButtonState0Instance,
                        BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).FirstOrDefault();
                    if (_buttonState0 == null)
                    {
                        return;
                    }
                }
                Helper.SetValue(_buttonState0, value);
                ButtonState2 = value;
                ButtonState1 = value;
            }
        }

        #endregion

        #region ButtonState1

        private static MemberInfo _buttonState1;

        public static ButtonState ButtonState1
        {
            get
            {
                if (_buttonState1 == null)
                {
                    _buttonState1 = type.GetMember(ButtonState1Instance,
                        BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).FirstOrDefault();
                    if (_buttonState1 == null)
                    {
                        return ButtonState.Released;
                    }
                }
                return Helper.GetValue<ButtonState>(_buttonState1, null);
            }
            set
            {
                if (_buttonState1 == null)
                {
                    _buttonState1 = type.GetMember(ButtonState1Instance,
                        BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).FirstOrDefault();
                    if (_buttonState1 == null)
                    {
                        return;
                    }
                }
                Helper.SetValue(_buttonState1, value);
            }
        }

        #endregion

        #region ButtonState2

        private static MemberInfo _buttonState2;

        public static ButtonState ButtonState2
        {
            get
            {
                if (_buttonState2 == null)
                {
                    _buttonState2 = type.GetMember(ButtonState2Instance,
                        BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).FirstOrDefault();
                    if (_buttonState2 == null)
                    {
                        return ButtonState.Released;
                    }
                }
                return Helper.GetValue<ButtonState>(_buttonState2, null);
            }
            set
            {
                if (_buttonState2 == null)
                {
                    _buttonState2 = type.GetMember(ButtonState2Instance,
                        BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).FirstOrDefault();
                    if (_buttonState2 == null)
                    {
                        return ;
                    }
                }
                Helper.SetValue(_buttonState2, value);
            }
        }

        #endregion

        #region ButtonState3

        private static MemberInfo _buttonState3;

        public static ButtonState ButtonState3
        {
            get
            {
                if (_buttonState3 == null)
                {
                    _buttonState3 = type.GetMember(ButtonState3Instance,
                        BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).FirstOrDefault();
                    if (_buttonState3 == null)
                    {
                        return ButtonState.Released;
                    }
                }
                return Helper.GetValue<ButtonState>(_buttonState3, null);
            }
        }

        #endregion

        #region ButtonState4

        private static MemberInfo _buttonState4;

        public static ButtonState ButtonState4
        {
            get
            {
                if (_buttonState4 == null)
                {
                    _buttonState4 = type.GetMember(ButtonState4Instance,
                        BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).FirstOrDefault();
                    if (_buttonState4 == null)
                    {
                        return ButtonState.Released;
                    }
                }
                return Helper.GetValue<ButtonState>(_buttonState4, null);
            }
        }

        #endregion

        #region ButtonState5

        private static MemberInfo _buttonState5;

        public static ButtonState ButtonState5
        {
            get
            {
                if (_buttonState5 == null)
                {
                    _buttonState5 = type.GetMember(ButtonState5Instance,
                        BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).FirstOrDefault();
                    if (_buttonState5 == null)
                    {
                        return ButtonState.Released;
                    }
                }
                return Helper.GetValue<ButtonState>(_buttonState5, null);
            }
        }

        #endregion

        #region ButtonState6

        private static MemberInfo _buttonState6;

        public static ButtonState ButtonState6
        {
            get
            {
                if (_buttonState6 == null)
                {
                    _buttonState6 = type.GetMember(ButtonState6Instance,
                        BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).FirstOrDefault();
                    if (_buttonState6 == null)
                    {
                        return ButtonState.Released;
                    }
                }
                return Helper.GetValue<ButtonState>(_buttonState6, null);
            }
        }

        #endregion

        public static void Init()
        {
            type = Global.Osu.GetType(ClassName);
            /*foreach (var memberInfo in type.GetMembers(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
            {
                var value = Helper.GetValue<object>(memberInfo, null);
                Console.WriteLine("Name {0} Value: {1}", memberInfo.Name, value);
            }*/
            //_currentTime = type.GetMember(CurrentTimeInstance, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).FirstOrDefault();
        }

    }
}
