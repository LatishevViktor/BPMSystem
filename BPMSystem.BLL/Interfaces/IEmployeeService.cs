using BPMSystem.BLL.DTO.Employee;
using BPMSystem.BLL.DTO.Employees;
using BPMSystem.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BPMSystem.BLL.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<DtoEmployee>> GetAllEmployee();
        Task<DtoEmployee> GetEmployee(Guid id);
        Task CreateEmployee(DtoCreateEmployee dtoEmployee);
        Task UpdateEmployee(DtoEmployee dtoEmployee);
        Task DeleteEmployee(Guid id);
    }
}
