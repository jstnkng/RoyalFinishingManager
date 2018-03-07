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
using System.Windows.Shapes;

namespace RFDesktopManager
{
    /// <summary>
    /// Interaction logic for Jobs.xaml
    /// </summary>
    public partial class Jobs : Window
    {
        private JobsViewModel _viewModel;

        public Jobs()
        {
            InitializeComponent();
            _viewModel = new JobsViewModel();
            DataContext = _viewModel;
        }

        private void listJobs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Job selectedLabor = (Job)listJobs.SelectedItems[0];
            Window editJobWindow = new EditJob(selectedLabor);
            editJobWindow.Show();
        }
    }
}
