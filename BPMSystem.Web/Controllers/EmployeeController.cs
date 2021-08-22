using BPMSystem.BLL.DTO.Employee;
using BPMSystem.BLL.DTO.Employees;
using BPMSystem.BLL.Interfaces;
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
                return Ok(empList);
            }
            catch(Exception ex) { throw ex; }
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] DtoCreateEmployee createEmployee)
        {
            try
            {
                await _service.CreateEmployee(createEmployee);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            try
            {
                await _service.DeleteEmployee(id);
                return Ok();
            }
            catch(Exception ex) { throw ex; }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(DtoEmployee dtoEmployee)
        {
            try
            {
                await _service.UpdateEmployee(dtoEmployee);
                return Ok();
            }
            catch(Exception ex) { throw ex; }
        }

    }
}
