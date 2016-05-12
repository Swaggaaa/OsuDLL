using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Osu.Enums
{

    [Flags]
    public enum HitObjectType
    {
        None = 0,
        Normal = 1,
        Slider = 2,
        NewCombo = 4,
        NormalNewCombo = NewCombo | Normal,
        SliderNewCombo = NewCombo | Slider,
        Spinner = 8,
        ColourHax = 112,
        Hold = 128,
        ManiaLong = Hold,
    }
}
