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
    /// Interaction logic for AddJobPage.xaml
    /// </summary>
    public partial class AddJobPage : UserControl
    {
        private AddJobViewModel _viewModel;

        public static int ID = 3;

        public AddJobPage()
        {
            InitializeComponent();
            _viewModel = new AddJobViewModel();
            DataContext = _viewModel;
        }

        private void btnInvoice_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.SaveJob();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.PageControl.SelectedIndex = HomePage.ID;
        }
    }
}
