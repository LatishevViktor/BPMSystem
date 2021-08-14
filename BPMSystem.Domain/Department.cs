using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMSystem.Domain
{
    public class Department
    {
        [Key]
        public Guid Id { get; set; }
        /// <summary>
        /// Наименование отдела
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Начальник отдела
        /// </summary>
        public string DepartmentHead { get; set; }
        /// <summary>
        /// Внутренний номер отдела
        /// </summary>
        public int ExtensionNumber { get; set; }
    }
}
