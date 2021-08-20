using BPMSystem.BLL.DTO;
using BPMSystem.BLL.Interfaces;
using BPMSystem.DAL.Entities;
using BPMSystem.DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BPMSystemBLL.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _repository;
        public DepartmentService(IDepartmentRepository repository)
        {
            _repository = repository;
        }
        public async Task CreateDepartment(DtoCreateDepartment dtoDepartment)
        {
            List<Department> allDepartment = await _repository.GetAllDepartment();

            // Проверяем есть существует ли отдел с таким же именем или внутренним номером
            foreach(var allDep in allDepartment)
            {
                if(allDep.Name == dtoDepartment.Name
                    || allDep.ExtensionNumber == dtoDepartment.ExtensionNumber)
                {
                    throw new Exception("Отдел с таким названием уже существует или регистрационным номером уже существует");
                }
            }

            var department = new Department
            {
                Name = dtoDepartment.Name,
                ExtensionNumber = dtoDepartment.ExtensionNumber
            };

            try
            {
                await _repository.CreateDepartment(department);
            }

            catch (Exception ex) { throw ex; }
        }

        public async Task DeleteDepartment(Guid id)
        {
            try
            {
                await _repository.DeleteDepartment(id);
            }
            catch (Exception ex) { throw ex; }
        }

        public async Task<IEnumerable<DtoDepartment>> GetAllDepartment()
        {
            IEnumerable<Department> depList = new List<Department>();
            try
            {
                depList = await _repository.GetAllDepartment();
            }
            catch (Exception ex) { throw ex; }

            // Маппинг данных
            var dtoList = depList.Select(dep => new DtoDepartment
            {
                Id = dep.Id,
                Name = dep.Name,
                ExtensionNumber = dep.ExtensionNumber
            }).ToList();

            return dtoList.ToList();
        }

        public async Task<DtoDepartment> GetDepartment(Guid id)
        {
            Department department = new Department();
            try
            {
                department = await _repository.GetDepartment(id);
            }
            catch (Exception ex) { throw ex; }

            var dtoDepartment = new DtoDepartment
            {
                Id = department.Id,
                Name = department.Name,
                ExtensionNumber = department.ExtensionNumber
            };

            return dtoDepartment;
        }

        public async Task UpdateDepartment(DtoDepartment dtoDepartment)
        {
            var department = new Department
            {
                Id = dtoDepartment.Id,
                Name = dtoDepartment.Name,
                ExtensionNumber = dtoDepartment.ExtensionNumber
            };

            try
            {
                await _repository.UpdateDepartment(department);
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
