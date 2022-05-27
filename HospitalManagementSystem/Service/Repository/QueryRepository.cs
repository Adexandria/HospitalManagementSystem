using HospitalManagementSystem.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Service.Repository
{
    public class QueryRepository : IQuery
    {
       readonly DbService db;
        public QueryRepository(DbService db)
        {
            this.db = db;
        }
        // Get Patients Weekly
        public IEnumerable<Patient> AllPatientsWeekly 
        {
            get
            {
               return db.Appointments.OrderBy(s=>s.AppointmentTime.DayOfWeek).Select(s=>s.Patient);
            }
        }

        //Get Monthly Patients

        public IEnumerable<Patient> AllPatientsMonthly 
        {
            get
            {
                return db.Appointments.OrderBy(s => s.AppointmentTime.Month).Select(s => s.Patient);
            }
        }


        public IEnumerable<Patient> AllPatientsQuartely
        {
            get
            {
                return db.Appointments.Where(s => Quarterly(s.AppointmentTime.Month) == 2).Select(s => s.Patient);
            }
        }

        //Get Yearly Patients
        public IEnumerable<Patient> AllPatientsYearly
        {
            get
            {
                return db.Appointments.OrderBy(s => s.AppointmentTime.Year).Select(s => s.Patient);
            }
        }

        // Get All Registered
        public IEnumerable<Patient> AllRegisteredPatients
        {
            get
            {
                return db.Patients.Where(s => s.Status == PatientStatus.Registered).OrderBy(s => s.PatientId);
            }
        }

        //Get Patients who have outstandingBills
        public IEnumerable<Patient> AllOverdueBillsByPatients
        {
            get
            {
                return db.Billings.Where(s => s.OutstandingBill > 0).Select(s => s.Patient).OrderBy(s => s.PatientId);
            }
        }

        //Get the top 10 drugs
        public IEnumerable<string> ExtractTopDrugs
        {
            get
            {
                return db.Drugs.OrderByDescending(s => s.Quantity).Select(s => s.Drug).Take(10);
            }
        }

        //Get doctor patients
        public IEnumerable<Patient> AllPatientsByDoctorId(Guid doctorId)
        {
            return db.Appointments.Where(s => s.DoctorId == doctorId).Select(s => s.Patient).OrderBy(s => s.PatientId);
        }

        //Check if appointment is valid
        public async Task<bool> CheckAppointment(Guid patientId)
        {
            
            Appointment appointment = await db.Appointments
                .Where(s => s.PatientId == patientId)
                .Where(s => s.AppointmentTime.Date >= DateTime.Now.Date)
                .FirstOrDefaultAsync();
            if(appointment == null)
            {
                return false;
            }
            return true;
        }

        //Check if patient is registered
        public async Task<bool> CheckRegisteredPatient(Guid patientId)
        {
            Patient patient = await db.Patients.Where(s => s.PatientId == patientId).Where(s => s.Status == PatientStatus.Registered).FirstOrDefaultAsync();
            if(patient == null)
            {
                return false;
            }
            return true;
        }

        private int Quarterly(int month)
        {
            return ((month - 1) / 3) + 1;
        }
    }
}
