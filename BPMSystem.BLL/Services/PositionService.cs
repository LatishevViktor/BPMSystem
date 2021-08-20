using BPMSystem.BLL.DTO.Position;
using BPMSystem.BLL.Interfaces;
using BPMSystem.DAL.Entities;
using BPMSystem.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BPMSystemBLL.Services
{
    public class PositionService : IPositionService
    {
        private readonly IPositionRepository _repository;
        public PositionService(IPositionRepository repository)
        {
            _repository = repository;
        }
        public async Task CreatePosition(DtoCreatePosition dtoPosition)
        {
            List<Position> allPositions = await _repository.GetAllPosition();

            foreach(var pos in allPositions)
            {
                if(pos.Name == dtoPosition.Name 
                   && pos.Title == dtoPosition.Title)
                {
                    throw new Exception("Такая должность уже существует");
                }
            }

            var position = new Position
            {
                Name = dtoPosition.Name,
                Title = dtoPosition.Title
            };

            try
            {
                await _repository.CreatePosition(position);
            }
            catch (Exception ex) { throw ex; }
        }

        public async Task DeletePosition(Guid id)
        {
            try
            {
                await _repository.DeletePosition(id);
            }
            catch(Exception ex) { throw ex; }
        }

        public async Task<IEnumerable<DtoPosition>> GetAllPosition()
        {
            IEnumerable<Position> posList = new List<Position>();
            try
            {
                posList = await _repository.GetAllPosition();
            }
            catch(Exception ex) { throw ex; }

            //Маппинг данных
            var dtoPosList = posList.Select(pos => new DtoPosition
            {
                Id = pos.Id,
                Name = pos.Name,
                Title = pos.Title
            }).ToList();

            return dtoPosList;
        }

        public async Task<DtoPosition> GetPosition(Guid id)
        {
            Position position = new Position();
            try
            {
                position = await _repository.GetPosition(id);
            }
            catch(Exception ex) { throw ex; }

            var dtoPosition = new DtoPosition
            {
                Id = position.Id,
                Name = position.Name,
                Title = position.Title
            };

            return dtoPosition;
        }

        public async Task UpdatePosition(DtoPosition dtoPosition)
        {
            var position = new Position
            {
                Id = dtoPosition.Id,
                Name = dtoPosition.Name,
                Title = dtoPosition.Title
            };

            try
            {
                await _repository.UpdatePosition(position);
            }
            catch(Exception ex) { throw ex; }
        }
    }
}
