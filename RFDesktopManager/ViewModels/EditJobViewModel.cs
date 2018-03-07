using RFDesktopManager.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RFDesktopManager.ViewModels
{
    public class EditJobViewModel : DependencyObject, INotifyPropertyChanged
    {

        private Job jobModel;

        public Job JobModel
        {
            get { return jobModel; }
            set
            {
                jobModel = value;
                RaisePropertyChanged("JobModel");
            }
        }

        public EditJobViewModel(Job selectedJob)
        {
            JobModel = selectedJob;
        }

        public void OpenDirections()
        {
            System.Diagnostics.Process.Start("https://maps.google.com/?q=" + JobModel.Address);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
