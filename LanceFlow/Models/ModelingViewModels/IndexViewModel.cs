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

        public List<Variant> Variants;

        public int CurrentVariantId;

        public List<ProcessOfTechnologyDate> ProcessOfTechnologyDates;

        public DateTime CurrentDateId;

        public IndexViewModel()
        {
            Data = new FurmaGeneral();
        }
    }
}
