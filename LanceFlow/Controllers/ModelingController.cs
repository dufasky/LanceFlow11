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

                Variants variant = _context.Variants.FirstOrDefault(x => x.VariantId == RemoveVariantId);

                if(variant != null)
                {
                    _context.Variants.Remove(variant);
                }
                _context.SaveChanges();
            }

            List<Variants> model = _context.Variants.ToList();

            return View(model);
        }

        [HttpPost]
        public IActionResult Result(FurmaGeneral input, string VariantName)
        {
            if(VariantName != null && VariantName != String.Empty)
            {
                Variants variant = new Variants { Name = VariantName };
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

        public IActionResult Vvod(int VariantId = 1)
        {
            IndexViewModel model = new IndexViewModel();

            model.CurrentVariantId = VariantId;
            model.Variants = _context.Variants.ToList();
            model.Data.SetDefaultData();

            // 
            List<DanniePoFurmam> data = _context.DanniePoFurmam.Where(x => x.VariantId == VariantId).ToList();

            ProcessOfTechnology processData = _context.ProcessOfTechnology.FirstOrDefault(x => x.VariantId == VariantId);

            if(processData != null)
            {
                Pechi pech = _context.Pechi.FirstOrDefault(x => x.Id == processData.PechId);

                if(pech != null)
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


            // model.Furm;

            return View(model);
        }
    }
}