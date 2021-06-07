using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanceFlow.Models.Entities
{
    public class ProcessOfTechnologyDate
    {
        public DateTime DateId { get; set; }

        public int PechId { get; set; }

        public double UdRashKoks { get; set; }

        public double RashDut { get; set; }

        public double DavlDut { get; set; }

        public double TDut { get; set; }

        public double VlazDut { get; set; }

        public double SodKislorod { get; set; }

        public double Proizv { get; set; }
    }
}
