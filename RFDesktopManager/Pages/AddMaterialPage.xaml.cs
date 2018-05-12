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
    /// Interaction logic for AddMaterialPage.xaml
    /// </summary>
    public partial class AddMaterialPage : UserControl
    {
        private AddMaterialViewModel _viewModel;

        public AddMaterialPage()
        {
            InitializeComponent();
            _viewModel = new AddMaterialViewModel();
            DataContext = _viewModel;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //_viewModel.Save();
        }
    }
}
