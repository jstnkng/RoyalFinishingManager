﻿using System;
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

namespace RFDesktopManager.Pages
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : UserControl
    {
        public static int ID = 0;

        public HomePage()
        {
            InitializeComponent();
        }

        private void btnNewJob_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.PageControl.SelectedIndex = AddJobPage.ID;
        }

        private void btnOpenJob_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.PageControl.SelectedIndex = JobsPage.ID;
            JobsPage._viewModel.Refresh();
        }

        private void btnTimeCard_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.PageControl.SelectedIndex = TimeCardPage.ID;
        }
    }
}
