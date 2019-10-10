using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models.Entities
{
    //ФАЙЛ СОЗДАНИЯ ТАБЛИЦЫ В БД ДЛЯ ТЕХНОЛОГИЧЕСКОГО ПРОЦЕССА
    public class ProcessOfTechnology
    {
      
        public int VariantId { get; set; }

        public int PechId { get; set; }
        public double UdRashKoks { get; set; }
        public double RashDut { get; set; }
        public double DavlDut { get; set; }
        public double TDut { get; set; }//поля
        public double VlazDut { get; set; }
        public double SodKislorod { get; set; }
        public double RashPrirGaz { get; set; }
        public double Proizv { get; set; }
        public int NrabFurm { get; set; }

    }
}
