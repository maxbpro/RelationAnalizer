using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Runtime.InteropServices;


namespace BD
{

    [StructLayout(LayoutKind.Sequential)]
    public struct MARGINS
    {
        public int Left;
        public int Right;
        public int Top;
        public int Bottom;

        public MARGINS(Thickness t)
        {
            this.Left = (int)t.Left;
            this.Right = (int)t.Right;
            this.Top = (int)t.Top;
            this.Bottom = (int)t.Bottom;
        }
    }


    public class GlassHelper
    {
        public static bool ExtendGlassFrame(Window window, Thickness margin)
        {
            try
            {
                // desktop window manader must be enabled if it isn't don't bother trying to add glass
                if (!DwmIsCompositionEnabled())
                {
                    return false;
                }

                IntPtr hwnd = new WindowInteropHelper(window).Handle;

                if (hwnd == IntPtr.Zero)
                {
                    throw new InvalidOperationException("The Window must be shown before extending glass.");
                }

                // Set the background to transparent from both the WPF and Win32 perspectives
                //window.Background = Brushes.Transparent;
                HwndSource.FromHwnd(hwnd).CompositionTarget.BackgroundColor = Colors.Transparent;
                
                MARGINS margins = new MARGINS(margin);
                DwmExtendFrameIntoClientArea(hwnd, ref margins);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool ExtendGlassFrame(Window window)
        {
            try
            {
                // desktop window manader must be enabled if it isn't don't bother trying to add glass
                if (!DwmIsCompositionEnabled())
                {
                    return false;
                }

                IntPtr hwnd = new WindowInteropHelper(window).Handle;

                if (hwnd == IntPtr.Zero)
                {
                    throw new InvalidOperationException("The Window must be shown before extending glass.");
                }

                // Set the background to transparent from both the WPF and Win32 perspectives
                //window.Background = Brushes.Transparent;
                HwndSource.FromHwnd(hwnd).CompositionTarget.BackgroundColor = Colors.Transparent;

                MARGINS margins = new MARGINS(new Thickness(2000));
                DwmExtendFrameIntoClientArea(hwnd, ref margins);
                return true;
            }
            catch
            {
                return false;
            }
        }


        [DllImport("dwmapi.dll", PreserveSig = false)]
        private static extern void DwmExtendFrameIntoClientArea(IntPtr hwnd, ref MARGINS margins);


        [DllImport("dwmapi.dll", PreserveSig = false)]
        private static extern bool DwmIsCompositionEnabled();


    }
    //protected override void OnSourceInitialized(EventArgs e)
    //{
    //    // add glass background to main application window
    //    if (!GlassHelper.ExtendGlassFrame(this, new Thickness(-1)))
    //    {
    //        this.Background = (DrawingBrush)this.FindResource("VistaBackground");
    //    }
    //}


}
