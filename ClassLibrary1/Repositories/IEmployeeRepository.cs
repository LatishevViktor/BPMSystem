using BPMSystem.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMSystem.Domain.Interfaces.Repositories
{
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Получить список сотрудников
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Employee>> GetAllEmployee();

        /// <summary>
        /// Получить конкретного сотрудника
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Employee> GetEmployee(int id);

        /// <summary>
        /// Создать сотрудника
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        Task CreateEmployee(Employee employee);

        /// <summary>
        /// Обновить данные о сотруднике
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        Task UpdateEmployee(Employee employee);

        /// <summary>
        /// Удалить сотрудника
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteEmployee(int id);
    }
}
