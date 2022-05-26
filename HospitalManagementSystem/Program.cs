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
            */
            Patient patient = new Patient()
            {
                HospitalId = Guid.Parse("e323aa25-9061-4ecf-b5af-3ef5288daefa"),
                Name="Adeola"
            };

            PatientService.CreatePatient(patient);
            PatientService.GetAllPatients(Guid.Parse("e323aa25-9061-4ecf-b5af-3ef5288daefa"));
        }

        
    }
}
