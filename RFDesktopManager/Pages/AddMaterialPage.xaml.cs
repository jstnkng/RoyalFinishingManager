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
    public partial class AddMaterialPage : UserControl
    {
        public static AddMaterialViewModel _viewModel;

        public static int ID = 5;

        public AddMaterialPage()
        {
            InitializeComponent();
            _viewModel = new AddMaterialViewModel();
            DataContext = _viewModel;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Save();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.PageControl.SelectedIndex = EditJobPage.ID;
            EditJobPage.Refresh();
        }
    }
}
