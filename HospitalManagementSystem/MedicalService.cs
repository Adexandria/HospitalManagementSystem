using HospitalManagementSystem.Model;
using HospitalManagementSystem.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagementSystem
{
    public class MedicalService
    {
        readonly static DbService db = new DbService();
        readonly static IHospital<MedicalCondition> medicalDb = new MedicalRepository(db);


        //Medical 
        //Create medical condition
        public static void CreateMedicalCondtion(MedicalCondition medical)
        {
            int inserted = medicalDb.Add(medical).Result;
            if (inserted == 0)
            {
                Console.WriteLine("Try Again");
            }
            else
            {
                Console.WriteLine("Created Successfully");
            }
        }

        //Get medical condition
        public static void GetMedicalCondition(Guid medicalId)
        {
            MedicalCondition medical = medicalDb.Get(medicalId).Result;
            if (medical == null)
            {
                Console.WriteLine("The medical consiton doesn't exist");
            }
            else
            {
                Console.WriteLine($" The patient {medical.Patient.Name} has {medical.Description}");
            }
        }

        //Update Medical condition
        public static void UpdateMedicalCondtion(MedicalCondition medical)
        {
            int updated = medicalDb.Update(medical).Result;
            if (updated == 0)
            {
                Console.WriteLine("Try Again");
            }
            else
            {
                Console.WriteLine("Updated Successfully");
            }
        }
        //Delete Medical condition
        public static void DeleteMedicalCondtion(Guid medicalId)
        {
            int deleted = medicalDb.Delete(medicalId).Result;
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
