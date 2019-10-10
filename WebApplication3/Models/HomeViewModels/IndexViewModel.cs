using FurmaLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models.Entities;

namespace WebApplication3.Models.HomeViewModels
{
    public class IndexViewModel
    {
        public FurmaGeneral Data;

        public List<Variants> Variants;

        public int CurrentVariantId;

        public IndexViewModel()
        {
            Data = new FurmaGeneral();
        }
    }
}
