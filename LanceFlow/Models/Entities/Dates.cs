using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace LanceFlow.Models.Entities
{
    public class Dates
    {
        [Key]
        public DateTime DateId { get; set; }

        public string Name { get; set; }
        public object VariantId { get; internal set; }
    }
}
