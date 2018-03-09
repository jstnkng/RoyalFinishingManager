using RFDesktopManager.Data;
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
    /// Interaction logic for JobsPage.xaml
    /// </summary>
    public partial class JobsPage : UserControl
    {
        public JobsPage()
        {
            InitializeComponent();
        }

        private void listJobs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Job selectedLabor = (Job)listJobs.SelectedItems[0];
            //Window editJobWindow = new EditJob(selectedLabor);
            //editJobWindow.Show();
        }
    }
}
