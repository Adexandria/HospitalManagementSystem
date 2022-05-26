using HospitalManagementSystem.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Service
{
    public class PharmacistRepository :IHospital<Pharmacist>
    {
        readonly DbService db;
        public PharmacistRepository(DbService db)
        {
            this.db = db;
        }

        //Get Pharmacist by pharmacist Id
        public async Task<Pharmacist> Get(Guid id)
        {
            return await db.Pharmacists.Where(s => s.PharmacistId == id).Include(s => s.Hospital).FirstOrDefaultAsync();
        }
        // Get all Hospital Pharmacist
        public IEnumerable<Pharmacist> GetAll(Guid hospitalId)
        {
            return db.Pharmacists.Where(s => s.HospitalId == hospitalId).OrderBy(s=>s.PharmacistId).Include(s => s.Hospital);
        }
        //Add new Pharmacist
        public async Task<int> Add(Pharmacist entity)
        {
            try
            {
                if (entity == null)
                {
                    return 0;
                }
                entity.PharmacistId = Guid.NewGuid();
                await db.Pharmacists.AddAsync(entity);
                return await SaveChanges();
            }
            catch (Exception)
            {

                return 0;
            }
        }

        //Delete Pharamacist
        public async Task<int> Delete(Guid id)
        {
            try
            {
                Pharmacist currentPharmacist = await Get(id);
                db.Pharmacists.Remove(currentPharmacist);
                return await SaveChanges();
            }
            catch (Exception)
            {

                return 0;
            }
        }

     
        //Update Pharmacist
        public async Task<int> Update(Pharmacist entity)
        {
            try
            {
                Pharmacist currentPharmacist = await Get(entity.PharmacistId);
                //gets the value of the attribute(s)updated and set it in the current value
                db.Entry(currentPharmacist).CurrentValues.SetValues(entity);
                //Change the entity state to modified.
                db.Entry(currentPharmacist).State = EntityState.Modified;
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
