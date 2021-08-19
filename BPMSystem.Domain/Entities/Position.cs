using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMSystem.Domain.Core.Entities
{
    public class Position : BaseEntity
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
