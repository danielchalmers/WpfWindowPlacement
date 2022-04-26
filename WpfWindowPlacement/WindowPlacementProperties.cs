using System;
using System.ComponentModel;
using System.Windows;

namespace WpfWindowPlacement
{
    /// <summary>
    /// <para>Attached properties for <see cref="WindowPlacement" /> in XAML.</para>
    /// <para>See <see cref="WindowPlacementFunctions"/> for use in code-behind.</para>
    /// </summary>
    public static class WindowPlacementProperties
    {
        /// <summary>
        /// The <see cref="WindowPlacement" /> property used by <see cref="TrackPlacementProperty" />.
        /// </summary>
        public static readonly DependencyProperty PlacementProperty =
            DependencyProperty.RegisterAttached(
                "Placement",
                typeof(WindowPlacement),
                typeof(WindowPlacementProperties),
                new FrameworkPropertyMetadata(default(WindowPlacement), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnPlacementChanged));

        /// <summary>
        /// Set window's placement to <see cref="PlacementProperty"/> on source initialization, and vice versa on window closing.
        /// </summary>
        public static readonly DependencyProperty TrackPlacementProperty =
            DependencyProperty.RegisterAttached(
                "TrackPlacement",
                typeof(bool),
                typeof(WindowPlacementProperties),
                new PropertyMetadata(false, OnTrackPlacementChanged));
       
        public static WindowPlacement GetPlacement(Window sender) => (WindowPlacement)sender.GetValue(PlacementProperty);
        public static void SetPlacement(Window sender, WindowPlacement value) => sender.SetValue(PlacementProperty, value);
        public static bool GetTrackPlacement(Window sender) => (bool)sender.GetValue(TrackPlacementProperty);
        public static void SetTrackPlacement(Window sender, bool value) => sender.SetValue(TrackPlacementProperty, value);

        private static void OnPlacementChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var window = (Window)sender;
            var placement = (WindowPlacement)e.NewValue;

            WindowPlacementFunctions.SetPlacement(window, placement);
        }

        private static void OnTrackPlacementChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var window = (Window)sender;
            var track = (bool)e.NewValue;

            if (track)
            {
                window.SourceInitialized += Window_SourceInitialized;
                window.Closing += Window_Closing;
            }
            else
            {
                window.SourceInitialized -= Window_SourceInitialized;
                window.Closing -= Window_Closing;
            }
        }

        private static void Window_Closing(object sender, CancelEventArgs e)
        {
            var window = (Window)sender;
            var placement = WindowPlacementFunctions.GetPlacement(window);

            SetPlacement(window, placement);
        }

        private static void Window_SourceInitialized(object sender, EventArgs e)
        {
            var window = (Window)sender;
            var placement = GetPlacement(window);

            WindowPlacementFunctions.SetPlacement(window, placement);
        }
    }
}