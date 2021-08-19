using BPMSystem.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMSystem.BLL.Interfaces
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DtoDepartment>> GetAllDepartment();
        Task<DtoDepartment> GetDepartment(Guid id);
        Task CreateDepartment(DtoCreateDepartment dtoDepartment);
        Task UpdateDepartment(DtoDepartment dtoDepartment);
        Task DeleteDepartment(Guid id);
    }
}
