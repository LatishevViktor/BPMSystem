using BPMSystem.BLL.DTO.Position;
using BPMSystem.BLL.Interfaces;
using BPMSystem.DAL.Entities;
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
                var posList = await _service.GetAllPosition();

                //Маппинг данных
                var dtoPosList = posList.Select(pos => new DtoPosition
                {
                    Id = pos.Id,
                    Name = pos.Name,
                    Title = pos.Title
                }).ToList();

                return Ok(dtoPosList);
            }
            catch (Exception ex) { throw ex; }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DtoPosition>> GetPosition(Guid id)
        {
            try
            {
                var position = await _service.GetPosition(id);

                var dtoPosition = new DtoPosition
                {
                    Id = position.Id,
                    Name = position.Name,
                    Title = position.Title
                };

                return Ok(dtoPosition);
            }
            catch(Exception ex) { throw ex; }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePosition([FromBody] ViewModelCreatePosition dtoCreatePosition)
        {
            try
            {
                var position = new Position
                {
                    Name = dtoCreatePosition.Name,
                    Title = dtoCreatePosition.Title
                };

                await _service.CreatePosition(position);
                return Ok();
            }
            catch(Exception ex) { throw ex; }
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePosition([FromBody]DtoPosition dtoPosition)
        {
            try
            {
                var position = new Position
                {
                    Id = dtoPosition.Id,
                    Name = dtoPosition.Name,
                    Title = dtoPosition.Title
                };

                await _service.UpdatePosition(position);
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
