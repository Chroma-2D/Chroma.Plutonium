using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Chroma.Gui.Nuklear.Internal
{
    internal static class CoreNative
    {
        private static class Windows
        {
            [DllImport("msvcrt", EntryPoint = "memcmp", CallingConvention = CallingConvention.Cdecl),
             SuppressUnmanagedCodeSecurity]
            internal static extern int MemCmp(IntPtr a, IntPtr b, IntPtr count);

            [DllImport("msvcrt", EntryPoint = "memcpy", CallingConvention = CallingConvention.Cdecl),
             SuppressUnmanagedCodeSecurity]
            internal static extern void MemCpy(IntPtr a, IntPtr b, IntPtr count);

            [DllImport("msvcrt", EntryPoint = "memset", CallingConvention = CallingConvention.Cdecl),
             SuppressUnmanagedCodeSecurity]
            internal static extern void MemSet(IntPtr a, int value, IntPtr count);

            [DllImport("msvcrt", EntryPoint = "malloc", CallingConvention = CallingConvention.Cdecl),
             SuppressUnmanagedCodeSecurity]
            internal static extern IntPtr Malloc(IntPtr size);

            [DllImport("msvcrt", EntryPoint = "free", CallingConvention = CallingConvention.Cdecl),
             SuppressUnmanagedCodeSecurity]
            internal static extern void Free(IntPtr p);
        }

        private static class Unix
        {
            [DllImport("libc", EntryPoint = "memcmp", CallingConvention = CallingConvention.Cdecl),
             SuppressUnmanagedCodeSecurity]
            internal static extern int MemCmp(IntPtr a, IntPtr b, IntPtr count);

            [DllImport("libc", EntryPoint = "memcpy", CallingConvention = CallingConvention.Cdecl),
             SuppressUnmanagedCodeSecurity]
            internal static extern void MemCpy(IntPtr a, IntPtr b, IntPtr count);

            [DllImport("libc", EntryPoint = "memset", CallingConvention = CallingConvention.Cdecl),
             SuppressUnmanagedCodeSecurity]
            internal static extern void MemSet(IntPtr a, int value, IntPtr count);

            [DllImport("libc", EntryPoint = "malloc", CallingConvention = CallingConvention.Cdecl),
             SuppressUnmanagedCodeSecurity]
            internal static extern IntPtr Malloc(IntPtr size);

            [DllImport("libc", EntryPoint = "free", CallingConvention = CallingConvention.Cdecl),
             SuppressUnmanagedCodeSecurity]
            internal static extern void Free(IntPtr p);
        }

        internal static int MemCmp(IntPtr a, IntPtr b, IntPtr count)
        {
            if (OperatingSystem.IsWindows())
            {
                return Windows.MemCmp(a, b, count);
            }

            return Unix.MemCmp(a, b, count);
        }

        internal static void MemCpy(IntPtr a, IntPtr b, IntPtr count)
        {
            if (OperatingSystem.IsWindows())
            {
                Windows.MemCpy(a, b, count);
            }
            else
            {
                Unix.MemCpy(a, b, count);
            }
        }

        internal static void MemSet(IntPtr a, int value, IntPtr count)
        {
            if (OperatingSystem.IsWindows())
            {
                Windows.MemSet(a, value, count);
            }
            else
            {
                Unix.MemSet(a, value, count);
            }
        }

        internal static IntPtr Malloc(IntPtr size)
        {
            if (OperatingSystem.IsWindows())
            {
                return Windows.Malloc(size);
            }
            else
            {
                return Unix.Malloc(size);
            }
        }
        
        internal static void Free(IntPtr p)
        {
            if (OperatingSystem.IsWindows())
            {
                Windows.Free(p);
            }
            else
            {
                Unix.Free(p);
            }
        }
    }
}