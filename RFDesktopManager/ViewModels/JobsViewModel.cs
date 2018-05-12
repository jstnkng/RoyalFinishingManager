using RFDesktopManager.Data;
using RFDesktopManager.Repos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RFDesktopManager.ViewModels
{
    public class JobsViewModel : DependencyObject, INotifyPropertyChanged
    {
        private List<Job> _JobsList;

        public List<Job> JobsList
        {
            get { return _JobsList; }
            set
            {
                _JobsList = value;
                RaisePropertyChanged("JobsList");
            }
        }

        private Job _selectedJob;

        public Job SelectedJob
        {
            get
            {
                return _selectedJob;
            }
            set
            {
                _selectedJob = value;
            }
        }

        public JobsViewModel()
        {
            _JobsList = RFRepo.GetJobs();
            RaisePropertyChanged("JobsList");
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
