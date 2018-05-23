using RFDesktopManager.Data;
using RFDesktopManager.Pages;
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
                if (value != null)
                {
                    MainWindow.PageControl.SelectedIndex = 2;
                    EditJobPage._viewModel.Refresh(value.ID);
                    EditJobPage._viewModel.SelectedStatus = RFRepo.GetStatusType(EditJobPage._viewModel.JobModel.StatusID);
                }
                _selectedJob = value;
            }
        }

        public int SelectedStatus { get; set; }

        public JobsViewModel()
        {
            _JobsList = RFRepo.GetJobs(0);
            RaisePropertyChanged("JobsList");
            SelectedSort = "";
        }

        public void Refresh()
        {
            if (SelectedSort.Contains("Name")) SortByName();
            else if (SelectedSort.Contains("City")) SortByCity();
            else
            {
                _JobsList = RFRepo.GetJobs(SelectedStatus);
                RaisePropertyChanged("JobsList");
            }
        }

        public void Search(string text)
        {
            JobsList.Clear();
            RaisePropertyChanged("JobsList");
            JobsList = RFRepo.SearchForJobs(text, SelectedStatus);
            RaisePropertyChanged("JobsList");
        }

        private string _SelectedSort;

        public string SelectedSort
        {
            get { return _SelectedSort; }
            set
            {
                _SelectedSort = value;
                RaisePropertyChanged("SelectedSort");
                Refresh();
            }
        }

        public void SortByName()
        {
            JobsList = RFRepo.SortJobsByName(SelectedStatus);
            RaisePropertyChanged("JobsList");
        }

        public void SortByCity()
        {
            JobsList = RFRepo.SortJobsByCity(SelectedStatus);
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
