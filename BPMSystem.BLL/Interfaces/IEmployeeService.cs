using BPMSystem.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BPMSystem.BLL.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllEmployee();
        Task<Employee> GetEmployee(int id);
        Task CreateEmployee(Employee dtoEmployee);
        Task UpdateEmployee(Employee dtoEmployee);
        Task DeleteEmployee(int id);
    }
}
