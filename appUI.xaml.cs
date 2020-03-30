using ACMApp.UI;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using SharpDX.DXGI;
using Control = System.Windows.Controls.Control;

namespace ACMApp
{
    /// <summary>
    /// Interaction logic for appUI.xaml
    /// </summary>
    public partial class appUI : Window
    {
        // event and handler now owned by app, not form
        //private requestHandler _handler;

        //private ExternalEvent _exEvent;

        /// <summary>
        /// Constructor for WPF window.
        /// </summary>
        public appUI()
        {
            //_handler = acmPanelApp.Instance.handler;
            //_exEvent = acmPanelApp.Instance.exEvent;

            this.DataContext = new mainViewModel(); 

            WindowInteropHelper wih = new WindowInteropHelper(this);
            wih.Owner = acmPanelApp.Instance.RevitWindowHandle;

            InitializeComponent();
        }

        /// <summary>
        /// Dispose event and handler when window is closed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void windowClosed(object sender, EventArgs e)
        {
            // we own both the event and the handler
            // we should dispose it before we are closed

            //_exEvent.Dispose();
            //_exEvent = null;
            //_handler = null;
        }

        /// <summary>
        ///   Control enabler / disabler
        /// </summary>
        ///
        private void enableCommands(bool status)
        {
            foreach (Control ctrl in findVisualChildren<Control>(this))
            {
                ctrl.IsEnabled = status;
            }
            if (!status)
            {
                //btnExit.IsEnabled = true;
            }
        }

        #region UI Basics

        /// <summary>
        ///   A private helper method to make a request
        ///   and put the dialog to sleep at the same time.
        /// </summary>
        /// <remarks>
        ///   It is expected that the process which executes the request
        ///   (the Idling helper in this particular case) will also
        ///   wake the dialog up after finishing the execution.
        /// </remarks>
        ///
        //private void makeRequest(requestId request)
        //{
        //    _handler.Request.make(request);
        //    _exEvent.Raise();
        //    dozeOff();
        //}

        /// <summary>
        ///   dozeOff -> disable all controls (but the Exit button)
        /// </summary>
        ///
        private void dozeOff()
        {
            enableCommands(false);
        }

        /// <summary>
        ///   wakeUp -> enable all controls
        /// </summary>
        ///
        public void wakeUp()
        {
            enableCommands(true);
        }

        /// <summary>
        /// Finds controls on the WPF form.
        /// </summary>
        /// <typeparam name="T">Control to collect.</typeparam>
        /// <param name="depObj">Form.</param>
        /// <returns></returns>
        public static IEnumerable<T> findVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in findVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        #endregion UI Basics
    }
}