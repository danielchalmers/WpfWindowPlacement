using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace WpfWindowPlacement
{
    public static class WindowPlacementFunctions
    {
        public static WindowPlacement GetPlacement(IntPtr windowHandle)
        {
            NativeMethods.GetWindowPlacement(windowHandle, out WindowPlacement placement);
            return placement;
        }

        public static WindowPlacement GetPlacement(Window window)
        {
            return GetPlacement(new WindowInteropHelper(window).Handle);
        }

        public static void SetPlacement(IntPtr windowHandle, WindowPlacement placement)
        {
            placement.Length = Marshal.SizeOf(typeof(WindowPlacement));

            // Restore window to normal state if minimized.
            if (placement.ShowCommand == NativeMethods.SW_SHOWMINIMIZED)
            {
                placement.ShowCommand = NativeMethods.SW_SHOWNORMAL;
            }

            NativeMethods.SetWindowPlacement(windowHandle, ref placement);
        }

        public static void SetPlacement(Window window, WindowPlacement placement)
        {
            SetPlacement(new WindowInteropHelper(window).Handle, placement);
        }
    }
}