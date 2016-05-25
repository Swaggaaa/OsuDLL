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
    static class BanchoClient //Player Circa 529 Check Cleaned for reference
    {
        public const string ClassName = "\u0023\u003DqIxN4vAwz0yoCdOQW4M_cMZsoUCTpSTqHvYu4yIx_izU\u003D";

        public struct Fields
        {
            public const string Permission = "\u0023\u003Dqj0EGm9y_PvqIc8E92rXSgA\u003D\u003D";
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
                _permission.SetValue(value);
            }
        }

    }
}
