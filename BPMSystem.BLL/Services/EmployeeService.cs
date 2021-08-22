using BPMSystem.BLL.DTO.Employee;
using BPMSystem.BLL.DTO.Employees;
using BPMSystem.BLL.Interfaces;
using BPMSystem.DAL.Entities;
using BPMSystem.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMSystem.BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;      
        }

        public async Task CreateEmployee(DtoCreateEmployee dtoEmployee)
        {
            List<Employee> employeeList = await _repository.GetAllEmployee();
            foreach(var emp in employeeList)
            {
                if(emp.PersonNumber == dtoEmployee.PersonNumber)
                {
                    throw new Exception("Такой сотрудник уже существует");
                }
            }

            var employee = new Employee
            {
                FirstName = dtoEmployee.FirstName,
                LastName = dtoEmployee.LastName,
                PersonNumber = dtoEmployee.PersonNumber,
                DateOfBirth = dtoEmployee.DateOfBirth,
                EditDate = null,
                WorkExperience = dtoEmployee.WorkExperience,
                DepartmentId = dtoEmployee.DepartmentId,
                PositionId = dtoEmployee.PositionId
            };

            await _repository.CreateEmployee(employee);
        }

        public async Task DeleteEmployee(Guid id)
        {
            try
            {
                await _repository.DeleteEmployee(id);
            }
            catch (Exception ex) { throw ex; }
        }

        public async Task<IEnumerable<DtoEmployee>> GetAllEmployee()
        {
            IEnumerable<Employee> empList = new List<Employee>();
            try
            {
                empList = await _repository.GetAllEmployee();
            }
            catch(Exception ex) { throw ex; }

            //Маппинг данных
            var dtoList = empList.Select(emp => new DtoEmployee
            {
                Id = emp.Id,
                FirstName = emp.FirstName,
                LastName = emp.LastName,
                PersonNumber = emp.PersonNumber,
                DateOfBirth = emp.DateOfBirth,
                EditDate = emp.EditDate,
                WorkExperience = emp.WorkExperience,
                Department = emp.Department,
                DepartmentId = emp.DepartmentId,
                PositionId = emp.PositionId,
                Position = emp.Position
            });

            return dtoList;
        }

        public async Task<DtoEmployee> GetEmployee(Guid id)
        {
            Employee employee = new Employee();
            try
            {
                employee = await _repository.GetEmployee(id);
            }
            catch(Exception ex) { throw ex; }

            //Мапипнг данных
            var dtoEmp =  new DtoEmployee
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                PersonNumber = employee.PersonNumber,
                DateOfBirth = employee.DateOfBirth,
                EditDate = employee.EditDate,
                WorkExperience = employee.WorkExperience,
                Department = employee.Department,
                DepartmentId = employee.DepartmentId,
                PositionId = employee.PositionId,
                Position = employee.Position
            };

            return dtoEmp;
        }

        public async Task UpdateEmployee(DtoEmployee dtoEmployee)
        {
            var employee = new Employee
            {
                Id = dtoEmployee.Id,
                FirstName = dtoEmployee.FirstName,
                LastName = dtoEmployee.LastName,
                PersonNumber = dtoEmployee.PersonNumber,
                DateOfBirth = dtoEmployee.DateOfBirth,
                EditDate = DateTime.Now,
                WorkExperience = dtoEmployee.WorkExperience,
                DepartmentId = dtoEmployee.DepartmentId,
                PositionId = dtoEmployee.PositionId
            };

            try
            {
                await _repository.UpdateEmployee(employee);
            }
            catch(Exception ex) { throw ex; }
        }
    }
}
