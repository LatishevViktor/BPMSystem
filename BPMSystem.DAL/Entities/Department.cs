using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMSystem.DAL.Entities
{
    /// <summary>
    /// Класс, описывающий отдел компании
    /// </summary>
    public class Department
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Наименование отдела
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Внутренний номер
        /// </summary>
        public int ExtensionNumber { get; set; }

        /// <summary>
        /// Свойство неободимое для выведения данных о сотрудниках в конкретном отделе
        /// </summary>
        public virtual List<Employee> Employees { get; set; }
    }
}
