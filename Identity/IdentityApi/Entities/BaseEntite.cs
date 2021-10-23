using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityApi.Entities
{
    public class BaseEntite
    {
        [Key]
        public long UserId { get; set; }
    }
}
