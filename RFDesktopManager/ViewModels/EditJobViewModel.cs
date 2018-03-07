using RFDesktopManager.Data;
using RFDesktopManager.Models;
using RFDesktopManager.Repos;
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

        private List<LaborModel> _LaborList;

        public List<LaborModel> LaborList
        {
            get { return _LaborList; }
            set
            {
                _LaborList = value;
                RaisePropertyChanged("LaborList");
            }
        }

        public EditJobViewModel(Job selectedJob)
        {
            JobModel = selectedJob;
            LaborList = RFRepo.GetJobLabors(selectedJob.ID);
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
