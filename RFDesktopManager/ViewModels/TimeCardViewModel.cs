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
    public class TimeCardViewModel : DependencyObject, INotifyPropertyChanged
    {

        public TimeCardViewModel()
        {
            EmployeeList = RFRepo.GetEmployees();
            //JobsList = RFRepo.GetJobs();
            if (DateTime.Now.DayOfWeek == DayOfWeek.Monday) StartDate = DateTime.Now;
            else if (DateTime.Now.DayOfWeek == DayOfWeek.Tuesday) StartDate = DateTime.Now.AddDays(-1);
            else if (DateTime.Now.DayOfWeek == DayOfWeek.Wednesday) StartDate = DateTime.Now.AddDays(-2);
            else if (DateTime.Now.DayOfWeek == DayOfWeek.Thursday) StartDate = DateTime.Now.AddDays(-3);
            else if (DateTime.Now.DayOfWeek == DayOfWeek.Friday) StartDate = DateTime.Now.AddDays(-4);
            else if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday) StartDate = DateTime.Now.AddDays(-5);
            else if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday) StartDate = DateTime.Now.AddDays(-6);

            EndDate = StartDate.AddDays(5);
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

        private DateTime _StartDate;
        
        public DateTime StartDate
        {
            get { return _StartDate.Date; }
            set
            {
                _StartDate = value.Date;
                RaisePropertyChanged("StartDate");
            }
        }

        private DateTime _EndDate;

        public DateTime EndDate
        {
            get { return _EndDate.Date; }
            set
            {
                _EndDate = value.Date;
                RaisePropertyChanged("EndDate");
            }
        }

        private Employee _SelectedEmployee;

        public Employee SelectedEmployee
        {
            get { return _SelectedEmployee; }
            set
            {
                _SelectedEmployee = value;
                RaisePropertyChanged("SelectedEmployee");
                
                LaborList = RFRepo.GetEmployeeLabor(SelectedEmployee.ID, StartDate, EndDate);

            }
        }

        private decimal _hours;

        public decimal Hours
        {
            get { return _hours; }
            set
            {
                _hours = value;
                RaisePropertyChanged("Hours");
            }
        }

        private List<LaborModel> _LaborList;

        public List<LaborModel> LaborList
        {
            get { return _LaborList; }
            set
            {
                _LaborList = value;
                foreach (var labor in _LaborList)
                {
                    Hours += labor.Hours;
                }
                RaisePropertyChanged("Hours");
                RaisePropertyChanged("LaborList");
            }
        }

        private List<Job> _JobsList;

        public List<Job> JobsList
        {
            get { return JobsList; }
            set
            {
                _JobsList = value;
                RaisePropertyChanged("JobsList");
            }
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
