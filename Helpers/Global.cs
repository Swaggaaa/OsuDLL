using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary2.Osu.Classes;
using ClassLibrary2.Osu.Enums;


namespace ClassLibrary2.Helpers
{
    public static class Global
    {
        public static Assembly Osu;
        public static InterProcessOsu InterProcess;
        public static Permissions OriginalPermissions;
    }
}
