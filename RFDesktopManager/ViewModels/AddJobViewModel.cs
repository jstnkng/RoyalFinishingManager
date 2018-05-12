using RFDesktopManager.Data;
using RFDesktopManager.Pages;
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
    public class AddJobViewModel : DependencyObject, INotifyPropertyChanged
    {

        private Job _JobModel;

        

        public Job JobModel
        {
            get { return _JobModel; }
            set
            {
                _JobModel = value;
                RaisePropertyChanged("JobModel");
            }
        }

        public AddJobViewModel()
        {
            JobModel = new Job();
            JobModel.Name = "";
            JobModel.Address = "";
            JobModel.Description = "";
            JobModel.StatusID = 1;         
        }

        public void SaveJob()
        {
            RFRepo.AddJob(JobModel);
            MessageBox.Show("Job added");
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
