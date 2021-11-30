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
    public class PositionController : Controller
    {
        private readonly IPositionService _service;
        private readonly IMapper _mapper;
        public PositionController(IPositionService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPosition()
        {
            try
            {
                var posList = await _service.GetAllPosition();

                //Маппинг данных
                var dtoPosList = _mapper.Map<IEnumerable<ViewModelPosition>>(posList);

                return Ok(dtoPosList);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ViewModelPosition>> GetPosition(int id)
        {
            try
            {
                var position = await _service.GetPosition(id);

                //Маппинг
                var dtoPosition = _mapper.Map<ViewModelPosition>(position);

                return Ok(dtoPosition);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePosition([FromBody] ViewModelCreatePosition dtoCreatePosition)
        {
            try
            {
                //Маппинг
                var position = _mapper.Map<Position>(dtoCreatePosition);

                await _service.CreatePosition(position);
                return Ok();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePosition([FromBody] ViewModelPosition dtoPosition)
        {
            try
            {
                //Маппинг
                var position = _mapper.Map<Position>(dtoPosition);

                await _service.UpdatePosition(position);
                return Ok();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePosition(int id)
        {
            try
            {
                await _service.DeletePosition(id);
                return Ok();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
