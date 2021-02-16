using System.Runtime.InteropServices;

namespace Chroma.Gui.Nuklear.Internal.NuklearDotNet {
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal unsafe delegate void nk_foreach_action(nk_command* c);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal unsafe delegate void nk_draw_foreach_action(nk_draw_command* c);

	internal static unsafe partial class LibNuklear {
		internal static void nk_foreach(nk_context* ctx, nk_foreach_action A) {
			nk_command* c = null;

			for (c = nk__begin(ctx); c != null; c = nk__next(ctx, c))
				A(c);
		}

		internal static void nk_draw_foreach(nk_context* ctx, nk_buffer* b, nk_draw_foreach_action A) {
			nk_draw_command* Cmd = null;

			for (Cmd = nk__draw_begin(ctx, b); Cmd != null; Cmd = nk__draw_next(Cmd, b, ctx))
				A(Cmd);
		}
	}
}
