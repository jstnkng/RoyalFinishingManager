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
    /// Interaction logic for EditJob.xaml
    /// </summary>
    public partial class EditJob : Window
    {
        private EditJobViewModel _viewModel;
        public EditJob(Job currentJob)
        {
            InitializeComponent();
            _viewModel = new EditJobViewModel(currentJob);
            DataContext = _viewModel;
        }

        private void btnDirections_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.OpenDirections();
        }
    }
}
