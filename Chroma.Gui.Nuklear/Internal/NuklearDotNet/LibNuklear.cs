using System.Runtime.InteropServices;

namespace Chroma.Gui.Nuklear.Internal.NuklearDotNet {
	internal static unsafe partial class LibNuklear {
		const string DllName = "nuklear";
		const CallingConvention CConv = CallingConvention.Cdecl;
		const CharSet CSet = CharSet.Ansi;

		internal const int NK_INPUT_MAX = 512; // 16 by default
	}
}
