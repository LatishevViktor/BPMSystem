using System;
using System.ComponentModel.DataAnnotations;

namespace BPMSystem.Domain
{
    // Класс описывающий сотрудника
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Дата найма на работу
        /// </summary>
        public DateTime? DateOfWork { get; set; }

        /// <summary>
        /// Должность
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// Опыт работы
        /// </summary>
        public string WorkExperience { get; set; }

        /// <summary>
        /// Табельный номер
        /// </summary>
        public string PersonNumber { get; set; }
    }
}
