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
    /// <summary>
    /// Interaction logic for EditJobPage.xaml
    /// </summary>
    public partial class EditJobPage : UserControl
    {
        public static EditJobViewModel _viewModel;

        public static int ID = 2;

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
            Refresh();
        }

        public static void Refresh()
        {
            _viewModel.LoadJob(_viewModel.JobModel.ID);
            _viewModel.SelectedStatus = RFRepo.GetStatusType(_viewModel.JobModel.StatusID);
        }

        private void btnLabor_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.PageControl.SelectedIndex = AddLaborPage.ID;
            AddLaborPage._viewModel.SelectedJob = RFRepo.GetJob(_viewModel.JobModel.ID).Name;
        }

        private void btnMaterial_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.PageControl.SelectedIndex = AddMaterialPage.ID;
            AddMaterialPage._viewModel.JobName = _viewModel.JobModel.Name;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.PageControl.SelectedIndex = JobsPage.ID;
            JobsPage._viewModel.Refresh();
        }

        private void txtSqFt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void chkHour_Click(object sender, RoutedEventArgs e)
        {
            chkSqFt.IsChecked = false;
            _viewModel.Refresh();
        }

        private void chkSqFt_Click(object sender, RoutedEventArgs e)
        {
            chkHour.IsChecked = false;
            _viewModel.Refresh();
        }
    }
}
