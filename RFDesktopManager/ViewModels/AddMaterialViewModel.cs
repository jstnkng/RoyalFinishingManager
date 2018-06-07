using RFDesktopManager.Data;
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
    public class AddMaterialViewModel : DependencyObject, INotifyPropertyChanged
    {

        private MaterialHistory _Model;

        public MaterialHistory Model
        {
            get { return _Model;}
            set
            {
                _Model = value;
                RaisePropertyChanged("Model");
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

        private Employee _SelectedEmployee;

        public Employee SelectedEmployee
        {
            get { return _SelectedEmployee; }
            set
            {
                _SelectedEmployee = value;
                RaisePropertyChanged("SelectedEmployee");
            }
        }

        private List<Material> _MaterialList;

        public List<Material> MaterialList
        {
            get { return _MaterialList; }
            set
            {
                _MaterialList = value;
                RaisePropertyChanged("MaterialList");
            }
        }

        private string _NewMaterial;

        public string NewMaterial
        {
            get { return _NewMaterial; }
            set
            {
                _NewMaterial = value;
                RaisePropertyChanged("NewMaterial");
                if (RFRepo.InMaterials(NewMaterial))
                {
                    SelectedMaterial = RFRepo.GetMaterial(NewMaterial);
                    Model.CostPerItem = SelectedMaterial.Price;
                    RaisePropertyChanged("MyModel");
                }
                else Model.CostPerItem = 0;

            }
        }

        private decimal _TotalPrice;

        public decimal TotalPrice
        {
            get { return _TotalPrice; }
            set
            {
                _TotalPrice = value;
                RaisePropertyChanged("TotalPrice");
            }
        }

        private Material _SelectedMaterial;

        public Material SelectedMaterial
        {
            get { return _SelectedMaterial; }
            set
            {
                _SelectedMaterial = value;
                RaisePropertyChanged("SelectedMaterial");
            }
        }

        private List<Job> _JobList;

        public List<Job> JobList
        {
            get { return _JobList; }
            set
            {
                _JobList = value;
                RaisePropertyChanged("JobList");
            }
        }

        private Job _SelectedJob;

        public Job SelectedJob
        {
            get { return _SelectedJob; }
            set
            {
                _SelectedJob = value;
                RaisePropertyChanged("SelectedJob");
            }
        }

        private string _JobName;

        public string JobName
        {
            get { return _JobName; }
            set
            {
                _JobName = value;
                SelectedJob = RFRepo.GetJob(value);
                RaisePropertyChanged("JobName");
            }
        }

        public AddMaterialViewModel()
        {
            EmployeeList = RFRepo.GetEmployees();
            MaterialList = RFRepo.GetMaterials();
            JobList = RFRepo.GetJobs(0);
            Model = new MaterialHistory();
        }

        public void Save()
        {
            if (!(RFRepo.InMaterials(NewMaterial)))
            {
                RFRepo.AddMaterial(NewMaterial, Model.CostPerItem);
                SelectedMaterial = RFRepo.GetMaterial(NewMaterial);
            }

            Model.EmployeeID = SelectedEmployee.ID;
            Model.ItemID = SelectedMaterial.ID;
            Model.JobID = SelectedJob.ID;
            RFRepo.AddMaterialHistory(Model);
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
