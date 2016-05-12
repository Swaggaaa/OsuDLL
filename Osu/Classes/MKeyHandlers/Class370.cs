using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary2.Helpers;
using Microsoft.Xna.Framework.Input;

namespace ClassLibrary2.Osu.Classes.MKeyHandlers
{
    //Class 925 -> Line 150
    static class Class370
    {
        public static String ClassName = "\u0023\u003Dq5gQPLk9Kk53iXQy\u0024E73s7QN7GkF9tjvMHVMDRW_G_M_G3nCdae3upKKwmX4r_uJ4";
        //useless
        public static String ButtonState0Instance = "\u0023\u003Dqv_6GfBfyfV2naBvZbxVu9A\u003D\u003D";          //private
        public static String ButtonState1Instance = "\u0023\u003DqeHnIXpAaoEPbD3Z\u0024_mARmg\u003D\u003D";     //private
        public static String ButtonState2Instance = "\u0023\u003Dq\u0024oImETAsIsvVDgQa32mj5A\u003D\u003D";     //private
        public static String ButtonState3Instance = "\u0023\u003DqBQdWxUNRzr\u0024WhilCRUTrXg\u003D\u003D";     //private
        public static String ButtonState4Instance = "\u0023\u003Dqj6P7awgRQ6u2HEmKJ4831A\u003D\u003D";          //private

        public static String ButtonState5Instance = "\u0023\u003DqQ33BB5cytPYQH2xJpER3tXdGfZzXlfY\u0024EJtlwbCwRk0\u003D";   //Internal
        public static String ButtonState6Instance = "\u0023\u003DqVxmeDboHn\u0024l\u0024r2yE3krYtQ\u003D\u003D";            //Internal

        public static String ButtonState7Instance = "\u0023\u003Dq0XEtiAqHqFP4vr66LBopvg\u003D\u003D";          //private
        public static String ButtonState8Instance = "\u0023\u003DqUZkp0w8sGLkUiLjbgyBgUg\u003D\u003D";          //private
        public static String ButtonState9Instance = "\u0023\u003DqP0DJRaOGgJSerjQtUsA8Jg\u003D\u003D";          //private
        public static String ButtonState10Instance = "\u0023\u003DqPo0hteC1sRnC7_MRZldHfA\u003D\u003D";         //private
        public static String ButtonState11Instance = "\u0023\u003DqCTNVceKljy8DTSjN1SH\u0024PQ\u003D\u003D";    //private

        private static Type type;        //Obfuscated Name for Reflection

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
                        return;
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
