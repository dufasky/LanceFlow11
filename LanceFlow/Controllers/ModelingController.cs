using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FurmaLibrary;
using LanceFlow.Models;
using LanceFlow.Models.Entities;
using LanceFlow.Models.ModelingViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanceFlow.Controllers
{
    public class ModelingController : Controller
    {
        private DcContext _context;

        public ModelingController(DcContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Variants> model = _context.Variants.ToList();

            return View(model);
        }

        [HttpPost]
        public IActionResult Result(FurmaGeneral input)
        {
            input.FurmaCalc();
            return View(input);
        }

        public IActionResult Vvod(int VariantId = 1)
        {
            ViewData["Message"] = "Your contact page.";

            IndexViewModel model = new IndexViewModel();

            model.CurrentVariantId = VariantId;
            model.Variants = _context.Variants.ToList();
            model.Data.SetDefaultData();

            // 
            List<DanniePoFurmam> data = _context.DanniePoFurmam.Where(x => x.VariantId == VariantId).ToList();

            ProcessOfTechnology data2 = _context.ProcessOfTechnology.FirstOrDefault(x => x.VariantId == VariantId);

            model.Data.Proizv = data2.Proizv;
            model.Data.RashDut = data2.RashDut;
            model.Data.SodKislorod = data2.SodKislorod;
            model.Data.UdRashKoks = data2.UdRashKoks;
            model.Data.TDut = data2.TDut;
            model.Data.DavlDut = data2.DavlDut;
            model.Data.VlazDut = data2.VlazDut;

            model.Data.Furm.Clear();

            foreach (DanniePoFurmam _dan in data)
            {
                model.Data.Furm.Add(new Furma
                {
                    isActual = _dan.isActual,
                    RashGazNaF = _dan.RashGazNaF,
                    RashVodiNaF = _dan.RashVodiNaF,
                    Tperepad = _dan.Tperepad,
                    TrebZnTeor = 2150
                });
            }


            // model.Furm;

            return View(model);
        }
    }
}