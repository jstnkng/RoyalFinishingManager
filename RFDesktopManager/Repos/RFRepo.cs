﻿using RFDesktopManager.Data;
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
        }

        public static void SaveJob(Job currentJob)
        {
            var db = new RoyalFinishingDataContext();
            var job = db.Jobs.FirstOrDefault(x => x.ID == currentJob.ID);
            job.Address = currentJob.Address;
            job.Description = currentJob.Description;
            job.Name = currentJob.Name;
            job.StatusID = currentJob.StatusID;
            db.SubmitChanges();
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
    }
}
