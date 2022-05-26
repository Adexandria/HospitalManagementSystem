using HospitalManagementSystem.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Service
{
    public class ReceptionistRepository : IHospital<Receptionist>
    {
        readonly DbService db;
        public ReceptionistRepository(DbService db)
        {
            this.db = db;
        }

        // Get Receptionist by receptionist id
        public async Task<Receptionist> Get(Guid id)
        {
            return await db.Receptionists.Where(s => s.ReceptionistId == id).Include(s => s.Hospital).FirstOrDefaultAsync();
        }

        //Get all receptionist in the database
        public IEnumerable<Receptionist> GetAll(Guid hospitalId)
        {
            return db.Receptionists.Where(s => s.ReceptionistId == hospitalId).Include(s => s.Hospital);
        }
        //Add new receptionist
        public async Task<int> Add(Receptionist entity)
        {

            try
            {
                if (entity == null)
                {
                    return 0;
                }
                entity.ReceptionistId = Guid.NewGuid();
                await db.Receptionists.AddAsync(entity);
                return await SaveChanges();
            }
            catch (Exception)
            {

                return 0;
            }
        }
        //Delete Receptionist
        public async Task<int> Delete(Guid id)
        {
            try
            {
                Receptionist currentReceptionist = await Get(id);
                db.Receptionists.Remove(currentReceptionist);
                return await SaveChanges();
            }
            catch (Exception)
            {

                return 0;
            }
        }
        //Update existing receptionist
        public async Task<int> Update(Receptionist entity)
        {
            try
            {
                Receptionist currentReceptionist = await Get(entity.ReceptionistId);
                //gets the value of the attribute(s)updated and set it in the current value
                db.Entry(currentReceptionist).CurrentValues.SetValues(entity);
                //Change the entity state to modified.
                db.Entry(currentReceptionist).State = EntityState.Modified;
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
