using HospitalManagementSystem.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Service
{
    public class HospitalRepository : IHospital<Hospital>
    {
        readonly DbService db;
        public HospitalRepository(DbService db)
        {
            this.db = db;
        }

        //Get existing hospital by id
        public async Task<Hospital> Get(Guid id)
        {
            return await db.Hospital.Where(s => s.HospitalId == id).FirstOrDefaultAsync();
        }

        //Add new hospital
        public async Task<int> Add(Hospital entity)
        {

            try
            {
                if (entity == null)
                {
                    return 0;
                }
                entity.HospitalId = Guid.NewGuid();
                await db.Hospital.AddAsync(entity);
                return await SaveChanges();
            }
            catch (Exception)
            {

                return 0;
            }
        }

        //Update existing hospital
        public async Task<int> Update(Hospital entity)
        {
            try
            {
                Hospital currentHospital = await Get(entity.HospitalId);
                //gets the value of the attribute(s)updated and set it in the current value
                db.Entry(currentHospital).CurrentValues.SetValues(entity);
                //Change the entity state to modified.
                db.Entry(currentHospital).State = EntityState.Modified;
                return await SaveChanges();
            }
            catch (Exception)
            {

                return 0;
            }
        }
        //Delete existing hospital
        public async Task<int> Delete(Guid id)
        {
            try
            {
                Hospital currentHospital = await Get(id);
                db.Hospital.Remove(currentHospital);
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
        
        //no implementation
        public IEnumerable<Hospital> GetAll(Guid hospitalId)
        {
            throw new NotImplementedException();
        }

    }
}
