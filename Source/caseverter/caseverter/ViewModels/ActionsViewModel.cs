using caseverter.Core;
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace caseverter
{
    public class ActionsViewModel : BaseViewModel
    {
        #region Private Members

        /// <summary>
        /// Hotkey to Show ContextMenu
        /// </summary>
        private uint mMenuHotkey;

        /// <summary>
        /// Hotkey to Turn Current Selection Into Uppercase Casing
        /// </summary>
        private uint mUppercaseHotkey;

        /// <summary>
        /// Hotkey to Turn Current Selection Into Lowercase Casing
        /// </summary>
        private uint mLowercaseHotkey;

        /// <summary>
        /// Hotkey to Turn Current Selection Into Titlecase Casing
        /// </summary>
        private uint mTitlecaseHotkey;

        /// <summary>
        /// Hotkey to Turn Current Selection Into Titlecase Casing
        /// </summary>
        private uint mAPATitlecaseHotkey;

        /// <summary>
        /// Hotkey to Turn Current Selection Into Sentence Casing
        /// </summary>
        private uint mSentencecaseHotkey;

        /// <summary>
        /// Hotkey to Turn Current Selection Into Sentence Casing
        /// </summary>
        private uint mAlternatingcaseHotkey;

        #endregion


        #region Commands

        /// <summary>
        /// Command to Show ContextMenu
        /// </summary>
        public ICommand ShowMenuCommand { get; set; }

        /// <summary>
        /// Command to Turn Current Selection Into Uppercase Casing
        /// </summary>
        public ICommand ToUppercaseCommand { get; private set; } 

        /// <summary>
        /// Command to Turn Current Selection Into Lowercase Casing
        /// </summary>
        public ICommand ToLowercaseCommand { get; private set; } 

        /// <summary>
        /// Command to Turn Current Selection Into Titlecase Casing
        /// </summary>
        public ICommand ToTitlecaseCommand { get; private set; }

        /// <summary>
        /// Command to Turn Current Selection Into APA Titlecase Casing
        /// </summary>
        public ICommand ToAPATitlecaseCommand { get; private set; }

        /// <summary>
        /// Command to Turn Current Selection Into Sentence Casing
        /// </summary>
        public ICommand ToSentencecaseCommand { get; private set; }

        /// <summary>
        /// Command to Turn Current Selection Into Sentence Casing
        /// </summary>
        public ICommand ToAlternatingcaseCommand { get; private set; }

        #endregion


        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ActionsViewModel()
        {
            HotkeyHelper.Instance.OnHotkeyPressed = OnHotkeyPress;

            mMenuHotkey = HotkeyHelper.Instance.StartListeningHotkey(System.Windows.Forms.Keys.X, HotkeyModifiers.Control | HotkeyModifiers.Shift);
            mUppercaseHotkey = HotkeyHelper.Instance.StartListeningHotkey(System.Windows.Forms.Keys.D1, HotkeyModifiers.Control | HotkeyModifiers.Alt);
            mLowercaseHotkey = HotkeyHelper.Instance.StartListeningHotkey(System.Windows.Forms.Keys.D2, HotkeyModifiers.Control | HotkeyModifiers.Alt);
            mTitlecaseHotkey = HotkeyHelper.Instance.StartListeningHotkey(System.Windows.Forms.Keys.D3, HotkeyModifiers.Control | HotkeyModifiers.Alt);
            mAPATitlecaseHotkey = HotkeyHelper.Instance.StartListeningHotkey(System.Windows.Forms.Keys.D4, HotkeyModifiers.Control | HotkeyModifiers.Alt);
            mSentencecaseHotkey = HotkeyHelper.Instance.StartListeningHotkey(System.Windows.Forms.Keys.D5, HotkeyModifiers.Control | HotkeyModifiers.Alt);
            mAlternatingcaseHotkey = HotkeyHelper.Instance.StartListeningHotkey(System.Windows.Forms.Keys.D6, HotkeyModifiers.Control | HotkeyModifiers.Alt);

            // Set Command Actions
            ToUppercaseCommand = new RelayCommand(() => ClipboardHelper.PasteText(ClipboardHelper.GetSelectedText().ToUpper()));
            ToLowercaseCommand = new RelayCommand(() => ClipboardHelper.PasteText(ClipboardHelper.GetSelectedText().ToLower()));
            ToTitlecaseCommand = new RelayCommand(() => ClipboardHelper.PasteText(ClipboardHelper.GetSelectedText().ToTitle()));
            ToAPATitlecaseCommand = new RelayCommand(() => ClipboardHelper.PasteText(ClipboardHelper.GetSelectedText().ToAPATitle()));
            ToSentencecaseCommand = new RelayCommand(() => ClipboardHelper.PasteText(ClipboardHelper.GetSelectedText().ToSentence()));
            ToAlternatingcaseCommand = new RelayCommand(() => ClipboardHelper.PasteText(ClipboardHelper.GetSelectedText().ToAlternating()));
        }

        #endregion


        #region Private Methods

        /// <summary>
        /// Hotkey Press Handler 
        /// </summary>
        /// <param name="keyId"></param>
        private void OnHotkeyPress(int keyId)
        {
            Debug.WriteLine(keyId);

            if (keyId == mMenuHotkey)
            {
                ShowMenuCommand.Execute(null);
                FocusHelper.FocusWindow();
            }

            else if (keyId == mUppercaseHotkey)
            {
                FocusHelper.FocusWindow();
                ToUppercaseCommand.Execute(null);
            }

            else if (keyId == mLowercaseHotkey)
            {
                ToLowercaseCommand.Execute(null);
            }

            else if (keyId == mTitlecaseHotkey)
            {
                ToTitlecaseCommand.Execute(null);
            }

            else if (keyId == mAPATitlecaseHotkey)
            {
                ToAPATitlecaseCommand.Execute(null);
            }

            else if (keyId == mSentencecaseHotkey)
            {
                ToSentencecaseCommand.Execute(null);
            }

            else if (keyId == mAlternatingcaseHotkey)
            {
                ToAlternatingcaseCommand.Execute(null);
            }
        }

        #endregion


        #region Event Handlers



        #endregion
    }
}
