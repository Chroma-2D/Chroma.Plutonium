namespace NuklearC.Native.Types
{
    public enum nk_text_alignment
    {
        NK_TEXT_LEFT = nk_text_align.NK_TEXT_ALIGN_MIDDLE 
                       | nk_text_align.NK_TEXT_ALIGN_LEFT,
        
        NK_TEXT_CENTERED = nk_text_align.NK_TEXT_ALIGN_MIDDLE | 
                           nk_text_align.NK_TEXT_ALIGN_CENTERED,
        
        NK_TEXT_RIGHT = nk_text_align.NK_TEXT_ALIGN_MIDDLE 
                        | nk_text_align.NK_TEXT_ALIGN_RIGHT
    }
}