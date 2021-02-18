using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct nk_text_undo_record {
        public int iwhere;
        public short insert_length;
        public short delete_length;
        public short char_storage;
    }
}