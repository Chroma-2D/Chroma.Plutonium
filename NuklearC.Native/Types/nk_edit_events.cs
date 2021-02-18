using System;

namespace NuklearC.Native.Types
{
    [Flags]
    public enum nk_edit_events
    {
        ACTIVE = 1 << 0,
        INACTIVE = 1 << 1,
        ACTIVATED = 1 << 2,
        DEACTIVATED = 1 << 3,
        COMMITTED = 1 << 4
    }
}