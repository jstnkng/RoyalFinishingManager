using RFDesktopManager.Data;
using RFDesktopManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RFDesktopManager.Repos
{
    public class RFRepo
    {

        public static void AddJob(Job newJob)
        { 
            var db = new RoyalFinishingDataContext();
            db.Jobs.InsertOnSubmit(newJob);
            db.SubmitChanges();
            MessageBox.Show("Job added");
        }

        public static void SaveJob(Job currentJob)
        {
            try
            {
                var db = new RoyalFinishingDataContext();
                var job = db.Jobs.FirstOrDefault(x => x.ID == currentJob.ID);
                job.BillByHour = currentJob.BillByHour;
                job.BillBySqFt = currentJob.BillBySqFt;
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("Job saved");
        }

        public static List<string> GetJobStatusList()
        {
            var db = new RoyalFinishingDataContext();
            var statusList = db.JobStatus.ToArray().ToList();
            var list = new List<string>();
            foreach (JobStatus statusType in statusList){
                list.Add(statusType.Status);
            }
            return list;
        }

        public static int GetStatusID(string status)
        {
            var db = new RoyalFinishingDataContext();
            var statusType = db.JobStatus.FirstOrDefault(x => x.Status == status);
            return statusType.ID;
        }

        public static string GetStatusType(int id)
        {
            var db = new RoyalFinishingDataContext();
            var statusType = db.JobStatus.FirstOrDefault(x => x.ID == id);
            return statusType.Status;
        }

        public static List<Job> GetJobs(int status)
        {

            var db = new RoyalFinishingDataContext();
            if (status == 0)
                return db.Jobs.ToList();
            else return db.Jobs.Where(x => x.StatusID == status).ToList();

        }

        public static string GetJobName(int jobID)
        {
            var db = new RoyalFinishingDataContext();
            return db.Jobs.FirstOrDefault(x => x.ID == jobID).Name;
        }

        public static int GetJobID(string jobName)
        {
            var db = new RoyalFinishingDataContext();
            return db.Jobs.FirstOrDefault(x => x.Name == jobName).ID;
        }

        public static Job GetJob(string jobName)
        {
            var db = new RoyalFinishingDataContext();
            return db.Jobs.FirstOrDefault(x => x.Name == jobName);
        }

        public static Job GetJob(int jobiD)
        {
            var db = new RoyalFinishingDataContext();
            return db.Jobs.FirstOrDefault(x => x.ID == jobiD);
        }

        public static List<Job> SearchForJobs(string text, int statusID)
        {
            var db = new RoyalFinishingDataContext();
            var searchList = new List<Job>();
            var descriptionList = db.Jobs.Where(x => x.Description.Contains(text) && x.StatusID == statusID);
            var nameList = db.Jobs.Where(x => x.Name.Contains(text) && x.StatusID == statusID);
            foreach (var job in descriptionList)
            {
                searchList.Add(job);
            }
            foreach (var job in nameList)
            {
                if (!(searchList.Contains(job)))
                searchList.Add(job);
            }
            return searchList;
        }


        public static List<Job> SortJobsByName(int statusID)
        {
            var db = new RoyalFinishingDataContext();
            if (statusID == 0)
                return db.Jobs.OrderBy(x => x.Name).ToList();
            else return db.Jobs.Where(x => x.StatusID == statusID).OrderBy(x => x.Name).ToList();           
        }

        public static List<Job> SortJobsByCity(int statusID)
        {
            var db = new RoyalFinishingDataContext();
            if (statusID == 0)
                return db.Jobs.OrderBy(x => x.City).ToList();
            else return db.Jobs.Where(x => x.StatusID == statusID).OrderBy(x => x.City).ToList();
        }

        public static List<Employee> GetEmployees()
        {
            var db = new RoyalFinishingDataContext();
            return db.Employees.ToList();
        }

        public static string GetEmployee(int empID)
        {
            var db = new RoyalFinishingDataContext();
            return db.Employees.FirstOrDefault(x => x.ID == empID).FullName;
        }

        public static int GetEmployeeID(string name)
        {
            var db = new RoyalFinishingDataContext();
            return db.Employees.FirstOrDefault(x => x.FullName == name).ID;
        }

        public static decimal GetEmployeeRate(string name)
        {
            var db = new RoyalFinishingDataContext();
            return db.Employees.FirstOrDefault(x => x.FullName == name).Wages;
        }

        public static List<LaborModel> GetEmployeeLabor(int employeeID, DateTime startDate, DateTime endDate)
        {
            var db = new RoyalFinishingDataContext();
            var list = db.Labors.Where(x => x.EmployeeID == employeeID && startDate <= x.Date && x.Date <= endDate).ToList();
            var laborList = new List<LaborModel>();
            foreach (var labor in list)
            {
                LaborModel newLabor = new LaborModel();
                newLabor.Date = labor.Date.Value;
                newLabor.Hours = labor.Hours;
                newLabor.JobName = GetJobName(labor.JobID);
                laborList.Add(newLabor);
            }

            return laborList;
        }

        public static List<LaborModel> GetJobLabors(int jobID)
        {
            var db = new RoyalFinishingDataContext();
            var list = db.Labors.Where(x => x.JobID == jobID).ToList();
            var jobList = new List<LaborModel>();
            foreach (var labor in list)
            {
                LaborModel newLabor = new LaborModel();
                newLabor.EmployeeName = GetEmployee(labor.EmployeeID);
                newLabor.Date = labor.Date.Value;
                newLabor.Hours = labor.Hours;
                jobList.Add(newLabor);
            }
            return jobList;
        }

        public static void AddLabor(Labor model)
        {
            var db = new RoyalFinishingDataContext();
            db.Labors.InsertOnSubmit(model);
            db.SubmitChanges();
        }

        public static List<Material> GetMaterials()
        {
            var db = new RoyalFinishingDataContext();
            return db.Materials.ToList();
        }

        public static int GetMaterialID(string materialName)
        {
            var db = new RoyalFinishingDataContext();
            return db.Materials.FirstOrDefault(x => x.Item == materialName).ID;
        }

        public static Material GetMaterial(string materialName)
        {
            var db = new RoyalFinishingDataContext();
            return db.Materials.FirstOrDefault(x => x.Item == materialName);
        }

        public static string GetMaterialName (int id)
        {
            var db = new RoyalFinishingDataContext();
            return db.Materials.FirstOrDefault(x => x.ID == id).Item;
        }

        public static bool InMaterials(string name)
        {
            var db = new RoyalFinishingDataContext();
            var list = db.Materials.ToList();
            foreach (var material in list)
            {
                if (material.Item == name)
                    return true;
            }
            return false;
        }

        public static void AddMaterial(string materialName, decimal price)
        {
            try
            {
                var db = new RoyalFinishingDataContext();
                Material newMaterial = new Material();
                newMaterial.Item = materialName;
                newMaterial.Price = price;
                db.Materials.InsertOnSubmit(newMaterial);
                db.SubmitChanges();
            }
            catch
            {
                MessageBox.Show("Unable to save material to materials table.");
            }
        }

        public static void AddMaterialHistory(MaterialHistory model)
        {
            try
            {
                var db = new RoyalFinishingDataContext();
                db.MaterialHistories.InsertOnSubmit(model);
                db.SubmitChanges();
                MessageBox.Show("Saved");
            }
            catch
            {
                MessageBox.Show("Unable to save. Try again shortly", "An error occured");
            }
        }

        public static List<MaterialModel> GetJobMaterials(int jobID)
        {
            var db = new RoyalFinishingDataContext();
            var list = db.MaterialHistories.Where(x => x.JobID == jobID).ToList();
            var materialList = new List<MaterialModel>();
            foreach (var material in list)
            {
                var materialModel = new MaterialModel();
                materialModel.Cost = material.CostPerItem;
                materialModel.Description = material.Description;
                materialModel.Quantity = material.Quantity;
                materialModel.MaterialName = GetMaterialName(material.ItemID);
                materialList.Add(materialModel);
            }
            return materialList;
        }
    }
}
