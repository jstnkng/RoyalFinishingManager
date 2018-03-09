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

        private decimal _TotalHours;

        public decimal TotalHours
        {
            get { return _TotalHours; }
            set
            {
                _TotalHours = value;
                RaisePropertyChanged("TotalHours");
            }
        }

        private List<LaborModel> _LaborList;

        public List<LaborModel> LaborList
        {
            get { return _LaborList; }
            set
            {
                _LaborList = value;
                TotalHours = 0;
                foreach (var labor in _LaborList)
                {
                    TotalHours += labor.Hours;
                }
                RaisePropertyChanged("TotalHours");
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

        public EditJobViewModel(Job selectedJob)
        {
            JobModel = selectedJob;
            LaborList = RFRepo.GetJobLabors(selectedJob.ID);
            MaterialsList = RFRepo.GetJobMaterials(selectedJob.ID);
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
