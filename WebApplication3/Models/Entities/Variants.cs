using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models.Entities
{
    public class Variants
    {
        [Key]
        public int VariantId { get; set; }

        public string Name { get; set; }
    }
}
