using BPMSystem.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMSystem.BLL.Interfaces
{
    public interface IPositionService
    {
        Task<IEnumerable<Position>> GetAllPosition();
        Task<Position> GetPosition(Guid id);
        Task CreatePosition(Position dtoPosition);
        Task UpdatePosition(Position dtoPosition);
        Task DeletePosition(Guid id);
    }
}
