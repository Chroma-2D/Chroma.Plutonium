namespace NuklearC.Native.Types
{
    public enum nk_edit_types
    {
        SIMPLE = nk_edit_flags.ALWAYS_INSERT_MODE,
        
        FIELD = SIMPLE 
                | nk_edit_flags.SELECTABLE 
                | nk_edit_flags.CLIPBOARD,

        BOX = nk_edit_flags.ALWAYS_INSERT_MODE 
              | nk_edit_flags.SELECTABLE 
              | nk_edit_flags.MULTILINE 
              | nk_edit_flags.ALLOW_TAB 
              | nk_edit_flags.CLIPBOARD,
        
        EDITOR = nk_edit_flags.SELECTABLE 
                 | nk_edit_flags.MULTILINE 
                 | nk_edit_flags.ALLOW_TAB 
                 | nk_edit_flags.CLIPBOARD,

        READ_ONLY_EDITOR = nk_edit_flags.SELECTABLE 
                           | nk_edit_flags.MULTILINE 
                           | nk_edit_flags.ALLOW_TAB 
                           | nk_edit_flags.CLIPBOARD 
                           | nk_edit_flags.READ_ONLY
    }
}