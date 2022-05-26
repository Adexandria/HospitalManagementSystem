using HospitalManagementSystem.Model;
using HospitalManagementSystem.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagementSystem
{
   public class NurseService
    {

        readonly static DbService db = new DbService();
        readonly static IHospital<Nurse> nurseDb = new NurseRepository(db);


        //Create Nurse
        public static void CreateNurse(Nurse nurse)
        {
            int inserted = nurseDb.Add(nurse).Result;
            if (inserted == 0)
            {
                Console.WriteLine("Try Again");
            }
            else
            {
                Console.WriteLine("Created Successfully");
            }
        }
        //Get Nurse
        public static void GetNurse(Guid nurseId)
        {
            Nurse nurse = nurseDb.Get(nurseId).Result;
            if (nurse == null)
            {
                Console.WriteLine("The nurse doesn't exist");
            }
            else
            {
                Console.WriteLine($"{nurse.NurseId} works at {nurse.Hospital.Name}");
            }

        }
        //Update Nurse
        public static void UpdateNurse(Nurse nurse)
        {
            int updated = nurseDb.Update(nurse).Result;
            if (updated == 0)
            {
                Console.WriteLine("Try Again");
            }
            else
            {
                Console.WriteLine("Updated Successfully");
            }
        }
        //Delete Nurse
        public static void DeleteNurse(Guid nurseId)
        {
            int deleted = nurseDb.Delete(nurseId).Result;
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
