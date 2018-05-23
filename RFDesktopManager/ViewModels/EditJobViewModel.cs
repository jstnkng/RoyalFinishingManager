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

        private decimal _Hours;

        public decimal Hours
        {
            get { return _Hours; }
            set
            {
                _Hours = value;
                RaisePropertyChanged("Hours");
            }
        }

        private string _CityLine;

        public string CityLine
        {
            get { return _CityLine; }
            set
            {
                _CityLine = value;
                RaisePropertyChanged("CityLine");
            }
        }

        private string _InvoiceItems;

        public string InvoiceItems
        {
            get { return _InvoiceItems; }
            set
            {
                _InvoiceItems = value;
                RaisePropertyChanged("InvoiceItems");
            }
        }

        private string _InvoiceCosts;

        public string InvoiceCosts
        {
            get { return _InvoiceCosts; }
            set
            {
                _InvoiceCosts = value;
                RaisePropertyChanged("InvoiceCosts");
            }
        }

        public EditJobViewModel()
        {
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

        private decimal? _HourlyCost;

        public decimal? HourlyCost
        {
            get { return _HourlyCost; }
            set
            {
                _HourlyCost = Math.Round(value.Value,2);
                RaisePropertyChanged("HourlyCost");
            }
        }

        private decimal? _SqFtCost;

        public decimal? SqFtCost
        {
            get { return _SqFtCost; }
            set
            {
                if (value.HasValue)
                _SqFtCost = Math.Round(value.Value, 2);
                RaisePropertyChanged("SqftCost");
            }
        }

        private decimal _TotalCost;

        public decimal TotalCost
        {
            get { return _TotalCost; }
            set
            {
                _TotalCost = Math.Round(value, 2);
                RaisePropertyChanged("TotalCost");
            }
        }

        public void Refresh(int jobID)
        {
            JobModel = RFRepo.GetJob(jobID);
            InvoiceCosts = "";
            InvoiceItems = "";
            Hours = 0;
            LaborList = RFRepo.GetJobLabors(jobModel.ID);
            HourlyCost = 0;
            foreach (var labor in LaborList)
            {
                Hours += labor.Hours;
                var employeeRate = RFRepo.GetEmployeeRate(labor.EmployeeName);
                HourlyCost += labor.Hours * employeeRate;
            }
            RaisePropertyChanged("HourlyCost");
            if (LaborList.Count > 0)
            {
                if (JobModel.BillByHour)
                {
                    InvoiceItems += "Labor: " + Hours + " hours\n\n";
                    InvoiceCosts += "$" + HourlyCost.ToString() + "\n\n";
                }
                else if (JobModel.BillBySqFt)
                {
                    InvoiceItems += JobModel.SqFt + " total square ft at $" + JobModel.SqFtRate + "/ sq ft\n\n";
                    InvoiceCosts += "$" + SqFtCost.ToString()  + "\n\n";
                }
                
            }
            SqFtCost = jobModel.SqFt * jobModel.SqFtRate;
            RaisePropertyChanged("SqFtCost");
            MaterialsList = RFRepo.GetJobMaterials(jobModel.ID);
            decimal invoiceMaterialsCost = 0;
            foreach (var material in MaterialsList)
            {
                InvoiceItems += material.MaterialName + "\t Qty: " + material.Quantity + "\n";
                var totalMaterialCost = material.Cost * material.Quantity;
                InvoiceCosts += "$" + totalMaterialCost + "\n";
                invoiceMaterialsCost += totalMaterialCost;
                if (!(string.IsNullOrEmpty(material.Description)))
                {
                    InvoiceItems += "\t Description: " + material.Description + "\n";
                    InvoiceCosts += "\n";
                }
            }
            TotalCost = HourlyCost.Value + invoiceMaterialsCost;
            var cityString = new StringBuilder(jobModel.City);
            cityString.Append(",");
            cityString.Append(jobModel.State);
            cityString.Append(" " + jobModel.ZipCode);
            CityLine = cityString.ToString();
            if (SelectedStatus != null)
            {
                SelectedStatus = RFRepo.GetStatusType(jobModel.StatusID);
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
