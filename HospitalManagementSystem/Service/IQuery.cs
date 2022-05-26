using HospitalManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Service
{
    public interface IQuery
    {
        IEnumerable<Patient> AllPatientsByDoctorId(Guid doctorId);
        IEnumerable<Patient> AllPatientsWeekly { get; }
        IEnumerable<Patient> AllPatientsMonthly { get; }
        IEnumerable<Patient> AllPatientsQuartely { get; }
        IEnumerable<Patient> AllPatientsYearly { get; }
        IEnumerable<Patient> AllRegisteredPatients { get; }
        IEnumerable<Patient> AllOverdueBillsByPatients { get; }
        IEnumerable<string> ExtractTopDrugs { get; }
        Task<bool> CheckAppointment(Guid patientId);
        Task<bool> CheckRegisteredPatient(Guid patientId);
        

    }
}
