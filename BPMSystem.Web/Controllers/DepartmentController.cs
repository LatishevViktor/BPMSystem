using BPMSystem.BLL.DTO;
using BPMSystem.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using BPMSystem.DAL.Entities;
using System.Linq;

namespace BPMSystem.Web.Controllers
{
    [Route("api/[controller]")]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentservice;
        public DepartmentController(IDepartmentService departmentservice)
        {
            _departmentservice = departmentservice;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment([FromBody]DtoCreateDepartment createDtoDepartment)
        {
            try
            {
                var createDepartment = new Department
                {
                    Name = createDtoDepartment.Name,
                    ExtensionNumber = createDtoDepartment.ExtensionNumber
                };

                await _departmentservice.CreateDepartment(createDepartment);
                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDepartments()
        {
            try
            {
                var depList = await _departmentservice.GetAllDepartment();

                // Маппинг данных
                var dtoList = depList.Select(dep => new Department
                {
                    Id = dep.Id,
                    Name = dep.Name,
                    ExtensionNumber = dep.ExtensionNumber
                }).ToList();

                return Ok(depList);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DtoDepartment>> GetDepartment(Guid id)
        { 
            try
            {
                var department = await _departmentservice.GetDepartment(id);

                var dtoDepartment = new Department
                {
                    Id = department.Id,
                    Name = department.Name,
                    ExtensionNumber = department.ExtensionNumber,
                    Employees = department.Employees
                };

                return Ok(dtoDepartment);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDepartment([FromBody]DtoDepartment dtoDepartment)
        {
            try
            {
                var department = new Department
                {
                    Id = dtoDepartment.Id,
                    Name = dtoDepartment.Name,
                    ExtensionNumber = dtoDepartment.ExtensionNumber
                };

                await _departmentservice.UpdateDepartment(department);
                return Ok();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(Guid id)
        {
            try
            {
                await _departmentservice.DeleteDepartment(id);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
