using System;
using System.Runtime.InteropServices;

namespace WpfWindowPlacement
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct WindowPlacement
    {
        public int Length;
        public int Flags;
        public int ShowCommand;
        public Point MinimizedPosition;
        public Point MaximizedPosition;
        public Rect NormalBounds;
    }
}