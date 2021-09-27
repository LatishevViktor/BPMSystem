using BPMSystem.BLL.DTO.Employee;
using BPMSystem.BLL.DTO.Employees;
using BPMSystem.BLL.Interfaces;
using BPMSystem.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMSystem.Web.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _service;
        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
        {
            try
            {
                var empList = await _service.GetAllEmployee();

                //Маппинг данных
                var dtoList = empList.Select(emp => new ViewModelEmployee
                {
                    Id = emp.Id,
                    FirstName = emp.FirstName,
                    LastName = emp.LastName,
                    PersonNumber = emp.PersonNumber,
                    DateOfBirth = emp.DateOfBirth,
                    EditDate = emp.EditDate,
                    WorkExperience = emp.WorkExperience,
                    DepartmentName = emp.Department.Name,
                    PositionName = emp.Position.Name
                });

                return Ok(dtoList);
            }
            catch(Exception ex) { throw ex; }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ViewModelEmployee>> GetEmployee(int id)
        {
            try
            {
                var employee = await _service.GetEmployee(id);

                //Мапипнг данных
                var dtoEmp = new ViewModelEmployee
                {
                    Id = employee.Id,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    PersonNumber = employee.PersonNumber,
                    DateOfBirth = employee.DateOfBirth,
                    EditDate = employee.EditDate,
                    WorkExperience = employee.WorkExperience,
                    DepartmentName = employee.Department.Name,
                    PositionName = employee.Position.Name
                };

                return Ok(dtoEmp);
            }
            catch(Exception ex) { throw ex; }
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] ViewModelCreateEmployee createDtoEmployee)
        {
            try
            {
                var employee = new Employee
                {
                    FirstName = createDtoEmployee.FirstName,
                    LastName = createDtoEmployee.LastName,
                    DateOfBirth = createDtoEmployee.DateOfBirth,
                    EditDate = null,
                    WorkExperience = createDtoEmployee.WorkExperience,
                    DepartmentId = createDtoEmployee.DepartmentId,
                    PositionId = createDtoEmployee.PositionId
                };

                await _service.CreateEmployee(employee);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                await _service.DeleteEmployee(id);
                return Ok();
            }
            catch(Exception ex) { throw ex; }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(ViewModelEmployee dtoEmployee)
        {
            try
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

                await _service.UpdateEmployee(employee);
                return Ok();
            }
            catch(Exception ex) { throw ex; }
        }

    }
}
