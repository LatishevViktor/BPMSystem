using AutoMapper;
using BPMSystem.BLL.Interfaces;
using BPMSystem.DAL.Entities;
using BPMSystem.Web.ViewModel;
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
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
        {
            try
            {
                var empList = await _service.GetAllEmployee();

                //Маппинг
                var dtoList = _mapper.Map<IEnumerable<ViewModelEmployee>>(empList);
                return Ok(dtoList);
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ViewModelEmployee>> GetEmployee(int id)
        {
            try
            {
                var employee = await _service.GetEmployee(id);

                //Мапипнг данных
                var dtoEmp = _mapper.Map<ViewModelEmployee>(employee);

                return Ok(dtoEmp);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] ViewModelCreateEmployee createDtoEmployee)
        {
            try
            {
                //Маппинг
                var employee = _mapper.Map<Employee>(createDtoEmployee);

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
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(ViewModelEmployee dtoEmployee)
        {
            try
            {
                //Маппинг
                var employee = _mapper.Map<Employee>(dtoEmployee);
                employee.EditDate = DateTime.Now;

                await _service.UpdateEmployee(employee);
                return Ok();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

    }
}
