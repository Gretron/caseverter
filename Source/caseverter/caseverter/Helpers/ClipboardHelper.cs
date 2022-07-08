using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Input;

namespace caseverter
{
    /// <summary>
    /// Helper for Clipboard Functions
    /// </summary>
    public static class ClipboardHelper
    {      
        #region Public Methods

        /// <summary>
        /// Get Selected Text from Any Application
        /// </summary>
        /// <returns></returns>
        public static string GetSelectedText()
        {
            // Set Foreground Window to Previous Window
            SetForegroundWindow(FocusHelper.FocusedWindow);

            // Cache Previous Clipboard
            var previous = Clipboard.GetText();

            // Send Copy Shortcut
            SendKeys.SendWait("^(c)");

            // Get Clipboard Text
            var clipboard = Clipboard.GetText();

            try
            {
                // Restore Previous Clipboard
                Clipboard.SetText(previous);
            }

            catch { }

            // Return Selected Text
            return clipboard;
        }

        /// <summary>
        /// Paste String
        /// </summary>
        /// <param name="text"></param>
        public static void PasteText(string text)
        {
            // Cache Previous Clipboard
            var previous = Clipboard.GetText();

            // Set Clipboard to Uppercase Version of the Selected Text
            try
            {
                Clipboard.SetText(text);
            }

            catch { }

            // Send Paste Shortcut
            SendKeys.SendWait("^(v)");
   
            try
            {
                // Restore Previous Clipboard
                Clipboard.SetText(previous);
            }

            catch { }
        }

        #endregion


        #region DLL Imports

        [DllImport("user32")]
        private static extern bool SetForegroundWindow(IntPtr hwnd);

        #endregion
    }
}
