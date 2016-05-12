using System;
using System.Collections.Generic;
using System.Linq;
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
                    *(sitePtr) = 0xBB; //mov ebx target
                    *((uint*)(sitePtr + 1)) = (uint)target.ToInt32(); //target
                    *(sitePtr + 5) = 0xFF; //jmp
                    *(sitePtr + 6) = 0xE3; //EBX
                }
            }

            public void Uninstall()
            {
                //Console.WriteLine("Remove Hook");
                unsafe
                {
                    byte* sitePtr = (byte*)source.ToPointer();
                    for (int i = 0; i < 7; i++)
                    {
                        //Console.Write("{0:X2} ", *(sitePtr + i));
                        *(sitePtr + i) = originalAsm[i];
                    }
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

}
