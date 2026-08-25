using ComicCollection.Styles;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ComicCollection.Helpers
{
    public static class UIHelper
    {
        // Apply the application's standard form styling
        public static void StyleForm(Form form)
        {
            form.BackColor = Theme.Background;
            form.ForeColor = Theme.Text;

            SetDarkTitleBar(form);
        }

        // Apply the application's standard button styling
        public static void StyleButton(Button button)
        {
            button.BackColor = Theme.Button;
            button.ForeColor = Theme.Text;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
        }

        // Set Windows title bar to dark mode
        private static void SetDarkTitleBar(Form form)
        {
            int useDarkMode = 1;

            DwmSetWindowAttribute(
                form.Handle,
                DWMWA_USE_IMMERSIVE_DARK_MODE,
                ref useDarkMode,
                sizeof(int)
            );
        }

        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(
            IntPtr hwnd,
            int dwAttribute,
            ref int pvAttribute,
            int cbAttribute
        );

        private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;
    }
}