using BPMSystem.DAL.EF;
using BPMSystem.DAL.Entities;
using BPMSystem.DAL.Exceptions;
using BPMSystem.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMSystem.DAL.Repositories
{
    public class PositionRepository : IPositionRepository
    {
        private readonly DataContext _context;
        public PositionRepository(DataContext context)
        {
            _context = context;
        }
        public async Task CreatePosition(Position position)
        {
            _context.Positions.Add(position);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePosition(Guid id)
        {
            var position = await _context.Positions.FirstOrDefaultAsync(pos => pos.Id == id);

            if(position == null)
            {
                throw new ObjectNotFoundException();
            }

            _context.Positions.Remove(position);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Position>> GetAllPosition()
        {
            return await _context.Positions.ToListAsync();

        }

        public async Task<Position> GetPosition(Guid id)
        {
            var position = await _context.Positions.FirstOrDefaultAsync(pos => pos.Id == id);
            if (position == null)
            {
                throw new ObjectNotFoundException();
            }
            return position;
        }

        public async Task UpdatePosition(Position position)
        {
            var pos = await _context.Positions.FirstOrDefaultAsync(pos => pos.Id == position.Id);
            if (pos == null)
            {
                throw new ObjectNotFoundException();
            }

            pos.Id = position.Id;
            pos.Name = position.Name;
            pos.Title = position.Title;

            await _context.SaveChangesAsync();
        }
    }
}
