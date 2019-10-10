using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models.Entities
{
    public class DanniePoFurmam
    {
        public int VariantId { get; set; }
        public int NFurm { get; set; }

        public bool isActual { get; set; }

        public double RashGazNaF { get; set; }
        public double RashVodiNaF { get; set; }
        public double Tperepad { get; set; }

    }
}
