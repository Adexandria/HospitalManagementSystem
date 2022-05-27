using HospitalManagementSystem.Model;
using HospitalManagementSystem.Service.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagementSystem.Service
{
    class ReceptionistService
    {
        readonly static DbService db = new DbService();
        readonly static IHospital<Receptionist> receptionistDb = new ReceptionistRepository(db);



        //create receptionist
        public static void CreateReceptionist(Receptionist receptionist)
        {
            int inserted = receptionistDb.Add(receptionist).Result;
            if (inserted == 0)
            {
                Console.WriteLine("Try Again");
            }
            else
            {
                Console.WriteLine("Created Successfully");
            }
        }
        //get receptionist
        public static void GetReceptionist(Guid receptionistId)
        {
            Receptionist receptionist = receptionistDb.Get(receptionistId).Result;
            if (receptionist == null)
            {
                Console.WriteLine("The Receptionist does't exist");
            }
            else
            {
                Console.WriteLine($"{receptionist.ReceptionistId} at {receptionist.Hospital.Name}");
            }
        }
        //Update receptionist
        public static void UpdateReceptionist(Receptionist receptionist)
        {
            int updated = receptionistDb.Update(receptionist).Result;
            if (updated == 0)
            {
                Console.WriteLine("Try Again");
            }
            else
            {
                Console.WriteLine("Updated Successfully");
            }
        }

        //Delete Receptionist
        public static void DeleteReceptionist(Guid receptionistId)
        {
            int deleted = receptionistDb.Delete(receptionistId).Result;
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
