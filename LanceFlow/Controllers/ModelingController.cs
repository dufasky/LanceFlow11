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

        public int PechId { get; private set; }

        public ModelingController(DcContext context)
        {
            _context = context;
        }

        public IActionResult Index(int RemoveVariantId)
        {
            if(RemoveVariantId > 0)
            {
                ProcessOfTechnology processData = _context.ProcessOfTechnology.FirstOrDefault(x => x.VariantId == RemoveVariantId);

                if (processData != null)
                {
                    _context.ProcessOfTechnology.Remove(processData);
                }

                List<DanniePoFurmam> furmData = _context.DanniePoFurmam.Where(x => x.VariantId == RemoveVariantId).ToList();
                
                if (furmData != null)
                {
                    _context.DanniePoFurmam.RemoveRange(furmData);
                }

                Variant variant = _context.Variants.FirstOrDefault(x => x.VariantId == RemoveVariantId);

                if(variant != null)
                {
                    _context.Variants.Remove(variant);
                }
                _context.SaveChanges();
            }

            List<Variant> model = _context.Variants.ToList();

            return View(model);
        }
        
        public IActionResult History()
        {
            List<ProcessOfTechnologyDate> model = _context.ProcessOfTechnologyDate.ToList();

            return View(model);
        }

        [HttpPost]
        public IActionResult Result(FurmaGeneral input, string VariantName)
        {
            if (VariantName != null && VariantName != String.Empty)
            {
                Variant variant = new Variant 
                { 
                    Name = VariantName
                };
                _context.Variants.Add(variant);
                _context.SaveChanges();

                Pechi searchPech = _context.Pechi.FirstOrDefault(x => x.NFurm == input.Nfurm && x.DiamFurm == input.DiamFurm && x.VisFurm == input.VisFurm && x.Vpolez == input.Vpolez);

                int PechId = 0;
                
                if(searchPech == null)
                {
                    Pechi newPech = new Pechi
                    {
                        NFurm = input.Nfurm,
                        DiamFurm = input.DiamFurm,
                        VisFurm = input.VisFurm,
                        Vpolez = input.Vpolez
                    };
                    _context.Pechi.Add(newPech);
                    _context.SaveChanges();

                    PechId = newPech.Id;
                }
                else
                {
                    PechId = searchPech.Id;
                }

                #region -- Process data

                ProcessOfTechnology processData = new ProcessOfTechnology
                {
                    VariantId = variant.VariantId,
                    PechId = PechId,
                    Proizv = input.Proizv,
                    RashDut = input.RashDut,
                    SodKislorod = input.SodKislorod,
                    UdRashKoks = input.UdRashKoks,
                    TDut = input.TDut,
                    DavlDut = input.DavlDut,
                    VlazDut = input.VlazDut, 
                };
                _context.ProcessOfTechnology.Add(processData);

                #endregion

                #region -- Furma data

                foreach (Furma furm in input.Furm)
                {
                    DanniePoFurmam furmData = new DanniePoFurmam
                    {
                        VariantId = variant.VariantId,
                        NFurm = furm.NumberOfFurm,
                        isActual = furm.isActual,
                        RashGazNaF = furm.RashGazNaF,
                        RashVodiNaF = furm.RashVodiNaF,
                        Tperepad = furm.Tperepad,
                        TrebZnTeor = furm.TrebZnTeor
                    };

                    _context.DanniePoFurmam.Add(furmData);
                }

                #endregion

                _context.SaveChanges();
            }

            input.FurmaCalc();
            return View(input);
        }

        public IActionResult Create()
        {
            IndexViewModel model = new IndexViewModel();
            model.Data.SetDefaultData();

            return View("Vvod", model);
        }

        public IActionResult Vvod(int VariantId, DateTime DateId)
        {
            if (VariantId > 0)
            {
                IndexViewModel model = new IndexViewModel();

                model.CurrentVariantId = VariantId;
                model.Variants = _context.Variants.ToList();
                model.Data.SetDefaultData();

                // 
                List<DanniePoFurmam> data = _context.DanniePoFurmam.Where(x => x.VariantId == VariantId).ToList();

                ProcessOfTechnology processData = _context.ProcessOfTechnology.FirstOrDefault(x => x.VariantId == VariantId);

                if (processData != null)
                {
                    Pechi pech = _context.Pechi.FirstOrDefault(x => x.Id == processData.PechId);

                    if (pech != null)
                    {
                        model.Data.Nfurm = pech.NFurm;
                        model.Data.DiamFurm = pech.DiamFurm;
                        model.Data.VisFurm = pech.VisFurm;
                        model.Data.Vpolez = pech.Vpolez;
                    }

                    model.Data.Proizv = processData.Proizv;
                    model.Data.RashDut = processData.RashDut;
                    model.Data.SodKislorod = processData.SodKislorod;
                    model.Data.UdRashKoks = processData.UdRashKoks;
                    model.Data.TDut = processData.TDut;
                    model.Data.DavlDut = processData.DavlDut;
                    model.Data.VlazDut = processData.VlazDut;
                }

                model.Data.Furm.Clear();

                foreach (DanniePoFurmam _dan in data)
                {
                    model.Data.Furm.Add(new Furma
                    {
                        isActual = _dan.isActual,
                        RashGazNaF = _dan.RashGazNaF,
                        RashVodiNaF = _dan.RashVodiNaF,
                        Tperepad = _dan.Tperepad,
                        TrebZnTeor = _dan.TrebZnTeor
                    });
                }
                return View(model);
            }
            else
            {

                DateTime test = DateTimeFormatter.DateFormatter(DateId);
                IndexViewModel model = new IndexViewModel();

                model.CurrentDateId = DateId;
                model.ProcessOfTechnologyDates = _context.ProcessOfTechnologyDate.ToList();
                model.Data.SetDefaultData();

                // 
                List<DanniePoFurmamDate> data = _context.DanniePoFurmamDate.Where(x => x.DateId == DateTimeFormatter.DateFormatter(DateId)).ToList();

                ProcessOfTechnologyDate processData = _context.ProcessOfTechnologyDate.FirstOrDefault(x => x.DateId == DateTimeFormatter.DateFormatter(DateId));

                if (processData != null)
                {
                    Pechi pech = _context.Pechi.FirstOrDefault(x => x.Id == processData.PechId);

                    if (pech != null)
                    {
                        model.Data.Nfurm = pech.NFurm;
                        model.Data.DiamFurm = pech.DiamFurm;
                        model.Data.VisFurm = pech.VisFurm;
                        model.Data.Vpolez = pech.Vpolez;
                    }

                    model.Data.Proizv = processData.Proizv;
                    model.Data.RashDut = processData.RashDut;
                    model.Data.SodKislorod = processData.SodKislorod;
                    model.Data.UdRashKoks = processData.UdRashKoks;
                    model.Data.TDut = processData.TDut;
                    model.Data.DavlDut = processData.DavlDut;
                    model.Data.VlazDut = processData.VlazDut;
                }

                model.Data.Furm.Clear();

                foreach (DanniePoFurmamDate _dan in data)
                {
                    model.Data.Furm.Add(new Furma
                    {
                        isActual = _dan.isActual,
                        RashGazNaF = _dan.RashGazNaF,
                        RashVodiNaF = _dan.RashVodiNaF,
                        Tperepad = _dan.Tperepad,
                        TrebZnTeor = _dan.TrebZnTeor
                    });
                }
                return View(model);
            }
            // model.Furm;
        }
    }
}