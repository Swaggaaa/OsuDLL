﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading.Tasks;

    namespace ClassLibrary2
    {
        public class HookManager
        {

            private IntPtr source;
            private IntPtr target;
            private byte[] originalAsm = new byte[7];

            public MethodInfo OriginalMethodInfo;
            public Type ClassType = null;

            private object classObject;
            public object ClassObject
            {
                get
                {
                    return classObject;
                }
                set
                {
                    ClassType = value.GetType();
                    classObject = value;
                }
            }

            [DllImport("kernel32.dll", SetLastError = true)]
            private static extern bool VirtualProtect(IntPtr lpAddress, uint dwSize,
uint flNewProtect, out uint lpflOldProtect);


            public HookManager(MethodInfo from, MethodInfo to, object classObject = null)
            {
                PrepareHook(from, to, classObject);

            }

            public HookManager(MethodInfo from, Action to, object classObject = null)
            {
                PrepareHook(from, to.Method, classObject);
            }

            public static HookManager HookManagerEx<T>(MethodInfo from, Func<T> to, object classObject = null)
            {
                return new HookManager(from, to.Method, classObject);
            }

            private void PrepareHook(MethodInfo from, MethodInfo to, object classObject = null)
            {
                //Compile/JIT target method into asm
                if (from == null)
                {
                    throw new Exception("From MethodInfo is null");
                }
                if (to == null)
                {
                    throw new Exception("To MethodInfo is null");
                }
                RuntimeHelpers.PrepareMethod(from.MethodHandle);
                OriginalMethodInfo = from;
                source = from.MethodHandle.GetFunctionPointer();
                target = to.MethodHandle.GetFunctionPointer();
                BackupAsm();
            }

            public void Install()
            {
                //Console.WriteLine("Install Hook");
                unsafe
                {
                    byte* sitePtr = (byte*)source.ToPointer();
                    uint oldPerms;
                    VirtualProtect(source, 7,(uint) Protection.PAGE_EXECUTE_READWRITE, out oldPerms);
                    *(sitePtr) = 0xBB; //mov ebx target
                    *((uint*)(sitePtr + 1)) = (uint)target.ToInt32(); //target
                    *(sitePtr + 5) = 0xFF; //jmp
                    *(sitePtr + 6) = 0xE3; //EBX
                    uint oldPerms2;
                    VirtualProtect(source, 7, oldPerms, out oldPerms2);
                }
            }

            public void Uninstall()
            {
                //Console.WriteLine("Remove Hook");
                unsafe
                {
                    uint oldPerms;
                    VirtualProtect(source, 7, (uint)Protection.PAGE_EXECUTE_READWRITE, out oldPerms);
                    byte* sitePtr = (byte*)source.ToPointer();
                    for (int i = 0; i < 7; i++)
                    {
                        //Console.Write("{0:X2} ", *(sitePtr + i));
                        *(sitePtr + i) = originalAsm[i];
                    }
                    uint oldPerms2;
                    VirtualProtect(source, 7, oldPerms, out oldPerms2);
                    // Console.WriteLine();
                }
            }

            public void CheckBytes()
            {
                unsafe
                {
                    byte* sitePtr = (byte*)source.ToPointer();
                    for (int i = 0; i < 7; i++)
                    {
                        Console.Write("{0:X2} ", *(sitePtr + i));
                    }
                    Console.WriteLine();
                }
            }

            public object CallOriginal(params object[] args)
            {
                Uninstall();
                object value = null;
                value = OriginalMethodInfo.Invoke(classObject, args.Length == 0 ? null : args);
                Install();
                return value;
            }

            private void BackupAsm()
            {
                unsafe
                {
                    byte* sitePtr = (byte*)source.ToPointer();
                    for (int i = 0; i < 7; i++)
                    {
                        originalAsm[i] = *(sitePtr + i);
                        //Console.Write("{0:X2} ", originalAsm[i]);
                    }
                    //Console.WriteLine();
                }
            }


        }
    }
    public enum Protection
    {
        PAGE_NOACCESS = 0x01,
        PAGE_READONLY = 0x02,
        PAGE_READWRITE = 0x04,
        PAGE_WRITECOPY = 0x08,
        PAGE_EXECUTE = 0x10,
        PAGE_EXECUTE_READ = 0x20,
        PAGE_EXECUTE_READWRITE = 0x40,
        PAGE_EXECUTE_WRITECOPY = 0x80,
        PAGE_GUARD = 0x100,
        PAGE_NOCACHE = 0x200,
        PAGE_WRITECOMBINE = 0x400
    }

}
