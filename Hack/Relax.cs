using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ClassLibrary2.Osu.Classes;
using ClassLibrary2.Osu.Enums;
using ClassLibrary2.Helpers;
using ClassLibrary2.Osu.Audio;
using ClassLibrary2.Osu.Classes.MKeyHandlers;
using ClassLibrary2.Osu.GameplayElements;
using ClassLibrary2.Osu.GameplayElements.Beatmaps;
using ClassLibrary2.Osu.GameplayElements.Scoring;
using Microsoft.Xna.Framework.Input;

namespace ClassLibrary2.Hack
{
    public delegate void OnHitOBjectEvent(object sender, HitObject e);
    class Relax
    {
        public event OnHitOBjectEvent HitObjectHandler;

        private readonly Beatmap _beatmap;
        private readonly int _offset;
        private int CurrentTime => AudioEngine.Time;
        private bool _zBusy = false;
        private bool _xBusy = false;

        public Relax(Beatmap beatmap, int offset)
        {
            this._beatmap = beatmap;
            this._offset = offset;
        }

        private async Task OnHitObject(HitObject hitObject)
        {
	        /*if (HitObjectHandler != null)
	        {
                HitObjectHandler(null, hitObject);
	        }*/
            if (hitObject.Duration == 0)
            {
                hitObject.EndTime += 40;
            }
            if (!_zBusy)
            {
                _zBusy = true;
                Keyboard.SimulateKeyDown(VirtualKeyCode.VK_Z);
                //Class370.ButtonState2 = ButtonState.Pressed;
                while (CurrentTime < hitObject.EndTime)
                {
                    //Class370.ButtonState2 = ButtonState.Pressed; ;

                }
                //Class370.ButtonState2 = ButtonState.Released; ;

               Keyboard.SimulateKeyUp(VirtualKeyCode.VK_Z);
                _zBusy = false;

            }
            else if (!_xBusy)
            {
                _zBusy = true;
                Keyboard.SimulateKeyDown(VirtualKeyCode.VK_X);
                while (CurrentTime < hitObject.EndTime)
                {
                    ;
                }
                Keyboard.SimulateKeyUp(VirtualKeyCode.VK_X);
                _zBusy = false;
            }
        }

        public void Run()
        {
            Random rnd = new Random();
            Mods activeMods = ModManager.CurrentMods;
            Console.WriteLine("Play! {0}", _beatmap.HitObjects.Count);
            reset:

            int prevTime = 0;
            foreach (var hitObject in _beatmap.HitObjects)
            {


                if (!Global.InterProcess.IsPlaying())
                {
                    Console.WriteLine("Play Exit ");
                    return;
                }
                while (CurrentTime  < hitObject.StartTime + rnd.Next(-_offset, _offset))
                {
                    /*Console.Clear();
                    Console.WriteLine(Class370.ButtonState0);
                    Console.WriteLine(Class370.ButtonState1);
                    Console.WriteLine(Class370.ButtonState2);
                    Console.WriteLine(Class370.ButtonState3);
                    Console.WriteLine(Class370.ButtonState4);
                    Console.WriteLine(Class370.ButtonState5);
                    Console.WriteLine(Class370.ButtonState6);
                    Thread.Sleep(1);*/
                    if (!Global.InterProcess.IsPlaying())
                    {
                        Console.WriteLine("Play Exit");
                        return;
                    }
                    if (CurrentTime + 50 < prevTime)
                    {
                       // Console.WriteLine("reset");
                        prevTime = CurrentTime;
                        goto reset;
                    }
                    prevTime = CurrentTime;
                    //Console.WriteLine("Time: {0}, Next: {1}", currentTime, hitObject.StartTime);

                }
                if (Math.Abs(CurrentTime - hitObject.StartTime) > _offset)
                {
                    //Console.WriteLine("Continue - {0}", CurrentTime - hitObject.StartTime);
                    continue;
                }
                var o = hitObject;
                Task.Run(() => OnHitObject(o));
                prevTime = CurrentTime;
                // Console.WriteLine("{0} - {1}", hitObject.StartTime, _xBusy);
            }

            //Thread.Sleep(5000);
        }


    }
}
