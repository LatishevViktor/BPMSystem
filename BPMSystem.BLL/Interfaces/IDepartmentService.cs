using BPMSystem.DAL.Entities;
using BPMSystem.Web.Communication;
using System.Threading.Tasks;

namespace BPMSystem.BLL.Interfaces
{
    public interface IDepartmentService
    {
        Task<DepartmentResponse> GetAllDepartment();
        Task<Department> GetDepartment(int id);
        Task CreateDepartment(Department dtoDepartment);
        Task UpdateDepartment(Department dtoDepartment);
        Task DeleteDepartment(int id);
    }
}
