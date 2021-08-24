using BPMSystem.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMSystem.BLL.Interfaces
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetAllDepartment();
        Task<Department> GetDepartment(Guid id);
        Task CreateDepartment(Department dtoDepartment);
        Task UpdateDepartment(Department dtoDepartment);
        Task DeleteDepartment(Guid id);
    }
}
