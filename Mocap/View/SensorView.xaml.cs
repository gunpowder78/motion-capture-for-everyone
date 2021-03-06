﻿using Mocap.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mocap.View
{
    /// <summary>
    /// Interaction logic for SensorView.xaml
    /// </summary>
    public partial class SensorView : UserControl
    {
        private SensorDetailsWindow detailsWindow = new SensorDetailsWindow();

        public SensorView()
        {
            InitializeComponent();
        }

        private void OnDetailsViewButtonClick(object sender, RoutedEventArgs e)
        {
            detailsWindow.Sensor = DataContext as SensorVM;
            detailsWindow.Show();
        }
    }
}
