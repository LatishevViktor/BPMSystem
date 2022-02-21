using BPMSystem.DAL.Entities;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace BPMSystem.BLL.Interfaces
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetAllDepartment();
        Task<Department> GetDepartment(int id);
        Task CreateDepartment(Department dtoDepartment);
        Task UpdateDepartment(Department dtoDepartment);
        Task DeleteDepartment(int id);
    }
}
