namespace NuklearC.Native.Types
{
    public enum nk_panel_set : uint
    {
        NK_PANEL_SET_NONBLOCK = nk_panel_type.NK_PANEL_CONTEXTUAL | nk_panel_type.NK_PANEL_COMBO |
                                nk_panel_type.NK_PANEL_MENU | nk_panel_type.NK_PANEL_TOOLTIP,
        NK_PANEL_SET_POPUP = NK_PANEL_SET_NONBLOCK | nk_panel_type.NK_PANEL_POPUP,
        NK_PANEL_SET_SUB = NK_PANEL_SET_POPUP | nk_panel_type.NK_PANEL_GROUP
    }
}