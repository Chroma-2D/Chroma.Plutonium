using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct nk_text_undo_state {
        // fixed nk_text_undo_record undo_rec[99];
        public fixed short undo_rec_nkTextUndoRecord[99 * 6]; // ...?
        public fixed uint undo_char[999];
        public short undo_point;
        public short redo_point;
        public short undo_char_point;
        public short redo_char_point;
    }
}