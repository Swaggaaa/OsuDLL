using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary2.Helpers;
using ClassLibrary2.Osu.Enums;
using ClassLibrary2.Osu.Helpers;
using Fasterflect;

namespace ClassLibrary2.Osu.Online
{
    static class BanchoClient
    {
        public const string ClassName = "\u0023\u003DqAdGpN_Uh8unAQNX4Yc3X9b0FnwoORxK3c0r2EUnYmnQ\u003D";

        public struct Fields
        {
            public const string Permission = "\u0023\u003DqXVw3PA\u0024wsnn6eSIpwQBdsg\u003D\u003D";
        }

        #region Type

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

        #endregion

        internal static ObfuscatedValue<Permissions> _permission  = new ObfuscatedValue<Permissions>(Type.GetFieldValue(Fields.Permission, Flags.StaticAnyVisibility));
        internal static Permissions Permission
        {
            get
            {
                return _permission.GetValue();
            }
            set
            {
                Console.WriteLine("Permission Set: {0}", value);
                _permission.SetValue(value);
                Console.WriteLine("Permission Settted: {0}", Permission);

            }
        }

    }
}
