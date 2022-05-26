using HospitalManagementSystem.Model;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Service
{
    public class DbService : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<Receptionist> Receptionists { get; set; }
        public DbSet<Accountant> Accountants { get; set; }
        public DbSet<Pharmacist> Pharmacists { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<BillingManagement> Billings { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<DrugAdministration> Drugs { get; set; }
        public DbSet<MedicalCondition> MedicalConditions { get; set; }
        public DbSet<Hospital> Hospital { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Database=HPMS;Integrated Security=True;Connect Timeout=30;");
        }
    }
}
