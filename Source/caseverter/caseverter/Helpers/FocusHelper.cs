using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Interop;

namespace caseverter
{
    /// <summary>
    /// Helper to Track Focused Window
    /// </summary>
    public static class FocusHelper
    {
        #region Private Members

        /// <summary>
        /// Application Window
        /// </summary>
        private static Window mWindow;

        /// <summary>
        /// Application Title
        /// </summary>
        private static string mTitle;

        #endregion


        #region Public Members

        /// <summary>
        /// Focused Window That Is Not This Application
        /// </summary>
        public static IntPtr FocusedWindow = IntPtr.Zero;

        #endregion


        #region Public Methods

        /// <summary>
        /// Initializes Helper & Adds Automation Hook Event Handler to Focus Changed Event
        /// </summary>
        public static void Setup(Window window)
        {
            mWindow = window;
            mTitle = window.Title;

            Automation.AddAutomationFocusChangedEventHandler(OnFocusChangedHandler);
        }

        /// <summary>
        /// Focus Main Application Window
        /// </summary>
        public static void FocusWindow()
        {
            if (mWindow == null)
                return;

            var handle = new WindowInteropHelper(mWindow).Handle;

            SetForegroundWindow(handle);
        }

        #endregion


        #region Event Handlers

        /// <summary>
        /// FocusedChanged Event Handler
        /// </summary>
        /// <param name="src"></param>
        /// <param name="src"></param>
        /// <param name="args"></param>
        private static void OnFocusChangedHandler(object src, AutomationFocusChangedEventArgs args)
        {
            AutomationElement element = src as AutomationElement;

            try
            {
                if (element != null)
                {
                    string name = element.Current.Name;
                    string id = element.Current.AutomationId;
                    int processId = element.Current.ProcessId;

                    using (Process process = Process.GetProcessById(processId))
                    {
                        if (process.ProcessName != mTitle)
                        {
                            Debug.WriteLine(process.ProcessName);
                            FocusedWindow = GetForegroundWindow();
                        }
                    }
                }
            }

            catch { /* To Prevent Closing Program Exception */ }
        }

        #endregion


        #region Dll Imports

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        #endregion
    }
}
