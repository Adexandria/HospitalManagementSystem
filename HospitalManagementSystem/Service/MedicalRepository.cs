using HospitalManagementSystem.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Service
{
    public class MedicalRepository :IHospital<MedicalCondition>
    {
        readonly DbService db;
        public MedicalRepository(DbService db)
        {
            this.db = db;
        }

        //Get medical condition by Medication condition Id
        public async Task<MedicalCondition> Get(Guid id)
        {
            return await db.MedicalConditions.Where(s => s.MedicalConditionId == id)
                .Include(s => s.Patient).FirstOrDefaultAsync();
        }
        //Get all patient medical condition
        public IEnumerable<MedicalCondition> GetAll(Guid patientId)
        {
            return db.MedicalConditions.Where(s => s.PatientId == patientId)
                .Include(s => s.Patient).OrderBy(s=>s.MedicalConditionId);
        }
        //Add new patient medication condition
        public async Task<int> Add(MedicalCondition entity)
        {
            try
            {
                if (entity == null)
                {
                    return 0;
                }
                entity.MedicalConditionId = Guid.NewGuid();
                await db.MedicalConditions.AddAsync(entity);
                return await SaveChanges();
            }
            catch (Exception)
            {

                return 0;
            }
        }
        //Delete existing medical condition
        public async Task<int> Delete(Guid id)
        {
            try
            {
                MedicalCondition currentCondition = await Get(id);
                db.MedicalConditions.Remove(currentCondition);
                return await SaveChanges();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        //Update existing medical condition
        public async Task<int> Update(MedicalCondition entity)
        {
            try
            {
                MedicalCondition currentCondition = await Get(entity.MedicalConditionId);
                //gets the value of the attribute(s)updated and set it in the current value
                db.Entry(currentCondition).CurrentValues.SetValues(entity);
                //Change the entity state to modified.
                db.Entry(currentCondition).State = EntityState.Modified;
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
