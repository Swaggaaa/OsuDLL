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
using ClassLibrary2.Osu.Online;
using ClassLibrary2.Osu.Classes.MKeyHandlers;
using ClassLibrary2.Osu.GameplayElements;
using ClassLibrary2.Osu.GameModes.Play;
using ClassLibrary2.Osu.GameplayElements.Beatmaps;
using ClassLibrary2.Osu.GameplayElements.Scoring;
using Fasterflect;
using Microsoft.Xna.Framework.Input;

namespace ClassLibrary2.Hack
{
    //TODO Hook Update() from player and do proper API
    class Relax : IDisposable
    {

        private readonly Beatmap _beatmap;
        private readonly int _offset;
        private readonly Player player;
        private int CurrentTime
        {
            get { return AudioEngine.Time; }
        }

        private bool _zBusy = false;
        private bool _xBusy = false;

        public static void OnLoadComplete(object sender, EventArgs e)
        {
            var player = new Player(sender);
                var relax = new Relax(player, 25);
                relax.Run();
        }

        /*public Relax(Beatmap beatmap, int offset)
        {
            this._beatmap = beatmap;
            this._offset = offset;
            Player.DisposeEvent += OnPlayerDispose;
        }*/

        public Relax(Player player, int offeset)
        {

            this.player = player;
            this._offset = offeset;
            _beatmap = new Beatmap(
                BeatmapManager.GetCurrentBeatmap.Call(null, null), player.HitObjectManager0.HitObjects);
            Player.DisposeEvent += OnPlayerDispose;

        }

        private async Task OnHitObject(HitObject hitObject)
        {
	        /*if (HitObjectHandler != null)
	        {
                HitObjectHandler(null, hitObject);
	        }*/
            if (!_zBusy)
            {
                _zBusy = true;
                Keyboard.SimulateKeyDown(VirtualKeyCode.VK_Z);
                //Class370.ButtonState2 = ButtonState.Pressed;
                while (CurrentTime < hitObject.EndTime + 40)
                {
                    await Task.Delay(15);
                    //Class370.ButtonState2 = ButtonState.Pressed; ;

                }
                //Class370.ButtonState2 = ButtonState.Released; ;

               Keyboard.SimulateKeyUp(VirtualKeyCode.VK_Z);
                _zBusy = false;

            }
            else if (!_xBusy)
            {
                _xBusy = true;
                Keyboard.SimulateKeyDown(VirtualKeyCode.VK_X);
                while (CurrentTime < hitObject.EndTime + 40)
                {
                    await Task.Delay(15);

                }
                Keyboard.SimulateKeyUp(VirtualKeyCode.VK_X);
                _xBusy = false;
            }
        }

        public void Run()
        {
            Random rnd = new Random();
            Mods activeMods = ModManager.CurrentMods;
            Console.WriteLine("Play! {0}\nMods:{1}", _beatmap.HitObjects.Count, activeMods);
            Console.WriteLine("Permissions: {0}", BanchoClient.Permission);

            foreach (var hitObject in _beatmap.HitObjects)
            {

                hitObject.StartTime += rnd.Next(-_offset, _offset);
                if (!Global.InterProcess.IsPlaying())
                {
                    Console.WriteLine("Play Exit ");
                    return;
                }
                while (CurrentTime  < hitObject.StartTime)
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
                    /*if (!Global.InterProcess.IsPlaying())
                    {
                        Console.WriteLine("Play Exit");
                        return;
                    }*/
                    /*if (CurrentTime + 1000 < prevTime)
                    {
                        Console.WriteLine("reset");
                        prevTime = CurrentTime;
                        resetX = true;
                        resetZ = true;
                        return;
                    }*/
                    Thread.Sleep(1);
                    //Console.WriteLine("Time: {0}, Next: {1}", currentTime, hitObject.StartTime);

                }
                if (Math.Abs(CurrentTime - hitObject.StartTime) > _offset)
                {
                    //Console.WriteLine("Continue - {0}", CurrentTime - hitObject.StartTime);
                    continue;
                }
                var o = hitObject;
                Task.Run(() => OnHitObject(o));
                // Console.WriteLine("{0} - {1}", hitObject.StartTime, _xBusy);
            }

            Thread.Sleep(5000);
        }

        public void OnPlayerDispose(object sender, EventArgs e)
        {
            //Player.DisposeEvent -= OnPlayerDispose;
            this.Dispose();
        }

        public void Dispose()
        {
            if (_zBusy)
            {
                Keyboard.SimulateKeyUp(VirtualKeyCode.VK_Z);

            }
            if (_xBusy)
            {
                Keyboard.SimulateKeyUp(VirtualKeyCode.VK_X);

            }
            Player.DisposeEvent -= OnPlayerDispose;
            player.Dispose();
            Console.WriteLine("Disposed Relax");
        }
    }
}
