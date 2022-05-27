using HospitalManagementSystem.Model;
using HospitalManagementSystem.Service.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagementSystem.Service
{
   public class DoctorService
    {
        readonly static DbService db = new DbService();
        readonly static IHospital<Doctor> doctorDb = new DoctorRepository(db);



        //Doctor
        //Create doctor
        public static void CreateDoctor(Doctor doctor)
        {
            int inserted = doctorDb.Add(doctor).Result;
            if (inserted == 0)
            {
                Console.WriteLine("Try Again");
            }
            else
            {
                Console.WriteLine("Created Successfully");
            }
        }

        //Get Doctor
        public static void GetDoctor(Guid doctorId)
        {
            Doctor doctor = doctorDb.Get(doctorId).Result;
            if (doctor == null)
            {
                Console.WriteLine("Doctor doesn't exist");
            }
            else
            {
                Console.WriteLine($"Doctor {doctor.Name} works at {doctor.Hospital.Name}");
            }
        }
        //Get all doctors
        public static void GetAllDoctors(Guid hospitalId)
        {
            IEnumerable<Doctor> doctors = doctorDb.GetAll(hospitalId);
            foreach (var doctor in doctors)
            {
                Console.WriteLine(doctor.Name);
            }
        }
        //update Doctor
        public static void UpdateDoctor(Doctor doctor)
        {
            int updated = doctorDb.Update(doctor).Result;
            if (updated == 0)
            {
                Console.WriteLine("Try Again");
            }
            else
            {
                Console.WriteLine("Updated Successfully");
            }
        }
        //delete doctor
        public static void DeleteDoctor(Guid doctorId)
        {
            int deleted = doctorDb.Delete(doctorId).Result;
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
