using BPMSystem.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using BPMSystem.DAL.Entities;
using System.Linq;
using AutoMapper;
using System.Collections.Generic;
using BPMSystem.Web.ViewModel;
using Microsoft.Extensions.Logging;
using Serilog;
using BPMSystem.BLL.ConstantLog.Department;

namespace BPMSystem.Web.Controllers
{
    [Route("api/[controller]")]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentservice;
        private readonly IMapper _mapper;
        private readonly ILogger<DepartmentController> _logger;
        
        public DepartmentController(IDepartmentService departmentservice, IMapper mapper, ILogger<DepartmentController> logger)
        {
            _departmentservice = departmentservice;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment([FromBody]ViewModelCreateDepartment createViewModelDepartment)
        {
            try
            {
                //Маппинг
                var createDepartment = _mapper.Map<Department>(createViewModelDepartment);

                _logger.LogInformation("Cоздание нового отдела...");
                await _departmentservice.CreateDepartment(createDepartment);
                return Ok();
            }
            catch(Exception ex)
            {
                _logger.LogError(DepartmentLogs.ERROR_CREATE + ". {@ex}", ex.Message);
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
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
                _logger.LogError(DepartmentLogs.ERROR_GET_ALL + ". {@ex}", ex.Message);
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ViewModelDepartment>> GetDepartment(int id)
        { 
            try
            {
                var department = await _departmentservice.GetDepartment(id);
                _logger.LogInformation("Получение данных по отделу: {@department}", department.Name);
                //Маппинг
                var departmentDto = _mapper.Map<ViewModelDepartment>(department);
                return Ok(departmentDto);
            }
            catch(Exception ex)
            {
                _logger.LogError(DepartmentLogs.ERROR_GET + ". {@ex}", ex.Message);
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
                _logger.LogError(DepartmentLogs.ERROR_UPDATE + ". {ex}", ex.Message);
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
                _logger.LogError(DepartmentLogs.ERROR_DELETE + ". {ex}", ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
