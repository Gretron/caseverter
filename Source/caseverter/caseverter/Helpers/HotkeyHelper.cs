using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Interop;

namespace caseverter
{
    /// <summary>
    /// Enum to Expose Key Modifiers
    /// </summary>
    public enum HotkeyModifiers
    {
        Alt = 1,        
        Control = 2,    
        Shift = 4,      
        WindowsKey = 8,     
    }

    /// <summary>
    /// Helper to Register Multiple Hotkeys
    /// </summary>
    public class HotkeyHelper : IDisposable
    {
        #region Private Members

        /// <summary>
        /// Handle of the Window Listening to Hotkey Presses
        /// </summary>
        private IntPtr mWindowHandle;

        #endregion


        #region Public Members

        /// <summary>
        /// Message for Hotkey Presses
        /// </summary>
        public const int WM_HOTKEY = 0x312;

        /// <summary>
        /// Instance of the Helper
        /// </summary>
        public static HotkeyHelper Instance;

        /// <summary>
        /// Hotkey Press Handler
        /// </summary>
        public Action<int> OnHotkeyPressed;

        #endregion


        #region Public Properties

        /// <summary>
        /// Unique Identifier to Receive Hotkey Messages
        /// </summary>
        public short HotkeyId { get; private set; }

        #endregion


        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="window"></param>
        /// <param name="hotkeyHandler"></param>
        public HotkeyHelper(Window window, Action<int> hotkeyHandler)
        {
            OnHotkeyPressed = hotkeyHandler;

            // Create Unique Id
            string atom = Thread.CurrentThread.ManagedThreadId.ToString("X8") + GetType().FullName;
            HotkeyId = GlobalAddAtom(atom);

            // Setup Hook to Listen to Hotkeys
            mWindowHandle = new WindowInteropHelper(window).Handle;

            if (mWindowHandle == null)
            {
                throw new ApplicationException("Cannot find window handle.");
            }

            var source = HwndSource.FromHwnd(mWindowHandle);
            source.AddHook(HwndHook);
        }

        #endregion


        #region Publiic Methods

        /// <summary>
        /// Start Listening to Specified Hotkey
        /// </summary>
        /// <param name="key">Hotkey Key</param>
        /// <param name="modifiers">Hotkey Modifiers</param>
        /// <returns></returns>
        public uint StartListeningHotkey(Keys key, HotkeyModifiers modifiers)
        {
            RegisterHotKey(mWindowHandle, HotkeyId, (uint)modifiers, (uint)key);
            return (uint)modifiers | (((uint)key) << 16);
        }

        /// <summary>
        /// Dispose of HotkeyHelper
        /// </summary>
        public void Dispose()
        {
            StopListening();
        }

        #endregion


        #region Private Methods

        /// <summary>
        /// Hook to Process Hotkey Presses
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <param name="handled"></param>
        /// <returns></returns>
        private IntPtr HwndHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == WM_HOTKEY && wParam.ToInt32() == HotkeyId)
            {
                OnHotkeyPressed?.Invoke(lParam.ToInt32());
                handled = true;
            }

            return IntPtr.Zero;
        }

        /// <summary>
        /// Stop Listening for Hotkey Presses
        /// </summary>
        private void StopListening()
        {
            if (HotkeyId != 0)
            {
                UnregisterHotKey(mWindowHandle, HotkeyId);
                GlobalDeleteAtom(HotkeyId);
                HotkeyId = 0;
            }
        }

        #endregion


        #region Dll Imports

        [DllImport("user32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RegisterHotKey(IntPtr hwnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32", SetLastError = true)]
        public static extern int UnregisterHotKey(IntPtr hwnd, int id);

        [DllImport("kernel32", SetLastError = true)]
        public static extern short GlobalAddAtom(string lpString);

        [DllImport("kernel32", SetLastError = true)]
        public static extern short GlobalDeleteAtom(short nAtom);

        #endregion
    }
}
