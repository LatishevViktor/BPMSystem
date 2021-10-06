using BPMSystem.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMSystem.BLL.DTO.Employees
{
    /// <summary>
    /// DTO модель для создания сотрудника
    /// </summary>
    public class ViewModelCreateEmployee
    {
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия работника
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Дата рождения работника
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Дата изменения данных работника
        /// </summary>
        public DateTime? EditData { get; set; }

        /// <summary>
        /// Опыт работы
        /// </summary>
        public double WorkExperience { get; set; }

        /// <summary>
        /// Идентификатор должности
        /// </summary>
        [ForeignKey(nameof(Position))]
        public int PositionId { get; set; }

        /// <summary>
        /// Внешний ключ на Id отдела
        /// </summary>
        [ForeignKey(nameof(Department))]
        public int DepartmentId { get; set; }
    }
}
