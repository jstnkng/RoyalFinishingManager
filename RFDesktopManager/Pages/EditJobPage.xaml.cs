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
            _viewModel = new EditJobViewModel(new Data.Job());
            DataContext = _viewModel;

        }

        private void btnDirections_Click(object sender, RoutedEventArgs e)
        {
            //_viewModel.OpenDirections();
        }
    }
}
