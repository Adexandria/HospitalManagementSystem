using HospitalManagementSystem.Model;
using HospitalManagementSystem.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagementSystem
{
    class AppointmentService
    {
        readonly static DbService db = new DbService();
        readonly static IHospital<Appointment> appointmentDb = new AppointmentRepository(db);

        //Create Appointment
        public static void CreateAppointment(Appointment appointment)
        {
            int inserted = appointmentDb.Add(appointment).Result;
            if (inserted == 0)
            {
                Console.WriteLine("Try Again");
            }
            else
            {
                Console.WriteLine("Created Successfully");
            }

        }
        //Get Appointment
        public static void GetAppointment(Guid appointmentId)
        {
            Appointment appointment = appointmentDb.Get(appointmentId).Result;
            if (appointment == null)
            {
                Console.WriteLine("Appointment doesn't exist");
            }
            else
            {
                Console.WriteLine($"{appointment.Patient.Name} is schedule at {appointment.AppointmentTime}");
            }
        }
        //Get all patient Appointments
        public static void GetPatientAppointments(Guid patientId)
        {
            IEnumerable<Appointment> appointments = appointmentDb.GetAll(patientId);
            foreach (var appointment in appointments)
            {
                Console.WriteLine($"Scheduled Appointment time at {appointment.AppointmentTime.ToString()}");
            }
        }
        //Update appointment
        public static void UpdateAppointment(Appointment appointment)
        {
            int updated = appointmentDb.Update(appointment).Result;
            if (updated == 0)
            {
                Console.WriteLine("Try Again");
            }
            else
            {
                Console.WriteLine("Updated Successfully");
            }
        }
        //Delete appointment
        public static void DeleteAppointment(Guid appointmentId)
        {
            int deleted = appointmentDb.Delete(appointmentId).Result;
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
