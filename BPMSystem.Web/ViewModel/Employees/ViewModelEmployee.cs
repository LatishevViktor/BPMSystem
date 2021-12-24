using System;

namespace BPMSystem.Web.ViewModel
{
    public class ViewModelEmployee
    {
        public int Id { get; set; }
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
        public string DateOfBirth { get; set; }

        /// <summary>
        /// Дата изменеия данных работника
        /// </summary>
        public string EditDate { get; set; }

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
        public int PositionId { get; set; }

        /// <summary>
        /// Название должности
        /// </summary>
        public string PositionName { get; set; }

        /// <summary>
        /// Внешний ключ на Id отдела
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// Название отдела
        /// </summary>
        public string DepartmentName { get; set; }
    }
}
