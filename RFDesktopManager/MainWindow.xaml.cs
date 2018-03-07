using RFDesktopManager;
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

namespace RFDesktopManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void btnAddJob_Click(object sender, RoutedEventArgs e)
        {
            Window jobWindow = new AddJob();
            jobWindow.Activate();
            jobWindow.Show();
        }

        private void btnJobs_Click(object sender, RoutedEventArgs e)
        {
            Window jobsWindow = new Jobs();
            jobsWindow.Activate();
            jobsWindow.Show();
        }

        private void btnTimeCards_Click(object sender, RoutedEventArgs e)
        {
            Window timeCardWindow = new TimeCard();
            timeCardWindow.Activate();
            timeCardWindow.Show();
        }

        private void btnMaterials_Click(object sender, RoutedEventArgs e)
        {
            Window materialWindow = new AddMaterial();
            materialWindow.Activate();
            materialWindow.Show();
        }
    }
}
