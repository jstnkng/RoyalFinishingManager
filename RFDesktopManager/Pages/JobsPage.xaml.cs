using RFDesktopManager.Data;
using RFDesktopManager.Repos;
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

    public partial class JobsPage : UserControl
    {
        public static JobsViewModel _viewModel;

        public static int ID = 1;

        public JobsPage()
        {
            InitializeComponent();
            _viewModel = new JobsViewModel();
            DataContext = _viewModel;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Refresh();
        }

        private void chkStatus1_Checked(object sender, RoutedEventArgs e)
        {
            chkStatus0.IsChecked = false;
            chkStatus2.IsChecked = false;
            chkStatus3.IsChecked = false;
            chkStatus4.IsChecked = false;
            _viewModel.SelectedStatus = 1;
            _viewModel.Refresh();
        }

        private void chkStatus4_Checked(object sender, RoutedEventArgs e)
        {
            chkStatus0.IsChecked = false;
            chkStatus2.IsChecked = false;
            chkStatus3.IsChecked = false;
            chkStatus1.IsChecked = false;
            _viewModel.SelectedStatus = 4;
            _viewModel.Refresh();
        }

        private void chkStatus3_Checked(object sender, RoutedEventArgs e)
        {
            chkStatus0.IsChecked = false;
            chkStatus2.IsChecked = false;
            chkStatus1.IsChecked = false;
            chkStatus4.IsChecked = false;
            _viewModel.SelectedStatus = 3;
            _viewModel.Refresh();
        }

        private void chkStatus2_Checked(object sender, RoutedEventArgs e)
        {
            chkStatus0.IsChecked = false;
            chkStatus1.IsChecked = false;
            chkStatus3.IsChecked = false;
            chkStatus4.IsChecked = false;
            _viewModel.SelectedStatus = 2;
            _viewModel.Refresh();
        }

        private void chkStatus0_Checked(object sender, RoutedEventArgs e)
        {
            chkStatus1.IsChecked = false;
            chkStatus2.IsChecked = false;
            chkStatus3.IsChecked = false;
            chkStatus4.IsChecked = false;
            _viewModel.SelectedStatus = 0;
            _viewModel.Refresh();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.PageControl.SelectedIndex = HomePage.ID;

        }

        private void listJobs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listJobs.UnselectAll();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrEmpty(txtSearch.Text))
            {
                _viewModel.Refresh();
            }
            else
            {
                _viewModel.Search(txtSearch.Text);
            }
        }
    }
}
