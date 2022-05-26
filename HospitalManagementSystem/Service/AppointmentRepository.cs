using HospitalManagementSystem.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Service
{
    public class AppointmentRepository : IHospital<Appointment>
    {

        readonly DbService db;
        public AppointmentRepository(DbService db)
        {
            this.db = db;
        }

        //Get the exsiting appointment by appointment id
        public async Task<Appointment> Get(Guid id)
        {
            return await db.Appointments.Where(s => s.AppointmentId == id)
                .Include(s => s.Doctor).Include(s => s.Patient).FirstOrDefaultAsync();
        }

        //Get all patient appointments
        public IEnumerable<Appointment> GetAll(Guid patientId)
        {
            return db.Appointments.Where(s => s.PatientId == patientId)
                .Include(s => s.Doctor).Include(s => s.Patient).OrderBy(s=>s.AppointmentId);
        }

        //Deletes existing appointments
        public async Task<int> Delete(Guid id)
        {
            try
            {
                Appointment currentAppointment = await Get(id);
                db.Appointments.Remove(currentAppointment);
                return await SaveChanges();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        //Add new appointment
        public async Task<int> Add(Appointment entity)
        {
            try
            {
                if (entity == null)
                {
                    return 0;
                }
                entity.AppointmentId = Guid.NewGuid();
                await db.Appointments.AddAsync(entity);
                return await SaveChanges();
            }
            catch (Exception)
            {

                return 0;
            }
        }

        //Update existing appointment
        public async Task<int> Update(Appointment entity)
        {
            try
            {
                Appointment currentAppointment = await Get(entity.AppointmentId);
                //gets the value of the attribute(s) updated and set it in the current value
                db.Entry(currentAppointment).CurrentValues.SetValues(entity);
                //Change the entity state to modified.
                db.Entry(currentAppointment).State = EntityState.Modified;
                return await SaveChanges();
            }
            catch (Exception)
            {

                return 0;
            }
        }

        private async Task<int> SaveChanges()
        {
            return await db.SaveChangesAsync();
        }
    }
}
