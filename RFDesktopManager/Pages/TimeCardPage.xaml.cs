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
    /// Interaction logic for TimeCardPage.xaml
    /// </summary>
    public partial class TimeCardPage : UserControl
    {
        public TimeCardPage()
        {
            InitializeComponent();
        }

        private void btnAddLabor_Click(object sender, RoutedEventArgs e)
        {
            //Window addLaborWindow = new AddLabor(_viewModel.SelectedEmployee.ID);
            //addLaborWindow.Show();
        }
    }
}
