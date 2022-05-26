using HospitalManagementSystem.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Service
{
    public class NurseRepository : IHospital<Nurse>
    {
        readonly DbService db;
        public NurseRepository(DbService db)
        {
            this.db = db;
        }
        //Get all nurses in the hospital
        public IEnumerable<Nurse> GetAll(Guid hospitalId) 
        {
                return db.Nurses.Where(s=>s.HospitalId == hospitalId).OrderBy(s => s.NurseId).Include(s=>s.Hospital);
        }

        //Add new nurse
        public async Task<int> Add(Nurse entity)
        {

            try
            {
                if (entity == null)
                {
                    return 0;
                }
                entity.NurseId = Guid.NewGuid();
                await db.Nurses.AddAsync(entity);
                return await SaveChanges();
            }
            catch (Exception)
            {

                return 0;
            }
        }
        //Get existing nurse
        public async Task<Nurse> Get(Guid id)
        {
            return await db.Nurses.Where(s => s.NurseId == id).Include(s => s.Hospital).FirstOrDefaultAsync();
        }

        //Update existing nurse
        public async Task<int> Update(Nurse entity)
        {
            try
            {
                Nurse currentNurse = await Get(entity.NurseId);
                //gets the value of the attribute(s)updated and set it in the current value
                db.Entry(currentNurse).CurrentValues.SetValues(entity);
                //Change the entity state to modified.
                db.Entry(currentNurse).State = EntityState.Modified;
                return await SaveChanges();
            }
            catch (Exception)
            {

                return 0;
            }
        }

        //Delete existing nurse
        public async Task<int> Delete(Guid id)
        {
            try
            {
                Nurse currentNurse = await Get(id);
                db.Nurses.Remove(currentNurse);
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
