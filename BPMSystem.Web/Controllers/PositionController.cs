using BPMSystem.BLL.DTO.Position;
using BPMSystem.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMSystem.Web.Controllers
{
    [Route("api/[controller]")]
    public class PositionController : Controller
    {
        private readonly IPositionService _service;
        public PositionController(IPositionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPosition()
        {
            try
            {
                var resultList = await _service.GetAllPosition();
                return Ok(resultList);
            }
            catch (Exception ex) { throw ex; }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DtoPosition>> GetPosition(Guid id)
        {
            try
            {
                var position = await _service.GetPosition(id);
                return Ok(position);
            }
            catch(Exception ex) { throw ex; }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePosition([FromBody] DtoCreatePosition dtoCreatePosition)
        {
            try
            {
                await _service.CreatePosition(dtoCreatePosition);
                return Ok();
            }
            catch(Exception ex) { throw ex; }
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePosition([FromBody]DtoPosition dtoPosition)
        {
            try
            {
                await _service.UpdatePosition(dtoPosition);
                return Ok();
            }
            catch(Exception ex) { throw ex; }
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePosition(Guid id)
        {
            try
            {
                await _service.DeletePosition(id);
                return Ok();
            }
            catch(Exception ex) { throw ex; }
        }
    }
}
