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

        public AddLaborViewModel(int employeeID)
        {
            JobsList = RFRepo.GetJobs(0);
            LaborModel = new Labor();
            LaborModel.EmployeeID = employeeID;
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
