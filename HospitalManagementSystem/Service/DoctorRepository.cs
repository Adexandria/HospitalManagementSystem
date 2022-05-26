using HospitalManagementSystem.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Service
{
    public class DoctorRepository : IHospital<Doctor>
    {
        readonly DbService db;
        public DoctorRepository(DbService db)
        {
            this.db = db;
        }
        //Get all doctors by hospital id
        public IEnumerable<Doctor> GetAll(Guid hospitalId)
        { 
            return db.Doctors.Where(s=>s.HospitalId==hospitalId).OrderBy(s => s.Name).Include(s => s.Hospital);
            
        }

        //Add new doctor to the database
        public async Task<int> Add(Doctor entity)
        {
            try
            {
                if (entity == null)
                {
                    return 0;
                }
                entity.DoctorId = Guid.NewGuid();
                await db.Doctors.AddAsync(entity);
                return await SaveChanges();
            }
            catch (Exception)
            {

                return 0;
            }
           
        }
        //Get existing doctor by doctor id
        public async Task<Doctor> Get(Guid id)
        {
            return await db.Doctors.Where(s => s.DoctorId == id).Include(s => s.Hospital).FirstOrDefaultAsync();
        }

        //Update existing doctor
        public async Task<int> Update(Doctor entity)
        {
            try
            {
                Doctor currentDoctor = await Get(entity.DoctorId);
                //gets the value of the attribute(s)updated and set it in the current value
                db.Entry(currentDoctor).CurrentValues.SetValues(entity);
                //Change the entity state to modified.
                db.Entry(currentDoctor).State = EntityState.Modified;
                return await SaveChanges();
            }
            catch (Exception)
            {

                return 0;
            }
            

        }
        //Delete doctor by doctor id
        public async Task<int> Delete(Guid id)
        {
            try
            {
                Doctor currentDoctor = await Get(id);
                db.Doctors.Remove(currentDoctor);
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
