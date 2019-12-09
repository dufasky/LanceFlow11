using FurmaLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanceFlow.Models.Entities;

namespace LanceFlow.Models.ModelingViewModels
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
