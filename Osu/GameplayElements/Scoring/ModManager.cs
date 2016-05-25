using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using ClassLibrary2.Helpers;
using ClassLibrary2.Osu.Enums;
using ClassLibrary2.Osu.Helpers;
using Fasterflect;

namespace ClassLibrary2.Osu.GameplayElements.Scoring
{
    class ModManager //Class 129
    {
        public static String ClassName = "\u0023\u003DqJUmemLQhBEXKCdFyn_BEkg3iAjBDniNM4R2YZ7z0NCBwEeejPbDIXdELkvwl4oWR";

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

        public static String ModsInstance = "\u0023\u003DqxL_\u0024pRZFbEUj7CEOv2La5g\u003D\u003D";

        public static ObfuscatedValue<Mods> _currentMods =
            new ObfuscatedValue<Mods>(Type.GetFieldValue(ModsInstance, Flags.StaticPrivate));
        public static Mods CurrentMods
        {
            get { return _currentMods.GetValue(); }

        }
    }
}
