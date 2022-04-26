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
        public static readonly DependencyProperty PlacementProperty =
            DependencyProperty.RegisterAttached(
                "Placement",
                typeof(WindowPlacement),
                typeof(WindowPlacementProperties),
                new FrameworkPropertyMetadata(default(WindowPlacement), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnPlacementPropertyChanged));

        public static WindowPlacement GetPlacement(Window sender) => (WindowPlacement)sender.GetValue(PlacementProperty);
        public static void SetPlacement(Window sender, WindowPlacement value) => sender.SetValue(PlacementProperty, value);

        private static void OnPlacementPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (DesignerProperties.GetIsInDesignMode(sender))
                return;

            var window = (Window)sender;
            var placement = (WindowPlacement)e.NewValue;

            // Set the window's placement from the property as soon as we have an hWnd to work with.
            if (window.IsInitialized)
            {
                WindowPlacementFunctions.SetPlacement(window, placement);
            }
            else
            {
                // Unsubscribe first in case we already were subscribed so we only have one subscription.
                window.SourceInitialized -= Window_SourceInitialized;
                window.SourceInitialized += Window_SourceInitialized;
            }

            window.Closing -= UpdatePlacementProperty;
            window.Closing += UpdatePlacementProperty;
        }

        private static void Window_SourceInitialized(object sender, EventArgs e)
        {
            var window = (Window)sender;

            window.SetPlacement(GetPlacement(window));
        }

        private static void UpdatePlacementProperty(object sender, EventArgs e)
        {
            var window = (Window)sender;
            var placement = WindowPlacementFunctions.GetPlacement(window);

            SetPlacement(window, placement);
        }
    }
}