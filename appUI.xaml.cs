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
        /// <summary>
        /// Constructor for WPF window.
        /// </summary>
        public appUI()
        {

            this.DataContext = new mainViewModel(); 

            InitializeComponent();
        }
    }
}
