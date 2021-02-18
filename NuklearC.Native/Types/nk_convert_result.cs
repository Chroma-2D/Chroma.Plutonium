using System;

namespace NuklearC.Native.Types
{
    [Flags]
    public enum nk_convert_result
    {
        // nk_convert_result, NK_CONVERT_*
        Success = 0,
        InvalidParam = 1,
        CommandBufferFull = 1 << 1,
        VertexBufferFull = 1 << 2,
        ElementBufferFull = 1 << 3
    }
}