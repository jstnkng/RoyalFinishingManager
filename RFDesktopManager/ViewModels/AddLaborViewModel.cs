using RFDesktopManager.Data;
using RFDesktopManager.Repos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RFDesktopManager.ViewModels
{
    public class AddLaborViewModel : DependencyObject, INotifyPropertyChanged
    {


        private Labor _LaborModel;

        public Labor LaborModel
        {
            get { return _LaborModel; }
            set
            {
                _LaborModel = value;
                RaisePropertyChanged("LaborModel");
            }
        }

        public bool SearchAllJobs { get; set; }

        public AddLaborViewModel()
        {
            EmployeeList = RFRepo.GetEmployees();
            if (SearchAllJobs) JobsList = RFRepo.GetJobs(0);
            else JobsList = RFRepo.GetJobs(RFRepo.JobStatusInProgress);
            LaborModel = new Labor();
        }

        public void RefreshJobs()
        {
            if (SearchAllJobs) JobsList = RFRepo.GetJobs(0);
            else JobsList = RFRepo.GetJobs(RFRepo.JobStatusInProgress);
        }

        public TimeSpan span1 = new TimeSpan();

        public TimeSpan span2 = new TimeSpan();


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

        private List<Employee> _EmployeeList;

        public List<Employee> EmployeeList
        {
            get { return _EmployeeList; }
            set
            {
                _EmployeeList = value;

                RaisePropertyChanged("EmployeeList");
            }
        }

        private string _SelectedEmployee;

        public string SelectedEmployee
        {
            get { return _SelectedEmployee; }
            set
            {
                _SelectedEmployee = value;
                LaborModel.EmployeeID = RFRepo.GetEmployeeID(value);
                RaisePropertyChanged("SelectedEmployee");
            }
        }

        private string _SelectedJob;

        public string SelectedJob
        {
            get { return _SelectedJob; }
            set
            {
                _SelectedJob = value;
                LaborModel.JobID = RFRepo.GetJobID(value);
                RaisePropertyChanged("SelectedJob");
            }
        }

        private string _Time1;

        public string Time1
        {
            get { return _Time1; }
            set
            {
                _Time1 = value;
                if (!(String.IsNullOrEmpty(Time2)))
                {
                    span1 = DateTime.Parse(Time2).Subtract(DateTime.Parse(Time1));
                    LaborModel.Hours = (decimal)span1.TotalHours + (decimal)span2.TotalHours;
                    RaisePropertyChanged("TotalHours");
                }
                RaisePropertyChanged("Time1");
            }
        }

        private string _Time2;

        public string Time2
        {
            get { return _Time2; }
            set
            {
                _Time2 = value;
                span1 = DateTime.Parse(Time2).Subtract(DateTime.Parse(Time1));
                LaborModel.Hours = (decimal)span1.TotalHours + (decimal)span2.TotalHours;
                RaisePropertyChanged("TotalHours");
                RaisePropertyChanged("Time2");
            }
        }

        private string _Time3;

        public string Time3
        {
            get { return _Time3; }
            set
            {
                _Time3 = value;
                if (!(String.IsNullOrEmpty(Time4)))
                {
                    span2 = DateTime.Parse(Time4).Subtract(DateTime.Parse(Time3));
                    LaborModel.Hours = (decimal)span1.TotalHours + (decimal)span2.TotalHours;
                    RaisePropertyChanged("TotalHours");
                }
                RaisePropertyChanged("Time3");
            }
        }

        private string _Time4;

        public string Time4
        {
            get { return _Time4; }
            set
            {
                _Time4 = value;
                span2 = DateTime.Parse(Time4).Subtract(DateTime.Parse(Time3));
                LaborModel.Hours = (decimal)span1.TotalHours + (decimal)span2.TotalHours;
                RaisePropertyChanged("TotalHours");
                RaisePropertyChanged("Time4");
            }
        }



        public void AddLabor()
        {
            RFRepo.AddLabor(LaborModel);
            MessageBox.Show("Labor added");
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
