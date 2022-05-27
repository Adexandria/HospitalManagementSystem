using HospitalManagementSystem.Model;
using HospitalManagementSystem.Service;
using System;
using System.Collections.Generic;

namespace HospitalManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {

            /* 
             * HospitalService.CreateHospital(new Hospital()); // creates hospital
               HospitalService.GetHospital(Guid.Parse("e323aa25-9061-4ecf-b5af-3ef5288daefa"));// get existing hospital
               Hospital updatedHospital = new Hospital
                {
                    HospitalId = Guid.Parse("e323aa25-9061-4ecf-b5af-3ef5288daefa"),
                    Name= "Adeola"
                };
                HospitalService.UpdateHospital(updatedHospital);//updates existing hospital
                HospitalService.DeleteHospital(Guid.Parse("b414bb72-002d-4b21-ad40-bd66f10a8ac1"));// Deletes existing hospital
            *
            
            Patient patient = new Patient()
            {
                HospitalId = Guid.Parse("e323aa25-9061-4ecf-b5af-3ef5288daefa"),
                Name = "Kemi",
                Status = PatientStatus.Registered

            };

            PatientService.CreatePatient(patient);
            PatientService.GetAllPatients(Guid.Parse("e323aa25-9061-4ecf-b5af-3ef5288daefa"));
            Receptionist receptionist = new Receptionist
            {
                HospitalId = Guid.Parse("e323aa25-9061-4ecf-b5af-3ef5288daefa")
            };
            ReceptionistService.CreateReceptionist(receptionist);

            Doctor doctor = new Doctor { 
                Name="French",
                HospitalId = Guid.Parse("e323aa25-9061-4ecf-b5af-3ef5288daefa")
            };
            DoctorService.CreateDoctor(doctor);

            Appointment newAppointment = new Appointment
            {
                AppointmentTime = DateTime.Now,
                DoctorId = Guid.Parse("0ad16cb3-0612-41ed-b586-5171da6f5956"),
                PatientId = patientId
            };
            AppointmentService.CreateAppointment(newAppointment);
            
             Guid receptionistId = Guid.Parse("34e66f0d-4ff7-4c6c-8b22-2b9b07450e42");
            Guid patientId = Guid.Parse("abcd3a34-4518-4ab2-baae-1910fdc5983c");
            HospitalService.CheckAppointment(receptionistId, patientId);

            HospitalService.GetRegisteredPatients(); // returns all registerd patient
            */

        }


    }
}
