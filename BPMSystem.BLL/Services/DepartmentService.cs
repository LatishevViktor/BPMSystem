﻿using BPMSystem.BLL.Interfaces;
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
        private readonly IEmployeeRepository _employeeRepository;

        public DepartmentService(IDepartmentRepository repository, IEmployeeRepository employeeRepository)
        {
            _repository = repository;
            _employeeRepository = employeeRepository;
        }

        public async Task CreateDepartment(Department department)
        {
            department.ExtensionNumber = GenerateExtensionNumber();
            List<Department> allDepartment = await _repository.GetAllDepartment();

            // Проверяем есть существует ли отдел с таким же именем или внутренним номером
            foreach(var allDep in allDepartment)
            {
                if(allDep.Name == department.Name
                    || allDep.ExtensionNumber == department.ExtensionNumber)
                {
                    throw new Exception("Отдел с таким названием уже существует или регистрационным номером уже существует");
                }
            }

            try
            {
                await _repository.CreateDepartment(department);
            }
            catch (Exception ex) { throw ex; }
        }

        private int GenerateExtensionNumber() => new Random().Next(100, 1000);

        public async Task DeleteDepartment(int id)
        {
            try
            {
                await _repository.DeleteDepartment(id);
            }
            catch (Exception ex) { throw ex; }
        }

        public async Task<IEnumerable<Department>> GetAllDepartment()
        {
            IEnumerable<Department> depList = new List<Department>();
            try
            {
                depList = await _repository.GetAllDepartment();
            }
            catch (Exception ex) { throw ex; }

            return depList.ToList();
        }

        public async Task<Department> GetDepartment(int id)
        {
            var empDep = await _employeeRepository.GetAllEmployee();

            var resultEmp = empDep.Where(emp => emp.DepartmentId == id).ToList();
            Department department = new Department();
            try
            {
                department = await _repository.GetDepartment(id);
                department.Employees = resultEmp;
            }
            catch (Exception ex) { throw ex; }

            return department;
        }

        public async Task UpdateDepartment(Department department)
        {
            try
            {
                await _repository.UpdateDepartment(department);
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
