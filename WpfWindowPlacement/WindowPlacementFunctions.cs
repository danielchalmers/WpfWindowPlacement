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
            var placement = new WindowPlacement
            {
                Length = Marshal.SizeOf(typeof(WindowPlacement))
            };
            NativeMethods.GetWindowPlacement(windowHandle, out placement);
            return placement;
        }

        public static WindowPlacement GetPlacement(this Window window)
        {
            return GetPlacement(new WindowInteropHelper(window).Handle);
        }

        public static void SetPlacement(IntPtr windowHandle, WindowPlacement placement)
        {
            // Don't continue if placement is default.
            if (placement.Equals(default(WindowPlacement)))
            {
                return;
            }

            placement.Length = Marshal.SizeOf(typeof(WindowPlacement));

            // Restore window to normal state if minimized.
            if (placement.ShowCommand == WindowPlacementShowCommands.ShowMinimized)
            {
                placement.ShowCommand = WindowPlacementShowCommands.ShowNormal;
            }

            NativeMethods.SetWindowPlacement(windowHandle, ref placement);
        }

        public static void SetPlacement(this Window window, WindowPlacement placement)
        {
            SetPlacement(new WindowInteropHelper(window).Handle, placement);
        }
    }
}