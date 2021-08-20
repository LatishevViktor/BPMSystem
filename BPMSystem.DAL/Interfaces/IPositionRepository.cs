using BPMSystem.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMSystem.DAL.Interfaces
{
    public interface IPositionRepository
    {
        /// <summary>
        /// Получение список всех должностей
        /// </summary>
        /// <returns></returns>
        Task<List<Position>> GetAllPosition();
        /// <summary>
        /// Получение должности
        /// </summary>
        /// <returns></returns>
        Task<Position> GetPosition(Guid id);
        /// <summary>
        /// Создаем должность
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        Task CreatePosition(Position position);
        /// <summary>
        /// Обновляем должность
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        Task UpdatePosition(Position position);
        /// <summary>
        /// Удаляем должность
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        Task DeletePosition(Guid id);
    }
}
