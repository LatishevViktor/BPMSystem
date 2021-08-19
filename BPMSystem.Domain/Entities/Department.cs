using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMSystem.Domain.Core.Entities
{
    public class Department : BaseEntity
    {
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
