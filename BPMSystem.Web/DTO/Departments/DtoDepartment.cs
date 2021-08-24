using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMSystem.BLL.DTO
{
    /// <summary>
    /// DTO модель класса Department
    /// </summary>
    public class DtoDepartment
    {
        [Key]
        public Guid Id { get; set; }
        /// <summary>
        /// Наименование отдела
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Внутренний номер
        /// </summary>
        public int ExtensionNumber { get; set; }
    }
}
