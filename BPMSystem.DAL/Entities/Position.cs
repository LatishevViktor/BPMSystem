using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMSystem.DAL.Entities
{
    /// <summary>
    /// Класс описывающий долножсти сотрудников
    /// </summary>
    public class Position
    {
        [Key]
        public Guid Id { get; set; }
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
