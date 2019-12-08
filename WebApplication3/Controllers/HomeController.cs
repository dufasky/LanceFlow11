﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FurmaLibrary;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.Models.Entities;
using WebApplication3.Models.HomeViewModels;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        public DcContext _context;

        public HomeController(DcContext context)
        {
            this._context = context;

        }

        public IActionResult Index()
        {
            List<Variants> model = _context.Variants.ToList();

            return View(model);
        }

        public IActionResult Modeling()
        {
            List<Variants> model = _context.Variants.ToList();

            return View(model);
        }

        [HttpPost]//пост когда нажимаем кнопку отправить 
        public IActionResult About(FurmaGeneral input)
        {
            input.FurmaCalc();
            return View(input);
        }

        [HttpGet]
        public IActionResult About()
        {
            return View();
        }
        public IActionResult area()
        {
            return View();
        }
        public IActionResult Artist()
        {
            return View();
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

            foreach(DanniePoFurmam _dan in data)
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
