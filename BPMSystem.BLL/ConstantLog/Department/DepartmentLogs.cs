using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMSystem.BLL.ConstantLog.Department
{
    public static class DepartmentLogs
    {
        // Константы логов при ошибках
        public const string ERROR_CREATE = "Ошибка при создании отдела";
        public const string ERROR_UPDATE = "Ошибка при обновлении отдела";
        public static string ERROR_DELETE = "Ошибка при удалении отдела";
        public static string ERROR_GET = "Ошибка при получении данных об отделе";
        public static string ERROR_GET_ALL = "Ошибка при получении данных о списках отделов";
    }
}
