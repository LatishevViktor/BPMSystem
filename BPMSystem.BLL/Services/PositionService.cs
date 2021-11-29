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
        public async Task CreatePosition(Position position)
        {
            List<Position> allPositions = await _repository.GetAllPosition();

            foreach(var pos in allPositions)
            {
                if(pos.Name == position.Name 
                   && pos.Title == position.Title)
                {
                    throw new Exception("Такая должность уже существует");
                }
            }

            try
            {
                await _repository.CreatePosition(position);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task DeletePosition(int id)
        {
            try
            {
                await _repository.DeletePosition(id);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<IEnumerable<Position>> GetAllPosition()
        {
            IEnumerable<Position> posList;
            try
            {
                posList = await _repository.GetAllPosition();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }

            return posList;
        }

        public async Task<Position> GetPosition(int id)
        {
            Position position = new Position();
            try
            {
                position = await _repository.GetPosition(id);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }

            return position;
        }

        public async Task UpdatePosition(Position position)
        {
            try
            {
                await _repository.UpdatePosition(position);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
