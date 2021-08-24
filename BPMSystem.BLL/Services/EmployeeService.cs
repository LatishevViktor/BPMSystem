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

        public async Task CreateEmployee(Employee employee)
        {
            List<Employee> employeeList = await _repository.GetAllEmployee();
            foreach(var emp in employeeList)
            {
                if(emp.PersonNumber == employee.PersonNumber)
                {
                    throw new Exception("Такой сотрудник уже существует");
                }
            }
            try
            {
                await _repository.CreateEmployee(employee);
            }
            catch(Exception ex) { throw ex; }
        }

        public async Task DeleteEmployee(Guid id)
        {
            try
            {
                await _repository.DeleteEmployee(id);
            }
            catch (Exception ex) { throw ex; }
        }

        public async Task<IEnumerable<Employee>> GetAllEmployee()
        {
            IEnumerable<Employee> empList = new List<Employee>();
            try
            {
                empList = await _repository.GetAllEmployee();
            }
            catch(Exception ex) { throw ex; }

            return empList;
        }

        public async Task<Employee> GetEmployee(Guid id)
        {
            Employee employee = new Employee();
            try
            {
                employee = await _repository.GetEmployee(id);
            }
            catch(Exception ex) { throw ex; }

            

            return employee;
        }

        public async Task UpdateEmployee(Employee employee)
        {
            try
            {
                await _repository.UpdateEmployee(employee);
            }
            catch(Exception ex) { throw ex; }
        }
    }
}
