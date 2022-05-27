using HospitalManagementSystem.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Service.Repository
{
    public class AccountantRepository : IHospital<Accountant>
    {
        readonly DbService db;
        public AccountantRepository(DbService db)
        {
            this.db = db;
        }

        //Gets all accountants in the hospital
        public IEnumerable<Accountant> GetAll(Guid hospitalId) 
        { 
                return db.Accountants.Where(s => s.HospitalId == hospitalId)
                .OrderBy(s => s.AccountantId).Include(s=>s.Hospital);
            
        }

        //Add new accountant to the database
        public async Task<int> Add(Accountant entity)
        {

            try
            {
                if (entity == null)
                {
                    return 0;
                }
                entity.AccountantId = Guid.NewGuid();
                await db.Accountants.AddAsync(entity);
                return await SaveChanges();
            }
            catch (Exception)
            {

                return 0;
            }
        }
        //Get existing accountant in the database
        public async Task<Accountant> Get(Guid id)
        {
            return await db.Accountants.Where(s => s.AccountantId == id).Include(s => s.Hospital).FirstOrDefaultAsync();
        }

        //Update existing account
        public async Task<int> Update(Accountant entity)
        {
            try
            {
                Accountant CurrentAccountant = await Get(entity.AccountantId);
                //gets the value of the attribute(s)updated and set it in the current value
                db.Entry(CurrentAccountant).CurrentValues.SetValues(entity);
                //Change the entity state to modified.
                db.Entry(CurrentAccountant).State = EntityState.Modified;
                return await SaveChanges();
            }
            catch (Exception)
            {

                return 0;
            }
        }

        //Delete existing accountant
        public async Task<int> Delete(Guid id)
        {
            try
            {
                Accountant CurrentAccountant = await Get(id);
                db.Accountants.Remove(CurrentAccountant);
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
