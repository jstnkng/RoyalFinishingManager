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

        private List<MaterialModel> _MaterialsList;

        public List<MaterialModel> MaterialsList
        {
            get { return _MaterialsList; }
            set
            {
                _MaterialsList = value;
                RaisePropertyChanged("MaterialsList");
            }
        }

        public EditJobViewModel()
        {
            JobModel = new Job();
            StatusList = RFRepo.GetJobStatusList();
        }

        public void OpenDirections()
        {
            var fullAddress = new StringBuilder(JobModel.Address);
            fullAddress.Append(" ,");
            fullAddress.Append(JobModel.City);
            fullAddress.Append(" ,");
            fullAddress.Append(JobModel.State);
            fullAddress.Append(" ,");
            fullAddress.Append(JobModel.ZipCode);
            System.Diagnostics.Process.Start("https://maps.google.com/?q=" + fullAddress.ToString());
        }

        public void SaveJob()
        {
            RFRepo.SaveJob(JobModel);
        }

        private string _SelectedStatus;

        public string SelectedStatus
        {
            get { return _SelectedStatus; }
            set
            {
                _SelectedStatus = value;
                JobModel.StatusID = RFRepo.GetStatusID(SelectedStatus);
                RaisePropertyChanged("SelectedStatus");
            }
        }

        public List<string> StatusList { get; set; }

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
