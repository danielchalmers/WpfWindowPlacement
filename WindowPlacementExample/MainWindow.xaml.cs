﻿using System;
using System.ComponentModel;
using System.Windows;
using WindowPlacementExample.Properties;
using WpfWindowPlacement;

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

            Settings.Default.PropertyChanged += Settings_PropertyChanged;
        }

        private void Settings_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(Settings.Default.MainWindowPlacement))
                PlacementPropertyLog.Text += DateTime.Now.ToLongTimeString() + ": Placement property updated!" + Environment.NewLine;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Settings.Default.Save();
        }

        private void ManualSaveButton_Click(object sender, RoutedEventArgs e)
        {
            Settings.Default.MainWindowPlacement = WindowPlacementFunctions.GetPlacement(this);

            Settings.Default.Save();
        }

        private void ManualLoadButton_Click(object sender, RoutedEventArgs e)
        {
            WindowPlacementFunctions.SetPlacement(this, Settings.Default.MainWindowPlacement);
        }
    }
}