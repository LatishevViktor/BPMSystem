using BPMSystem.BLL.Interfaces;
using BPMSystem.DAL.Entities;
using BPMSystem.DAL.Interfaces;
using BPMSystem.Web.Communication;
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
        private readonly ILogger<DepartmentService> _logger;

        public DepartmentService(IDepartmentRepository repository, ILogger<DepartmentService> logger)
        {
            _logger = logger;
            _repository = repository;
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
                    string messageError = "Отдел с таким названием уже существует или регистрационным номером уже существует";
                    _logger.LogWarning(messageError);
                    throw new Exception(messageError);
                }
            }

            try
            {
                _logger.LogInformation("Идет запись нового отдела в БД...");
                await _repository.CreateDepartment(department);
            }
            catch (Exception ex) 
            {
                _logger.LogError("Произошла ошибка при создании нового отдела!");
                throw new Exception(ex.Message); 
            }
        }

        private int GenerateExtensionNumber() => new Random().Next(100, 1000);

        public async Task DeleteDepartment(int id)
        {
            try
            {
                await _repository.DeleteDepartment(id);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<DepartmentResponse> GetAllDepartment()
        {
            var departments = await _repository.GetAllDepartment();
            if (departments == null)
                return new DepartmentResponse(false, "Не удалось получить данные", null); 
            else
                return new DepartmentResponse(true, "Данные получены", departments);
        }

        public async Task<Department> GetDepartment(int id)
        {
            Department department;
            try
            {
                department = await _repository.GetDepartment(id);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }

            return department;
        }

        public async Task UpdateDepartment(Department department)
        {
            try
            {
                await _repository.UpdateDepartment(department);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
