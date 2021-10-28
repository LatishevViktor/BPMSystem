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
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DataContext _context;
        public DepartmentRepository(DataContext context)
        {
            _context = context;
        }
        public async Task CreateDepartment(Department department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDepartment(int id)
        {
            var dep = await _context.Departments.FirstOrDefaultAsync(dep => dep.Id == id);

            var res = dep ?? throw new ObjectNotFoundException();
            _context.Departments.Remove(dep);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Department>> GetAllDepartment()
        {
            return await _context.Departments
                                 .Include(emp => emp.Employees)
                                 .ToListAsync();
        }

        public async Task<Department> GetDepartment(int id)
        {
            var dep = await _context.Departments
                                    .Include(emp => emp.Employees)
                                    .FirstOrDefaultAsync(dep => dep.Id == id);
                      
            return dep ?? throw new ObjectNotFoundException();
        }

        public async Task UpdateDepartment(Department department)
        {
            var dep = await _context.Departments.FirstOrDefaultAsync(dep => dep.Id == department.Id);

            var res = dep ?? throw new ObjectNotFoundException("Невозможно обновить данные не существующего объекта");
            dep.Id = department.Id;
            dep.Name = department.Name;
            dep.ExtensionNumber = department.ExtensionNumber;

            await _context.SaveChangesAsync();
        }
    }
}
