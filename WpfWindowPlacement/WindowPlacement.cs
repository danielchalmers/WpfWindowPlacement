﻿using System;
using System.Runtime.InteropServices;

namespace WpfWindowPlacement
{
    /// <summary>
    /// Contains information about the placement of a window on the screen.
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct WindowPlacement
    {
        /// <summary>
        /// The length of the structure, in bytes.
        /// </summary>
        public int Length;

        /// <summary>
        /// The flags that control the position of the minimized window and the method by which the window is restored. This member can be one or more of the following values.
        /// </summary>
        public int Flags;

        /// <summary>
        /// The current show state of the window.
        /// </summary>
        public int ShowCommand;

        /// <summary>
        /// The coordinates of the window's upper-left corner when the window is minimized.
        /// </summary>
        public Point MinimizedPosition;

        /// <summary>
        /// The coordinates of the window's upper-left corner when the window is maximized.
        /// </summary>
        public Point MaximizedPosition;

        /// <summary>
        /// The window's coordinates when the window is in the restored position.
        /// </summary>
        public Rect NormalBounds;
    }
}