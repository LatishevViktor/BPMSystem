using BPMSystem.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BPMSystem.BLL.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllEmployee();
        Task<Employee> GetEmployee(Guid id);
        Task CreateEmployee(Employee dtoEmployee);
        Task UpdateEmployee(Employee dtoEmployee);
        Task DeleteEmployee(Guid id);
    }
}
