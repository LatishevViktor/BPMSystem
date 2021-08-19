using BPMSystem.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMSystem.DAL.Interfaces
{
    public interface IDepartmentRepository
    {
        /// <summary>
        /// Получение всех отделов
        /// </summary>
        /// <returns></returns>
        Task<List<Department>> GetAllDepartment();
        /// <summary>
        /// Получение одного отдела
        /// </summary>
        /// <returns></returns>
        Task<Department> GetDepartment(Guid id);
        /// <summary>
        /// Создаем отдел
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        Task CreateDepartment(Department department);
        /// <summary>
        /// Обновляем отдел
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        Task UpdateDepartment(Department department);
        /// <summary>
        /// Удаляем отдел
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        Task DeleteDepartment(Guid id);
    }
}
