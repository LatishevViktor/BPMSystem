using BPMSystem.BLL.DTO;
using BPMSystem.BLL.Interfaces;
using BPMSystem.DAL.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMSystem.Web.Controllers
{
    [Route("api/department")]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentservice;
        public DepartmentController(IDepartmentService departmentservice)
        {
            _departmentservice = departmentservice;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment([FromBody]DtoCreateDepartment createDepartment)
        {
            try
            {
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
                return Ok(department);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDepartment(DtoDepartment dtoDepartment)
        {
            try
            {
                await _departmentservice.UpdateDepartment(dtoDepartment);
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
