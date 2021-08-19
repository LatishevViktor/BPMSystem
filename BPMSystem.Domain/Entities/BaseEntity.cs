using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMSystem.Domain.Core.Entities
{
    public class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // атрибут указывающий на то, что Id будет генерироваться БД
        public Guid Id { get; set; }
    }
}
