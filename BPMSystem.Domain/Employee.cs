using System;

namespace BPMSystem.Domain
{
    // Класс описывающий сотрудника
    public class Employee
    {
        /// <summary>
        /// Id сотрудника
        /// </summary>
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
    }
}
