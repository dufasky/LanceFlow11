using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models.Entities
{
    //ФАЙЛ СОЗДАНИЯ ТАБЛИЦЫ ДЛЯ ХАРАКТЕРИСТИК ПЕЧИ
    public class Pechi
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Vpolez { get; set; }

        

        public int NFurm { get; set; }

       

        public double DiamFurm { get; set; }

        public double VisFurm { get; set; }
    }
}
