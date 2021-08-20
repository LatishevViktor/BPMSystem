using BPMSystem.BLL.DTO.Position;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMSystem.BLL.Interfaces
{
    public interface IPositionService
    {
        Task<IEnumerable<DtoPosition>> GetAllPosition();
        Task<DtoPosition> GetPosition(Guid id);
        Task CreatePosition(DtoCreatePosition dtoPosition);
        Task UpdatePosition(DtoPosition dtoPosition);
        Task DeletePosition(Guid id);
    }
}
