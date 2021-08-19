using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMSystem.DAL.Exceptions
{
    public class ObjectNotFoundException : Exception
    {
        public ObjectNotFoundException(string message = ExceptionsConstant.NOT_FOUND) : base(message) { }
    }
}
