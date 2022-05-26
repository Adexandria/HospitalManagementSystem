using HospitalManagementSystem.Model;
using HospitalManagementSystem.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagementSystem
{
    public class PharmacistService
    {
        readonly static DbService db = new DbService();
        readonly static IHospital<Pharmacist> pharmacistDb = new PharmacistRepository(db);


        //Create Pharmacist
        public static void CreatePharmacist(Pharmacist pharmacist)
        {
            int inserted = pharmacistDb.Add(pharmacist).Result;
            if (inserted == 0)
            {
                Console.WriteLine("Try Again");
            }
            else
            {
                Console.WriteLine("Created Successfully");
            }
        }
        //Get Pharmacist
        public static void GetPharmacist(Guid pharmacistId)
        {
            Pharmacist pharmacist = pharmacistDb.Get(pharmacistId).Result;
            if (pharmacist == null)
            {
                Console.WriteLine("The Pharmacist doesn't exist");
            }
            else
            {
                Console.WriteLine($"{pharmacist.PharmacistId} at {pharmacist.Hospital.Name}");
            }
        }
        //Update Pharmacist
        public static void UpdatePharmacist(Pharmacist pharmacist)
        {
            int updated = pharmacistDb.Update(pharmacist).Result;
            if (updated == 0)
            {
                Console.WriteLine("Try Again");
            }
            else
            {
                Console.WriteLine("Updated Successfully");
            }
        }
        //Delete Pharmacist
        public static void DeletePharamacist(Guid pharmacistId)
        {
            int deleted = pharmacistDb.Delete(pharmacistId).Result;
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
