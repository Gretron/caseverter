using Gma.System.MouseKeyHook;
using System.Collections.Generic;
using System.Windows.Forms;

namespace caseverter
{
    /// <summary>
    /// Hook for Global Keyboard & Mouse Events
    /// </summary>
    public class GlobalHook
    {
        #region Private Members

        /// <summary>
        /// Instance of the Global Keyboard & Mouse Events
        /// </summary>
        private static IKeyboardMouseEvents Instance = Hook.GlobalEvents();

        /// <summary>
        /// Global KeyDown Event Handlers
        /// </summary>
        private static List<KeyEventHandler> mKeyDownHandlers = new List<KeyEventHandler>();

        /// <summary>
        /// Global KeyUp Event Handlers
        /// </summary>
        private static List<KeyEventHandler> mKeyUpHandlers = new List<KeyEventHandler>();

        #endregion


        #region Public Properties

        /// <summary>
        /// Bool Dictating Whether Globalhook Is Usable or Not
        /// </summary>
        public bool Enabled { get; set; } = true;

        #endregion


        #region Public Methods

        /// <summary>
        /// Add KeyDown Handler to Global Event & List
        /// </summary>
        /// <param name="handler"></param>
        public static void AddKeyDownHandler(KeyEventHandler handler)
        {
            mKeyDownHandlers.Add(handler);
            Instance.KeyDown += handler;
        }

        /// <summary>
        /// Add KeyUp Handler to Global Event & List
        /// </summary>
        /// <param name="handler"></param>
        public static void AddKeyUpHandler(KeyEventHandler handler)
        {
            mKeyUpHandlers.Add(handler);
            Instance.KeyUp += handler;
        }

        /// <summary>
        /// Clear KeyDown Handlers
        /// </summary>
        public static void ClearKeyDownHandlers()
        {
            foreach(KeyEventHandler handler in mKeyDownHandlers)
            {
                Instance.KeyDown -= handler;
            }
        }

        /// <summary>
        /// Clear KeyUp Handlers
        /// </summary>
        public static void ClearKeyUpHandlers()
        {
            foreach (KeyEventHandler handler in mKeyUpHandlers)
            {
                Instance.KeyUp -= handler;
            }
        }

        /// <summary>
        /// Dispose of GlobalHook & Clear Handlers
        /// </summary>
        public static void Dispose()
        {
            ClearKeyDownHandlers();
            ClearKeyUpHandlers();

            Instance.Dispose();
        }

        #endregion
    }
}
