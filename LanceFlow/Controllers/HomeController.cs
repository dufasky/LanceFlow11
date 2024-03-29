﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LanceFlow.Models;
using LanceFlow.Models.Entities;
using FurmaLibrary;

namespace LanceFlow.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private DcContext _context;

        public HomeController(DcContext context, ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            List<Variant> model = _context.Variants.ToList();

            return View(model);
        }

        public IActionResult History()
        {
            List<ProcessOfTechnologyDate> model = _context.ProcessOfTechnologyDate.ToList();

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
