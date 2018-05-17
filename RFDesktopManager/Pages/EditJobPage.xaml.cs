﻿using RFDesktopManager.Repos;
using RFDesktopManager.ViewModels;
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

namespace RFDesktopManager.Pages
{
    /// <summary>
    /// Interaction logic for EditJobPage.xaml
    /// </summary>
    public partial class EditJobPage : UserControl
    {
        public static EditJobViewModel _viewModel;
        public EditJobPage()
        {
            InitializeComponent();
            _viewModel = new EditJobViewModel();
            DataContext = _viewModel;

        }

        private void btnDirections_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.OpenDirections();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.SaveJob();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            //This code is also in the of the jobs page viewmodel
            _viewModel.MaterialsList = RFRepo.GetJobMaterials(_viewModel.JobModel.ID);
            _viewModel.LaborList = RFRepo.GetJobLabors(_viewModel.JobModel.ID);
            foreach (var labor in _viewModel.LaborList)
            {
                _viewModel.Hours += labor.Hours;
            }
            var CityLine = new StringBuilder(_viewModel.JobModel.City);
            CityLine.Append(",");
            CityLine.Append(_viewModel.JobModel.State);
            CityLine.Append(" " + _viewModel.JobModel.ZipCode);
            _viewModel.CityLine = CityLine.ToString();
            _viewModel.SelectedStatus = RFRepo.GetStatusType(_viewModel.JobModel.StatusID);
        }

        private void btnLabor_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.PageControl.SelectedIndex = 5;
        }

        private void btnMaterial_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.PageControl.SelectedIndex = 4;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.PageControl.SelectedIndex = 1;
        }
    }
}
