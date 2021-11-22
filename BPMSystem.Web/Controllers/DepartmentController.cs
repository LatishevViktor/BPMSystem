using BPMSystem.BLL.DTO;
using BPMSystem.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using BPMSystem.DAL.Entities;
using System.Linq;
using AutoMapper;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace BPMSystem.Web.Controllers
{
    [Route("api/[controller]")]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentservice;
        private readonly IMapper _mapper;
        
        public DepartmentController(IDepartmentService departmentservice, IMapper mapper)
        {
            _departmentservice = departmentservice;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment([FromBody]ViewModelCreateDepartment createViewModelDepartment)
        {
            try
            {
                //Маппинг
                var createDepartment = _mapper.Map<Department>(createViewModelDepartment);
                await _departmentservice.CreateDepartment(createDepartment);
                return Ok();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllDepartments()
        {
            try
            {
                var depList = await _departmentservice.GetAllDepartment();

                //Маппинг
                var departments = _mapper.Map<List<ViewModelDepartment>>(depList);
                return Ok(departments);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ViewModelDepartment>> GetDepartment(int id)
        { 
            try
            {
                var department = await _departmentservice.GetDepartment(id);
                //Маппинг
                var departmentDto = _mapper.Map<ViewModelDepartment>(department);
                return Ok(departmentDto);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDepartment([FromBody]ViewModelDepartment viewModelDepartment)
        {
            try
            {
                //Маппинг
                var department = _mapper.Map<Department>(viewModelDepartment);

                await _departmentservice.UpdateDepartment(department);
                return Ok();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
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
