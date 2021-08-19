using BPMSystem.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMSystem.Domain.Interfaces.Repositories
{
    public interface IDepartmentRepository
    {
        /// <summary>
        /// Получить список отделов
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Department>> GetAllDepartment();

        /// <summary>
        /// Получить конкретного отдела
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Department> GetDepartment(int id);

        /// <summary>
        /// Создать отдел
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        Task CreateDepartment(Department department);

        /// <summary>
        /// Обновить данные об отделе
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        Task UpdateDepartment(Department department);

        /// <summary>
        /// Удалить отдел
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteDepartment(int id);
    }
}
