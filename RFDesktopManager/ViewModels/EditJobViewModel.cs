﻿using RFDesktopManager.Data;
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

        private string _Address;

        public string Address
        {
            get
            {
                return _Address;
            }
            set
            {
                var fullAddress = new StringBuilder();

                
            }
        }


        public EditJobViewModel()
        {
            JobModel = new Job();
            StatusList = RFRepo.GetJobStatusList();
        }

        public void OpenDirections()
        {
            System.Diagnostics.Process.Start("https://maps.google.com/?q=" + JobModel.Address);
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
