using BPMSystem.Domain.Core.Entities;
using BPMSystem.Domain.DataContext;
using BPMSystem.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMSystem.Infrastructure.Data.EntityRepositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly BpmContext _context;
        public DepartmentRepository(BpmContext context)
        {
            _context = context;
        }
        public async Task CreateDepartment(Department department)
        {
            await _context.Departments.AddAsync(department);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDepartment(Guid id)
        {
            var department = await _context.Departments.FirstOrDefaultAsync(
                dep => dep.Id == id);

            if()
        }

        public Task<IEnumerable<Department>> GetAllDepartment()
        {
            
        }

        public Task<Department> GetDepartment(int id)
        {
            
        }

        public Task UpdateDepartment(Department department)
        {
            
        }
    }
}
