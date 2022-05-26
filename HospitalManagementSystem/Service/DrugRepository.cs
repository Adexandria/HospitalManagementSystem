using HospitalManagementSystem.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Service
{
    public class DrugRepository : IHospital<DrugAdministration>
    {
        readonly DbService db;
        public DrugRepository(DbService db)
        {
            this.db = db;
        }
        //Get drug by drug id
        public async Task<DrugAdministration> Get(Guid id)
        {
            return await db.Drugs.Where(s => s.DrugId == id)
                .Include(s => s.Patient)
                .Include(s => s.Appointment).Include(s => s.Pharmacist)
                .FirstOrDefaultAsync();
        }

        //Get all  patient drugs 
        public IEnumerable<DrugAdministration> GetAll(Guid patientId)
        {
            return  db.Drugs.Where(s => s.PatientId == patientId)
                .Include(s => s.Patient)
                .Include(s => s.Appointment).Include(s => s.Pharmacist)
                .OrderBy(s=>s.Drug);


        }

        //Add new  administered drug
        public async  Task<int> Add(DrugAdministration entity)
        {
            try
            {
                if (entity == null)
                {
                    return 0;
                }
                entity.DrugId = Guid.NewGuid();
                await db.Drugs.AddAsync(entity);
                return await SaveChanges();
            }
            catch (Exception)
            {

                return 0;
            }
        }

        //Delete existing drug
        public async Task<int> Delete(Guid id)
        {
            try
            {
                DrugAdministration CurrentDrug = await Get(id);
                db.Drugs.Remove(CurrentDrug);
                return await SaveChanges();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        //Update existing drug 
        public async Task<int> Update(DrugAdministration entity)
        {
            try
            {
                DrugAdministration CurrentDrug = await Get(entity.DrugId);
                //gets the value of the attribute(s)updated and set it in the current value
                db.Entry(CurrentDrug).CurrentValues.SetValues(entity);
                //Change the entity state to modified.
                db.Entry(CurrentDrug).State = EntityState.Modified;
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
