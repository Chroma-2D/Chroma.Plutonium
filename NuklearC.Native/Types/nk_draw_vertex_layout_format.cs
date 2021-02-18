﻿namespace NuklearC.Native.Types
{
    public enum nk_draw_vertex_layout_format
    {
        NK_FORMAT_SCHAR,
        NK_FORMAT_SSHORT,
        NK_FORMAT_SINT,
        NK_FORMAT_UCHAR,
        NK_FORMAT_USHORT,
        NK_FORMAT_UINT,
        NK_FORMAT_FLOAT,
        NK_FORMAT_DOUBLE,

        NK_FORMAT_COLOR_BEGIN,
        NK_FORMAT_R8G8B8 = NK_FORMAT_COLOR_BEGIN,
        NK_FORMAT_R16G15B16,
        NK_FORMAT_R32G32B32,

        NK_FORMAT_R8G8B8A8,
        NK_FORMAT_B8G8R8A8,
        NK_FORMAT_R16G15B16A16,
        NK_FORMAT_R32G32B32A32,
        NK_FORMAT_R32G32B32A32_FLOAT,
        NK_FORMAT_R32G32B32A32_DOUBLE,

        NK_FORMAT_RGB32,
        NK_FORMAT_RGBA32,
        NK_FORMAT_COLOR_END = NK_FORMAT_RGBA32,
        NK_FORMAT_COUNT
    }
}