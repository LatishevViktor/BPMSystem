using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMSystem.BLL.DTO.Position
{
    /// <summary>
    /// DTO модель для создания должностей
    /// </summary>
    public class DtoCreatePosition
    {
        /// <summary>
        /// Наименование должности
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public string Title { get; set; }
    }
}
