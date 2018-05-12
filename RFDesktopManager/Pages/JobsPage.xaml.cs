using RFDesktopManager.Data;
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


        private void listJobs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Job selectedJob = (Job)listJobs.SelectedItems[0];
            MainWindow.PageControl.SelectedIndex = 2;
            EditJobPage._viewModel.JobModel = selectedJob;
        }
    }
}
