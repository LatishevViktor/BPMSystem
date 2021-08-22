using BPMSystem.DAL.EF;
using BPMSystem.DAL.Entities;
using BPMSystem.DAL.Exceptions;
using BPMSystem.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMSystem.DAL.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _context;
        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }
        public async Task CreateEmployee(Employee employee)
        {
            _context.Add(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmployee(Guid id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(emp => emp.Id == id);

            if (employee == null)
            {
                throw new ObjectNotFoundException();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Employee>> GetAllEmployee()
        {
            return await _context.Employees
                         .Include(pos => pos.Position)
                         .Include(dep => dep.Department)
                         .ToListAsync();
        }

        public async Task<Employee> GetEmployee(Guid id)
        {
            var employee = await _context.Employees
                                .Include(pos => pos.Position)
                                .Include(dep => dep.Department)
                                .FirstOrDefaultAsync(emp => emp.Id == id);

            if(employee == null)
            {
                throw new ObjectNotFoundException();
            }
            return employee;
        }

        public async Task UpdateEmployee(Employee employee)
        {
            var emp = await _context.Employees.FirstOrDefaultAsync(emp => emp.Id == employee.Id);
            if (emp == null)
            {
                throw new ObjectNotFoundException();
            }

            emp.Id = employee.Id;
            emp.FirstName = employee.FirstName;
            emp.LastName = employee.LastName;
            emp.PersonNumber = employee.PersonNumber;
            emp.PositionId = employee.PositionId;
            emp.WorkExperience = employee.WorkExperience;
            emp.DateOfBirth = employee.DateOfBirth;
            emp.DepartmentId = employee.DepartmentId;

            await _context.SaveChangesAsync();
        }
    }
}
