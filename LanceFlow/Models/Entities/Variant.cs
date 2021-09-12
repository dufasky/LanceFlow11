using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LanceFlow.Models.Entities
{
    public class Variant
    {
        [Key]
        public int VariantId { get; set; }

        public string Name { get; set; }
    }
}
