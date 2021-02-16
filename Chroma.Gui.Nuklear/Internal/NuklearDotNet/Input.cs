using System.Runtime.InteropServices;

namespace Chroma.Gui.Nuklear.Internal.NuklearDotNet
{
    internal enum NkKeys {
		None,
		Shift,
		Ctrl,
		Del,
		Enter,
		Tab,
		Backspace,
		Copy,
		Cut,
		Paste,
		Up,
		Down,
		Left,
		Right,

		InserMode,
		ReplaceMode,
		ResetMode,
		LineStart,
		LineEnd,
		TextStart,
		TextEnd,
		TextUndo,
		TextRedo,
		TextSelectAll,
		TextWordLeft,
		TextWordRight,

		ScrollStart,
		ScrollEnd,
		ScrollDown,
		ScrollUp,
		NK_KEY_MAX
	}

	internal enum nk_buttons {
		NK_BUTTON_LEFT,
		NK_BUTTON_MIDDLE,
		NK_BUTTON_RIGHT,
		NK_BUTTON_DOUBLE,
		NK_BUTTON_MAX
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct nk_mouse_button {
		internal int down;
		internal uint clicked;
		internal nk_vec2 clicked_pos;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct nk_mouse {
		/* fixed nk_mouse_button buttons[(int)(nk_buttons.NK_BUTTON_MAX)]; */
		internal nk_mouse_button buttonLeft;
		internal nk_mouse_button buttonMiddle;
		internal nk_mouse_button buttonRight;
		internal nk_mouse_button buttonDouble;

		internal nk_vec2 pos;
		internal nk_vec2 prev;
		internal nk_vec2 delta;
		internal nk_vec2 scroll_delta;

		internal byte grab;
		internal byte grabbed;
		internal byte ungrab;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct nk_key {
		internal int down;
		internal uint clicked;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct nk_keyboard { // TODO: Hax
		internal fixed uint keysCastTwoOfMeToOneNkKey[2 * (int)(NkKeys.NK_KEY_MAX)];
		//internal fixed nk_key keys[(uint)nk_keys.NK_KEY_MAX];
		internal fixed byte text[LibNuklear.NK_INPUT_MAX];
		internal int text_len;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct nk_input {
		internal nk_keyboard keyboard;
		internal nk_mouse mouse;
	}

	// [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
	internal static unsafe partial class LibNuklear {
		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_input_begin(nk_context* context);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_input_motion(nk_context* context, int x, int y);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_input_key(nk_context* context, NkKeys keys, int down);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_input_button(nk_context* context, nk_buttons buttons, int x, int y, int down);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_input_scroll(nk_context* context, nk_vec2 val);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_input_char(nk_context* context, byte c);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_input_glyph(nk_context* context, nk_glyph glyph);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_input_unicode(nk_context* context, uint rune);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_input_end(nk_context* context);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern int nk_input_has_mouse_click(nk_input* inp, nk_buttons buttons);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern int nk_input_has_mouse_click_in_rect(nk_input* inp, nk_buttons buttons, NkRect r);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern int nk_input_has_mouse_click_down_in_rect(nk_input* inp, nk_buttons buttons, NkRect r, int down);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern int nk_input_is_mouse_click_in_rect(nk_input* inp, nk_buttons buttons, NkRect r);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern int nk_input_is_mouse_click_down_in_rect(nk_input* inp, nk_buttons id, NkRect b, int down);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern int nk_input_any_mouse_click_in_rect(nk_input* inp, NkRect r);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern int nk_input_is_mouse_prev_hovering_rect(nk_input* inp, NkRect r);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern int nk_input_is_mouse_hovering_rect(nk_input* inp, NkRect r);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern int nk_input_mouse_clicked(nk_input* inp, nk_buttons buttons, NkRect r);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern int nk_input_is_mouse_down(nk_input* inp, nk_buttons buttons);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern int nk_input_is_mouse_pressed(nk_input* inp, nk_buttons buttons);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern int nk_input_is_mouse_released(nk_input* inp, nk_buttons buttons);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern int nk_input_is_key_pressed(nk_input* inp, NkKeys keys);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern int nk_input_is_key_released(nk_input* inp, NkKeys keys);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern int nk_input_is_key_down(nk_input* inp, NkKeys keys);
	}
}
