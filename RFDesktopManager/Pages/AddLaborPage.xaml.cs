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
    /// Interaction logic for AddLaborPage.xaml
    /// </summary>
    public partial class AddLaborPage : UserControl
    {
        private AddLaborViewModel _viewModel;

        public static int ID = 4;

        public AddLaborPage()
        {
            InitializeComponent();
            _viewModel = new AddLaborViewModel();
            DataContext = _viewModel;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.AddLabor();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.PageControl.SelectedIndex = EditJobPage.ID;
        }
    }
}
