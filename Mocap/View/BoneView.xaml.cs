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
    /// Interaction logic for BoneView.xaml
    /// </summary>
    public partial class BoneView : UserControl
    {
        public BoneView()
        {
            InitializeComponent();
        }

        private void cb_sensors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var appvm = AppVM.GetCurrent();

            SensorVM sensor = e.AddedItems[0] as SensorVM; // we assume comboBox so theres always a single selected item
            BoneVM bone = (BoneVM)DataContext;
            var arg = new Tuple<BoneVM, SensorVM>(bone, sensor);
            if (appvm.AssignSensorToBoneCommand.CanExecute(arg))
            {
                appvm.AssignSensorToBoneCommand.Execute(arg);
            };
        }
    }
}
