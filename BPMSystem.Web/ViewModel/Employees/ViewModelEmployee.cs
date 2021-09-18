using BPMSystem.DAL.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BPMSystem.BLL.DTO.Employee
{
    public class ViewModelEmployee
    {
        public Guid Id { get; set; }
        /// <summary>
        /// Имя работника
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия работника
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Дата рождения работника
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Дата изменеия данных работника
        /// </summary>
        public DateTime? EditDate { get; set; }

        /// <summary>
        /// Опыт работы
        /// </summary>
        public double WorkExperience { get; set; }

        /// <summary>
        /// Табельный номер
        /// </summary>
        public string PersonNumber { get; set; }

        /// <summary>
        /// Идентификатор должности
        /// </summary>
        [ForeignKey(nameof(Position))]
        public Guid PositionId { get; set; }

        /// <summary>
        /// Название должности
        /// </summary>
        public string PositionName { get; set; }

        /// <summary>
        /// Внешний ключ на Id отдела
        /// </summary>
        [ForeignKey(nameof(Department))]
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// Название отдела
        /// </summary>
        public string DepartmentName { get; set; }
    }
}
