using HospitalManagementSystem.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Service.Repository
{
    public class PatientRepository : IHospital<Patient>
    {
        readonly DbService db;
        public PatientRepository(DbService db)
        {
            this.db = db;
        }
        //Get all patients in the hospital
        public IEnumerable<Patient> GetAll(Guid hospitalId)
        {
            return db.Patients.Where(s => s.HospitalId == hospitalId).OrderBy(s => s.PatientId).Include(s => s.Hospital);
        }
        //Get existing patient by patient id
        public async Task<Patient> Get(Guid id)
        {
            return await db.Patients.Where(s => s.PatientId == id).Include(s=>s.Hospital).FirstOrDefaultAsync();
        }
        //Add new patient
        public async Task<int> Add(Patient entity)
        {
            try
            {
                if (entity == null)
                {
                    return 0;
                }
                entity.PatientId = Guid.NewGuid();
                await db.Patients.AddAsync(entity);
                return await SaveChanges();
            }
            catch (Exception)
            {

                return 0;
            }
        }
        //Update patient
        public async Task<int> Update(Patient entity)
        {
            try
            {
                Patient currentPatient = await Get(entity.PatientId);
                //gets the value of the attribute(s)updated and set it in the current value
                db.Entry(currentPatient).CurrentValues.SetValues(entity);
                //Change the entity state to modified.
                db.Entry(currentPatient).State = EntityState.Modified;
                return await SaveChanges();
            }
            catch (Exception)
            {

                return 0;
            }
        }
        //Delete Patient
        public async Task<int> Delete(Guid id)
        {
            try
            {
                Patient currentPatient = await Get(id);
                db.Patients.Remove(currentPatient);
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
