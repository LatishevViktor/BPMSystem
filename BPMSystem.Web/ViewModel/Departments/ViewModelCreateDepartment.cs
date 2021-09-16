using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMSystem.BLL.DTO
{
    /// <summary>
    /// DTO модель для создания отделов
    /// </summary>
    public class ViewModelCreateDepartment
    { 
        public string Name { get; set; }

        /// <summary>
        /// Внутренний номер
        /// </summary>
        public int ExtensionNumber { get; set; }
    }
}
