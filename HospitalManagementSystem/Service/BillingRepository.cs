using HospitalManagementSystem.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Service
{
    public class BillingRepository : IHospital<BillingManagement>
    {
        readonly DbService db;
        public BillingRepository(DbService db)
        {
            this.db = db;
        }
        //Get existing bills by billing id
        public Task<BillingManagement> Get(Guid id)
        {
            return db.Billings.Where(s => s.BillingId == id).Include(s=>s.Patient).FirstOrDefaultAsync();
        }

        // Get all bills by patient id
        public IEnumerable<BillingManagement> GetAll(Guid patientId)
        {
            return db.Billings.Where(s => s.PatientId == patientId).OrderBy(s => s.BillingId);
        }
        //Add new bill
        public async Task<int> Add(BillingManagement entity)
        {
            try
            {
                if (entity == null)
                {
                    return 0;
                }
                entity.BillingId = Guid.NewGuid();
                await db.Billings.AddAsync(entity);
                return await SaveChanges();
            }
            catch (Exception)
            {

                return 0;
            }
        }

        //Delete existing bill
        public async Task<int> Delete(Guid id)
        {
            try
            {
                BillingManagement currentBilling = await Get(id);
                db.Billings.Remove(currentBilling);
                return await SaveChanges();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        

        public async Task<int> Update(BillingManagement entity)
        {
            try
            {
                BillingManagement currentBilling = await Get(entity.BillingId);
                //gets the value of the attribute(s)updated and set it in the current value
                db.Entry(currentBilling).CurrentValues.SetValues(entity);
                //Change the entity state to modified.
                db.Entry(currentBilling).State = EntityState.Modified;
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
