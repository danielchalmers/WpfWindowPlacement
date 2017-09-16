using System;
using System.Windows;
using WindowPlacementExample.Properties;

namespace WindowPlacementExample
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

        private void Window_Closed(object sender, EventArgs e)
        {
            Settings.Default.Save();
        }

        private void ManualSaveButton_Click(object sender, RoutedEventArgs e)
        {
            Settings.Default.MainWindowPlacement = WpfWindowPlacement.WindowPlacementFunctions.GetPlacement(this);
            Settings.Default.Save();
        }

        private void ManualLoadButton_Click(object sender, RoutedEventArgs e)
        {
            WpfWindowPlacement.WindowPlacementFunctions.SetPlacement(this, Settings.Default.MainWindowPlacement);
        }
    }
}