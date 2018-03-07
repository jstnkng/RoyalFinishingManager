using RFDesktopManager.Data;
using RFDesktopManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static List<Job> GetJobs()
        {
            var db = new RoyalFinishingDataContext();
            return db.Jobs.ToList();

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
    }
}
