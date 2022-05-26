using HospitalManagementSystem.Model;
using HospitalManagementSystem.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagementSystem
{
    public class HospitalService
    {

        readonly static DbService db = new DbService();
        readonly static IHospital<Hospital> hospitalDb = new HospitalRepository(db);
        readonly static IHospital<Receptionist> receptionistDb = new ReceptionistRepository(db);
        readonly static IHospital<Appointment> appointmentDb = new AppointmentRepository(db);
        readonly static IQuery query = new QueryRepository(db);


        //Create new hospital
        public static void CreateHospital(Hospital hospital)
        {
            int inserted = hospitalDb.Add(hospital).Result;
            if (inserted == 0)
            {
                Console.WriteLine("Try Again");
            }
            else
            {
                Console.WriteLine("Created Successfully");
            }
        }
        //Get Hospital
        public static void GetHospital(Guid id)
        {
            Hospital hospital = hospitalDb.Get(id).Result;
            if(hospital == null)
            {
                Console.WriteLine("This hospital doesn't exist");
            }
            else
            {
                Console.WriteLine($"Welcome to {hospital.Name}");
            }
            
        }
        //Update Hospital
        public static void UpdateHospital(Hospital hospital)
        {
            int updated = hospitalDb.Update(hospital).Result;
            if (updated == 0)
            {
                Console.WriteLine("Try Again");
            }
            else
            {
                Console.WriteLine("Updated Successfully");
            }
        }
        //Delete Hospital
        public static void DeleteHospital(Guid hospitalId)
        {
            int deleted = hospitalDb.Delete(hospitalId).Result;
            if (deleted == 0)
            {
                Console.WriteLine("Try Again");
            }
            else
            {
                Console.WriteLine("Deleted Successfully");
            }
        }

       
        //Extract patients seen by a particular doctor
        public static void GetPatientsByDoctorId(Guid doctorId)
        {
            IEnumerable<Patient> patients = query.AllPatientsByDoctorId(doctorId);
            foreach(var patient in patients)
            {
                Console.WriteLine(patient.Name);
            }
        }

        //Extract patient weekly
        public static void GetPatientWeekly()
        {
            IEnumerable<Patient> patients = query.AllPatientsWeekly;
            foreach (var patient in patients)
            {
                Console.WriteLine(patient.Name);
            }
        }
        //Extract patient monthly
        public static void GetPatientMonthly()
        {
            IEnumerable<Patient> patients = query.AllPatientsMonthly;
            foreach (var patient in patients)
            {
                Console.WriteLine(patient.Name);
            }
        }
        //Extract patient yearly
        public static void GetPatientYearly()
        {
            IEnumerable<Patient> patients = query.AllPatientsYearly;
            foreach (var patient in patients)
            {
                Console.WriteLine(patient.Name);
            }

        }
        //Get Registered Patients
        public static void GetRegisteredPatients()
        {
            IEnumerable<Patient> patients = query.AllRegisteredPatients;
            foreach (var patient in patients)
            {
                Console.WriteLine(patient.Name);
            }
        }

        //Get patients with outstanding balance
        public static void GetPatientsOutstandingBalance()
        {
            IEnumerable<Patient> patients = query.AllOverdueBillsByPatients;
            foreach (var patient in patients)
            {
                Console.WriteLine(patient.Name);
            }
        }
        //Get Top drugs
        public static void getTopDrugs()
        {
            IEnumerable<string> drugs = query.ExtractTopDrugs;
            foreach (var drug in drugs)
            {
                Console.WriteLine(drug);
            }
        }

        //Schedules appointment
        public static void CheckAppointment(Guid receptionistId, Guid patientId)
        {
            Appointment newAppointment = new Appointment
            {
                AppointmentTime = DateTime.Now,
                DoctorId = Guid.Parse(""),
                PatientId = patientId
            };
            Receptionist receptionist = receptionistDb.Get(receptionistId).Result;
            if (receptionist == null)
            {
                Console.WriteLine("Unauthorized user");
            }
            bool isRegistered = query.CheckRegisteredPatient(patientId).Result;
            if (isRegistered)
            {
                bool hasAppointment = query.CheckAppointment(patientId).Result;
                if (hasAppointment)
                {
                    Console.WriteLine("You can see the doctor");
                }

            }
            else
            {
                appointmentDb.Add(newAppointment);
                Console.WriteLine("Scheduled Appointment");
            }
        }
    }
}
