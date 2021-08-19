using BPMSystem.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMSystem.DAL.Interfaces
{
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Получение всех сотрудников
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Employee>> GetAllEmployee();
        /// <summary>
        /// Получение одного сотрудника
        /// </summary>
        /// <returns></returns>
        Task<Employee> GetEmployee(Guid id);
        /// <summary>
        /// Создаем сотрудника
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        Task CreateEmployee(Employee employee);
        /// <summary>
        /// Обновляем сотрудника
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        Task UpdateEmployee(Employee employee);
        /// <summary>
        /// Удаляем сотрудника
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        Task DeleteEmployee(Guid id);
    }
}
