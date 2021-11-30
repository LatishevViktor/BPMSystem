using System;
using System.Collections.Generic;


namespace BPMSystem.Web.ViewModel
{
    /// <summary>
    /// DTO модель класса Department
    /// </summary>
    public class ViewModelDepartment
    {
        public int Id { get; set; }
        /// <summary>
        /// Наименование отдела
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Внутренний номер
        /// </summary>
        public int ExtensionNumber { get; set; }

        /// <summary>
        /// Свойство неободимое для выведения данных о сотрудниках в конкретном отделе
        /// </summary>
        public List<ViewModelEmployee> Employees { get; set; }
    }
}
