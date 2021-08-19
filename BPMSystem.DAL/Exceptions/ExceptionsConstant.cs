using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMSystem.DAL.Exceptions
{
    public static class ExceptionsConstant
    {
        public const string NOT_FOUND = "Объект с заданным идентификатором не найден";
        public const string COMMON_EXCEPTION = "Вызов метода {MethodName} завершился с ошибкой";
    }
}
