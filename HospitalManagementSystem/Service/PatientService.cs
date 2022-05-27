using HospitalManagementSystem.Model;
using HospitalManagementSystem.Service.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagementSystem.Service
{
    class PatientService
    {
        readonly static DbService db = new DbService();
        readonly static IHospital<Patient> patientDb = new PatientRepository(db);



        //Create patient
        public static void CreatePatient(Patient patient)
        {
            int inserted = patientDb.Add(patient).Result;
            if (inserted == 0)
            {
                Console.WriteLine("Try Again");
            }
            else
            {
                Console.WriteLine("Created Successfully");
            }
        }

        //Get Patient
        public static void GetPatient(Guid patientId)
        {
            Patient patient = patientDb.Get(patientId).Result;
            if (patient == null)
            {
                Console.WriteLine("Patient doesn't exist");
            }
            else
            {
                Console.WriteLine($"Patient {patient.Name} at {patient.Hospital.Name}");
            }
        }
        //Get all patients
        public static void GetAllPatients(Guid hospitalId)
        {
            IEnumerable<Patient> patients = patientDb.GetAll(hospitalId);
            foreach (var patient in patients)
            {
                Console.WriteLine($"Patient {patient.Name} at {patient.Hospital.Name}");
            }
        }
        // Update Patient
        public static void UpdatePatient(Patient patient)
        {
            int updated = patientDb.Update(patient).Result;
            if (updated == 0)
            {
                Console.WriteLine("Try Again");
            }
            else
            {
                Console.WriteLine("Updated Successfully");
            }
        }
        //Delete Patient 
        public static void DeletePatient(Guid patientId)
        {
            int deleted = patientDb.Delete(patientId).Result;
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
