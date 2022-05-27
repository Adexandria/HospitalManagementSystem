using HospitalManagementSystem.Model;
using HospitalManagementSystem.Service.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagementSystem.Service
{
    class DrugAdministrationService
    {
        readonly static DbService db = new DbService();
        readonly static IHospital<DrugAdministration> drugDb = new DrugRepository(db);
        //Drug
        //Create Drug
        public static void CreateDrug(DrugAdministration drug)
        {
            int inserted = drugDb.Add(drug).Result;
            if (inserted == 0)
            {
                Console.WriteLine("Try Again");
            }
            else
            {
                Console.WriteLine("Created Successfully");
            }
        }
        //Get drug
        public static void GetDrug(Guid drugId)
        {
            DrugAdministration drug = drugDb.Get(drugId).Result;
            if (drug == null)
            {
                Console.WriteLine(" The administered Drug doesn't exist");
            }
            else
            {
                Console.WriteLine($"{drug.Drug} was administered to {drug.Patient.Name}");
            }
        }
        //update drug
        public static void UpdateDrug(DrugAdministration drug)
        {
            int updated = drugDb.Update(drug).Result;
            if (updated == 0)
            {
                Console.WriteLine("Try Again");
            }
            else
            {
                Console.WriteLine("Updated Successfully");
            }
        }
        //Delete Drug
        public static void DeleteDrug(Guid drugId)
        {
            int deleted = drugDb.Delete(drugId).Result;
            if (deleted == 0)
            {
                Console.WriteLine("Try Again");
            }
            else
            {
                Console.WriteLine("Deleted Successfully");
            }
        }
    }
}
