﻿using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void nk_plugin_paste_t(nk_handle handle, ref nk_text_edit edit);
}