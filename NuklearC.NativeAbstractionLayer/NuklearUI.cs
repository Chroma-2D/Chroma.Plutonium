using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using NuklearC.Native;
using NuklearC.Native.Types;

namespace NuklearC.NativeAbstractionLayer
{
    public static class NuklearUI
    {
        private static Action<string> _onClipboardCopy;
        private static nk_plugin_copy_t _nkOnClipboardCopy;
        private static Func<string> _onClipboardPaste;
        private static nk_plugin_paste_t _nkOnClipboardPaste;
        private static unsafe nk_context* _nuklearContext;

        internal static unsafe void InitializeContext(nk_context* context)
        {
            _nuklearContext = context;
        }

        public static bool Window(string name, string title, RectangleF rect, nk_panel_flags flags, Action action)
        {
            var result = true;

            unsafe
            {
                if (Nuklear.nk_begin_titled(_nuklearContext, name, title, rect, (uint)flags) != 0)
                    action?.Invoke();
                else
                    result = false;

                Nuklear.nk_end(_nuklearContext);
            }

            return result;
        }

        public static bool Window(string title, float x, float y, float w, float h, nk_panel_flags flags, Action action)
            => Window(title, title, new RectangleF(x, y, w, h), flags, action);

        public static bool WindowIsClosed(string name)
        {
            unsafe
            {
                return Nuklear.nk_window_is_closed(_nuklearContext, name) != 0;
            }
        }

        public static bool WindowIsHidden(string name)
        {
            unsafe
            {
                return Nuklear.nk_window_is_hidden(_nuklearContext, name) != 0;
            }
        }

        public static bool WindowIsCollapsed(string name)
        {
            unsafe
            {
                return Nuklear.nk_window_is_collapsed(_nuklearContext, name) != 0;
            }
        }

        public static bool Group(string name, string title, nk_panel_flags flags, Action action)
        {
            var result = true;

            unsafe
            {
                if (Nuklear.nk_group_begin_titled(_nuklearContext, name, title, flags) != 0)
                    action?.Invoke();
                else
                    result = false;

                Nuklear.nk_group_end(_nuklearContext);
            }

            return result;
        }

        public static bool Group(string name, nk_panel_flags flags, Action action)
            => Group(name, name, flags, action);

        public static bool ButtonLabel(string text)
        {
            unsafe
            {
                return Nuklear.nk_button_label(_nuklearContext, text) != 0;
            }
        }

        public static bool ButtonText(string text)
        {
            unsafe
            {
                return Nuklear.nk_button_text(_nuklearContext, text);
            }
        }

        public static void LayoutRowStatic(float height, int itemWidth, int columns)
        {
            unsafe
            {
                Nuklear.nk_layout_row_static(_nuklearContext, height, itemWidth, columns);
            }
        }

        public static void LayoutRowDynamic(float height = 0, int columns = 1)
        {
            unsafe
            {
                Nuklear.nk_layout_row_dynamic(_nuklearContext, height, columns);
            }
        }

        public static void Label(string Txt, nk_text_align TextAlign = (nk_text_align)nk_text_alignment.NK_TEXT_LEFT)
        {
            unsafe
            {
                Nuklear.nk_label(_nuklearContext, Txt, (uint)TextAlign);
            }
        }

        public static void LabelWrap(string text)
        {
            unsafe
            {
                Nuklear.nk_label_wrap(_nuklearContext, text);
            }
        }

        public static void LabelColored(string text, nk_color color,
            nk_text_align alignment = (nk_text_align)nk_text_alignment.NK_TEXT_LEFT)
        {
            unsafe
            {
                Nuklear.nk_label_colored(_nuklearContext, text, alignment, color);
            }
        }

        public static void LabelColored(string text, byte R, byte G, byte B, byte A,
            nk_text_align TextAlign = (nk_text_align)nk_text_alignment.NK_TEXT_LEFT)
        {
            LabelColored(text, new nk_color() {r = R, g = G, b = B, a = A}, TextAlign);
        }

        public static void LabelColoredWrap(string Txt, nk_color Clr)
        {
            unsafe
            {
                Nuklear.nk_label_colored_wrap(_nuklearContext, Txt, Clr);
            }
        }

        public static void LabelColoredWrap(string Txt, byte R, byte G, byte B, byte A)
        {
            LabelColoredWrap(Txt, new nk_color
            {
                r = R,
                g = G,
                b = B,
                a = A
            });
        }

        public static nk_rect WindowGetBounds()
        {
            unsafe
            {
                return Nuklear.nk_window_get_bounds(_nuklearContext);
            }
        }

        public static nk_edit_events EditString(nk_edit_types editType, StringBuilder buffer, nk_plugin_filter_t filter)
        {
            unsafe
            {
                return (nk_edit_events)Nuklear.nk_edit_string_zero_terminated(
                    _nuklearContext,
                    (uint)editType,
                    buffer,
                    buffer.MaxCapacity,
                    filter
                );
            }
        }

        public static nk_edit_events EditString(nk_edit_types editType, StringBuilder buffer)
        {
            return EditString(editType, buffer, (ref nk_text_edit _, uint _) => 1);
        }

        public static void WindowClose(string Name)
        {
            unsafe
            {
                Nuklear.nk_window_close(_nuklearContext, Name);
            }
        }

        public static void SetClipboardCallback(Action<string> onCopy, Func<string> onPaste)
        {
            unsafe
            {
                _onClipboardCopy = onCopy;
                _onClipboardPaste = onPaste;

                _nkOnClipboardCopy = (_, str, len) =>
                {
                    var bytes = new byte[len];

                    for (var i = 0; i < bytes.Length; i++)
                        bytes[i] = str[i];

                    onCopy(Encoding.UTF8.GetString(bytes));
                };

                _nkOnClipboardPaste = (nk_handle _, ref nk_text_edit textEdit) =>
                {
                    var bytes = Encoding.UTF8.GetBytes(onPaste());

                    fixed (byte* bytesPtr = bytes)
                    fixed (nk_text_edit* TextEditPtr = &textEdit)
                        Nuklear.nk_textedit_paste(TextEditPtr, bytesPtr, bytes.Length);
                };

                _nuklearContext->clip.copyfun_nkPluginCopyT = Marshal.GetFunctionPointerForDelegate(_nkOnClipboardCopy);
                _nuklearContext->clip.pastefun_nkPluginPasteT =
                    Marshal.GetFunctionPointerForDelegate(_nkOnClipboardPaste);
            }
        }
    }
}