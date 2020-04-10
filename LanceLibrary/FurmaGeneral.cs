using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace FurmaLibrary
{
    public class FurmaGeneral
    {
        public FurmaGeneral()
        {
            Furm = new List<Furma>();
        }

        // начальные значения (общие, не по каждой фурме)
        public double Vpolez { set; get; }

        public double Proizv { set; get; }

        [Display(Name = "Удельный расход кокса, кг/т чуг")]
        public double UdRashKoks { set; get; }

        public Int32 Nfurm { set; get; }

        public Int32 NrabFurm { set; get; }

        public double DiamFurm { set; get; }

        public double VisFurm { set; get; }
        
        [Display(Name = "Расход дутья, м<sup>3</sup>/мин")]
        public double RashDut { set; get; }

        [Display(Name = "Давление дутья, ати")]
        public double DavlDut { set; get; }

        [Display(Name = "Температура дутья, &deg;С")]
        public double TDut { set; get; }

        [Display(Name = "Влажность дутья, г/м<sup>3</sup>")]
        public double VlazDut { set; get; }

        [Display(Name = "Содержание кислорода в дутье, %")]
        public double SodKislorod{ set; get; }

        public double DiGorn { set; get; }

        [Display(Name= "Коэффициент сжатия фурменного очага (в плане)")]
        public double Kszh { set; get; }

        [Display(Name = "Принятые потери расхода дутья по тракту, %")]
        public double PotPoTract { set; get; }

        [Display(Name = "Реакционная способность кокса, %")]
        public double ReaKoks { set; get; }

        public List<Furma> Furm { set; get; }//ПАКУЕМ В ЛИСТ ВСЕ НАЧАЛЬНЫЕ И РАСЧЕТНЫЕ ЗНАЧЕНИЯ ПО КАЖДОЙ ФУРМЕ

        //дальше общие расчеты (не по каждой фурме)

        [Display(Name = "Расход природного газа, м3/т чуг")]
        public double RashPrirGaz
        {
            get
            {
                if (Furm.Count == 0)
                    return 0;

                return Furm.Sum(x => x.RashGazNaF) * 24d / Proizv;
            }
        }

        public double VIstDut
        {
            get
            {
                return ((RashDut * (1 - 0.01 * PotPoTract) + RashPrirGaz * Proizv / 1440) * (TDut + 273) * 77.73) / (NrabFurm * DiamFurm * DiamFurm * (1 + DavlDut));
            }
        }

        public double KinetW
        {
            get
            {
                return ((RashDut * (1 - 0.01 * PotPoTract) * 1.293 + 0.717 * RashPrirGaz * Proizv / 1440) * VIstDut * VIstDut) / (1177 * NrabFurm);
            }
        }

        public double ProtZoniCirk
        {
            get
            {
                return 0.6386 + 0.0001 * KinetW - 0.000000002 * KinetW * KinetW;
            }
        }

        public double ProtZoniOkisl
        {
            get
            {
                return ProtZoniCirk + (0.0187 * ReaKoks - 0.3531);
            }
        }

        #region расчет из файла: "Фурменный очаг" (расчеты которых нет в файле: "Дутье по фурмам")
        
        public double DlinSrOkr
        {
            get
            {
                return (DiGorn - (2 * VisFurm + ProtZoniOkisl)) * 3.14;
            }
        }

        public double SumDlinOs
        {
            get
            {
                return NrabFurm * ProtZoniOkisl * Kszh;
            }
        }

        public double Perecr
        {
            get
            {
                return (SumDlinOs - DlinSrOkr) / NrabFurm;
            }
        }
        #endregion

        #region Предварительные расчеты из файла "Дутьё по фурмамам"
        //предварительные расчеты
        public double TepKi
        {
            get
            {
                return 1.4851 + 0.000118 * TDut;
            }
        }

        public double TepAz
        {
            get
            {
                return 1.3902 + 0.000133 * TDut;
            }
        }

        public double TepDvuh
        {
            get
            {
                return 1.2897 + 0.000121 * TDut;
            }
        }

        public double TepPar
        {
            get
            {
                return 1.456 + 0.000282 * TDut;
            }
        }

        public double RashUgl
        {
            get
            {
                return 0.9333 / (0.01 * SodKislorod + 0.00124 * VlazDut);
            }
        }

        public double RashGaz
        {
            get
            {
                return 0.5 / (0.01 * SodKislorod + 0.00124 * VlazDut);
            }
        }

        public double RashGorn
        {
            get
            {
                return 1.8667 + RashUgl * (1 - 0.01 * SodKislorod + 0.00124 * VlazDut);
            }
        }

        public double VihGorn
        {
            get
            {
                return 3 + RashGaz * (1 - 0.01 * SodKislorod + 0.00124 * VlazDut);
            }
        }

        public double TeplosodDut
        {
            get
            {
                return TepDvuh * TDut - 0.00124 * VlazDut * (10800 - TepPar * TDut);
            }
        }

        public double TeplosodKoks
        {
            get
            {
                return 1.65 * 1500;
            }
        }

        public double TeploemkDut
        {
            get
            {
                return 0.01 * SodKislorod * TepKi + (1 - 0.01 * SodKislorod) * TepAz;
            }
        }

        public double TeploemkVod
        {
            get
            {
                return 4183;
            }
        }
        #endregion

        public void FurmaCalc()//создаем метод расчетов значений по каждой фурме
        {
            for (int i = 0; i < Furm.Count; i++)
            {
                if (Furm[i].isActual == false)
                {
                    Furm[i].RashGazNaF = 0;
                }

                Furm[i].KolTepla = Furm[i].RashVodiNaF * Furm[i].Tperepad * 1000 * 4.18 / 3600;
                //расчет параметра для каждой фурмы(в цикле чтобы расчитать в дальнейшем среднее)
            }
            double SrKolTepla = Furm.Average(x => x.KolTepla);//расчет среднего
            NrabFurm = Furm.Count(x => x.isActual == true);

            for (int i = 0; i < Furm.Count; i++)
            {
                if (Furm[i].isActual)
                {
                    Furm[i].FactRashDut = RashDut / NrabFurm * Furm[i].KolTepla / SrKolTepla;
                }
            }
            double SrFactRashDut = Furm.Average(x => x.FactRashDut);//расчет среднего

            // расчет каждого параметра для каждой фурмы
            for (int i = 0; i < Furm.Count; i++)
            {
                if ( ! Furm[i].isActual) continue;

                Furm[i].RashDutPribor = RashDut / NrabFurm;
                Furm[i].RasOtnos = Furm[i].FactRashDut / SrFactRashDut;
                Furm[i].KolUgler = 1.07143 * Furm[i].FactRashDut * 0.01 * SodKislorod;
                Furm[i].RashPGNaKG = (Furm[i].RashGazNaF / 60) / Furm[i].KolUgler;
                Furm[i].TeplosodGorn = (9800 + RashUgl * TeplosodDut + TeplosodKoks + Furm[i].RashPGNaKG * (1590 + RashGaz * TeplosodDut)) / (RashGorn + Furm[i].RashPGNaKG * VihGorn);
                Furm[i].TeorTGor = 0.6113 * Furm[i].TeplosodGorn + 165;

                Furm[i].VIstDut = ((Furm[i].FactRashDut * (1 - 0.01 * PotPoTract) + Furm[i].RashGazNaF / 60) * (TDut + 273) * 77.73) / (DiamFurm * DiamFurm * (1 + DavlDut));

                Furm[i].KinetW = ((Furm[i].FactRashDut * (1 - 0.01 * PotPoTract) * 1.293 + Furm[i].RashGazNaF * 0.717 / 60) / 1177) * Furm[i].VIstDut * Furm[i].VIstDut;

                // Furm[i].ProtZoniCirk = 0.8039 + 0.00005 * KinetW - 0.0000000005 * KinetW * KinetW;
                // или
                Furm[i].ProtZoniCirk = 0.6386 + 0.0001 * Furm[i].KinetW - 0.000000002 * Furm[i].KinetW * Furm[i].KinetW;
               // Furm[i].ProtZoniCirk = 0.8039 + 0.00005 * Furm[i].KinetW - 0.0000000005 * Furm[i].KinetW * Furm[i].KinetW;
                //Furm[i].ProtZoniOkisl = ProtZoniCirk + 0.29;
                // или
                Furm[i].ProtZoniOkisl = Furm[i].ProtZoniCirk + (0.0187 * ReaKoks - 0.3531);

                Furm[i].OtnoshVPGD = ((Furm[i].RashGazNaF / 60) / Furm[i].FactRashDut) * 100;
                Furm[i].TeplosodPriZadZn1 = (Furm[i].TrebZnTeor - 165) / 0.6113;
                Furm[i].RashPodderz = (9800 + RashUgl * TeplosodDut + TeplosodKoks - Furm[i].TeplosodPriZadZn1 * RashGorn) / (Furm[i].TeplosodPriZadZn1 * VihGorn - (1590 + RashGaz * TeplosodDut));
                Furm[i].TrebRashGaz = Furm[i].RashPodderz * Furm[i].KolUgler * 60;
                Furm[i].SFurmOchag = 3.14 * Furm[i].ProtZoniCirk * Furm[i].ProtZoniCirk / 4;

            }
        }
        public void SetDefaultData()//начальные значения 
        {
            this.Nfurm = 20;
            this.DiGorn = 1000;

            this.Vpolez = 1370;
            this.Proizv = 6500;
            this.UdRashKoks = 418.6;

            this.NrabFurm = 20;

            this.DiamFurm = 142;
            this.VisFurm = 350;
            this.RashDut = 2417;
            this.DavlDut = 2.5;
            this.TDut = 1182;
            this.VlazDut = 16.4;
            this.SodKislorod = 25.12;

            this.Kszh = 0.75;
            this.PotPoTract = 7;
            this.ReaKoks = 31.5;

            for (int i = 0; i < Nfurm; i++)//сколько используем начальных значений в зависимости от того сколько фурм работает
            {
                Furma cls = new Furma
                {
                    RashGazNaF = 908.522,//начальные значения
                    RashVodiNaF = 11.412,
                    Tperepad = 11.25,
                    TrebZnTeor = 2150
                };

                this.Furm.Add(cls);
            }
        }
    }

}
        
