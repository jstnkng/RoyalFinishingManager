﻿using RFDesktopManager;
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

namespace RFDesktopManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static TabControl PageControl;
        public MainWindow()
        {
            InitializeComponent();
            PageControl = PageController;
        }

        private void PageController_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TabItem selectedTab = (TabItem)PageController.SelectedItem;
            if (selectedTab == JobsPage)
            {
                RFDesktopManager.Pages.JobsPage tabPage = (RFDesktopManager.Pages.JobsPage)selectedTab.Content;
                
            }
        }
    }
}
