using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Service
{
    public interface IHospital<T>
    {
        IEnumerable<T> GetAll(Guid hospitalId);
        Task<T> Get(Guid id);
        Task<int> Add(T entity);
        Task<int> Update(T entity);
        Task<int> Delete(Guid id);

    }
}
