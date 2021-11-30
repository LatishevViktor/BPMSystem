using System;

namespace BPMSystem.Web.ViewModel
{
    /// <summary>
    /// DTO модель для создания сотрудника
    /// </summary>
    public class ViewModelCreateEmployee
    {
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
        /// Дата изменения данных работника
        /// </summary>
        public DateTime? EditData { get; set; }

        /// <summary>
        /// Опыт работы
        /// </summary>
        public double WorkExperience { get; set; }

        /// <summary>
        /// Идентификатор должности
        /// </summary>
        public int PositionId { get; set; }

        /// <summary>
        /// Внешний ключ на Id отдела
        /// </summary>
        public int DepartmentId { get; set; }
    }
}
