using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Interop;

namespace ExternalApplications
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()

        {
            InitializeComponent();
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        IntPtr mainWindowHandle = new WindowInteropHelper(window: new Window()).Handle;
        private void btnOpenExternal_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();
            if (od.ShowDialog() == true);
            {
                Process proc = Process.Start(od.FileName);
                proc.WaitForInputIdle();
                while (proc.MainWindowHandle == IntPtr.Zero)
                {
                    Thread.Sleep(100);
                    proc.Refresh();
                }
                IntPtr windowHandle = mainWindowHandle;
            }
        }
    }
}
