using BPMSystem.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMSystem.Domain.Interfaces.Repositories
{
    public interface IPositionRepository
    {
        /// <summary>
        /// Получить список должностей
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Position>> GetAllPosition();

        /// <summary>
        /// Получить конкретную должность
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Position> GetPosition(int id);

        /// <summary>
        /// Создать должность
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        Task CreatePosition(Position position);

        /// <summary>
        /// Обновить данные о должности
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        Task UpdatePosition(Position position);

        /// <summary>
        /// Удалить должность
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeletePosition(int id);
    }
}
