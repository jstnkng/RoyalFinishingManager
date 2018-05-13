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
        public JobsPage()
        {
            InitializeComponent();
            _viewModel = new JobsViewModel();
            DataContext = _viewModel;
        }


        public static int selectedStatus = 0;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Refresh(selectedStatus);
        }

        private void chkStatus1_Checked(object sender, RoutedEventArgs e)
        {
            chkStatus0.IsChecked = false;
            chkStatus2.IsChecked = false;
            chkStatus3.IsChecked = false;
            chkStatus4.IsChecked = false;
            _viewModel.Refresh(1);
            selectedStatus = 1;
        }

        private void chkStatus4_Checked(object sender, RoutedEventArgs e)
        {
            chkStatus0.IsChecked = false;
            chkStatus2.IsChecked = false;
            chkStatus3.IsChecked = false;
            chkStatus1.IsChecked = false;
            _viewModel.Refresh(4);
            selectedStatus = 4;
        }

        private void chkStatus3_Checked(object sender, RoutedEventArgs e)
        {
            chkStatus0.IsChecked = false;
            chkStatus2.IsChecked = false;
            chkStatus1.IsChecked = false;
            chkStatus4.IsChecked = false;
            _viewModel.Refresh(3);
            selectedStatus = 3;
        }

        private void chkStatus2_Checked(object sender, RoutedEventArgs e)
        {
            chkStatus0.IsChecked = false;
            chkStatus1.IsChecked = false;
            chkStatus3.IsChecked = false;
            chkStatus4.IsChecked = false;
            _viewModel.Refresh(2);
            selectedStatus = 2;
        }

        private void chkStatus0_Checked(object sender, RoutedEventArgs e)
        {
            chkStatus1.IsChecked = false;
            chkStatus2.IsChecked = false;
            chkStatus3.IsChecked = false;
            chkStatus4.IsChecked = false;
            _viewModel.Refresh(0);
            selectedStatus = 0;
        }
    }
}
