using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

#pragma warning disable 0649
internal struct HARDWAREINPUT
{
    public uint Msg;
    public ushort ParamL;
    public ushort ParamH;
}
internal struct KEYBDINPUT
{
    public ushort Vk;
    public ushort Scan;
    public uint Flags;
    public uint Time;
    public IntPtr ExtraInfo;
}
internal struct MOUSEINPUT
{
    public int X;
    public int Y;
    public uint MouseData;
    public uint Flags;
    public uint Time;
    public IntPtr ExtraInfo;
}
[StructLayout(LayoutKind.Explicit)]
internal struct MOUSEKEYBDHARDWAREINPUT
{
    [FieldOffset(0)]
    public MOUSEINPUT Mouse;
    [FieldOffset(0)]
    public KEYBDINPUT Keyboard;
    [FieldOffset(0)]
    public HARDWAREINPUT Hardware;
}
struct INPUT
{
    public uint Type;
    public MOUSEKEYBDHARDWAREINPUT Data;
}
#pragma warning restore 0649
namespace ClassLibrary2
{
    internal static class Keyboard
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);
        public static void SimulateKeyDown(VirtualKeyCode keyCode)
        {
            INPUT input = getInput(keyCode, true);

            if ((int)SendInput(1U, new INPUT[1]{input}, Marshal.SizeOf(typeof(INPUT))) == 0)
                throw new Exception(string.Format("The key down simulation for {0} was not successful.", (object)keyCode));
        }
        public static void SimulateKeyUp(VirtualKeyCode keyCode)
        {
            INPUT input = getInput(keyCode, false);
            if ((int)SendInput(1U, new INPUT[1]{input}, Marshal.SizeOf(typeof(INPUT))) == 0)
                throw new Exception(string.Format("The key up simulation for {0} was not successful.", (object)keyCode));
        }
        public static void SimulateKeyPress(VirtualKeyCode keyCode, int sleep = 5)
        {
            SimulateKeyDown(keyCode);
            Thread.Sleep(sleep);
            SimulateKeyUp(keyCode);
        }

        private static INPUT getInput(VirtualKeyCode keyCode, bool down)
        {
            INPUT input = new INPUT();
            input.Type = 1U;
            input.Data.Keyboard = new KEYBDINPUT();
            input.Data.Keyboard.Vk = (ushort)keyCode;
            input.Data.Keyboard.Scan = (ushort)0;
            input.Data.Keyboard.Flags = down ? 0U : 2U;
            input.Data.Keyboard.Time = 0U;
            input.Data.Keyboard.ExtraInfo = IntPtr.Zero;
            return input;
        }

    }
}
