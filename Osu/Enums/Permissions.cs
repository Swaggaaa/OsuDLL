using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Osu.Enums
{
    [Flags]
    public enum Permissions
    {
        None = 0,
        Normal = 1,
        BAT = 2,
        Supporter = 4,
        Friend = 8,
        Peppy = 16,
        //Note: Tournament bit is not sent to or from Bancho in bUserPresences
        Tournament = 32
    }
}
