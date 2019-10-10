using System;

namespace ClassLibrary1
{//ЭТОТ ФАЙЛ НЕ НУЖЕН
    //ЭТОТ ФАЙЛ НЕ НУЖЕН
    //ЭТОТ ФАЙЛ НЕ НУЖЕН
    //ЭТОТ ФАЙЛ НЕ НУЖЕН
    //ЭТОТ ФАЙЛ НЕ НУЖЕН
    //ЭТОТ ФАЙЛ НЕ НУЖЕН
    //ЭТОТ ФАЙЛ НЕ НУЖЕН
    //ЭТОТ ФАЙЛ НЕ НУЖЕН
    //ЭТОТ ФАЙЛ НЕ НУЖЕН
    //ЭТОТ ФАЙЛ НЕ НУЖЕН
    //ЭТОТ ФАЙЛ НЕ НУЖЕН
    //ЭТОТ ФАЙЛ НЕ НУЖЕН
    //ЭТОТ ФАЙЛ НЕ НУЖЕН
    //ЭТОТ ФАЙЛ НЕ НУЖЕН
    //ЭТОТ ФАЙЛ НЕ НУЖЕН
    //ЭТОТ ФАЙЛ НЕ НУЖЕН
    //ЭТОТ ФАЙЛ НЕ НУЖЕН
    public class Class1
    {
        #region Входные данные из файла: "Дутье по фурмам"
        //Входные данные из файла: "Дутье по фурмам"
        public int NumberOfFurm { set; get; }
        public double Vpolez { set; get; }
        public double Proizv { set; get; }
        public double UdRashKoks { set; get; }
        public double Nfurm { set; get; }

        public double NrabFurm { set; get; }

        public double DiamFurm { set; get; }
        public double VisFurm { set; get; }
        public double RashDut { set; get; }
        public double DavlDut { set; get; }
        public double TDut { set; get; }
        public double VlazDut { set; get; }
        public double SodKislorod { set; get; }
        public double RashPrirGaz { set; get; }
        public double DiGorn { set; get; }

        //входные данные воздушных фурм из файла: "Дутье по фурмам"
        public double RashGazNaF { set; get; }
        public double RashVodiNaF { set; get; }
        public double Tperepad { set; get; }

        //cредние значения из файла: "Дутье по фурмам"
        public double SrKolTepla { set; get; }//заглушка на среднее!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        public double SrFactRashDut { set; get; }//заглушка на среднее!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        //теплоемкость воды как константа???
        public double TrebZnTeor { set; get; }//2150 в файле
        #endregion
        #region Недостающие входные данные из файла: "Фурменный очаг"
        public double Kszh { set; get; }
        public double PotPoTract { set; get; }
        public double ReaKoks { set; get; }

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

        #region Расчет для воздушных фурм (20 фурм. Расчет только для одной)
        //расчет для воздушных фурм
        public double KolTepla
        {
            get
            {
                return RashVodiNaF * Tperepad * 1000 * 4.18 / 3600;
            }
        }
        public double FactRashDut
        {
            get
            {
                return RashDut / NrabFurm * KolTepla / SrKolTepla;
            }
        }
        public double RasOtnos
        {
            get
            {
                return FactRashDut / SrFactRashDut;
            }
        }
        public double KolUgler
        {
            get
            {
                return 1.07143 * FactRashDut * 0.01 * SodKislorod;
            }
        }
        public double RashPGNaKG
        {
            get
            {
                return (RashGazNaF / 60) / KolUgler;
            }
        }
        public double TeplosodGorn
        {
            get
            {
                return (9800 + RashUgl * TeplosodDut + TeplosodKoks + RashPGNaKG * (1590 + RashGaz * TeplosodDut)) / (RashGorn + RashPGNaKG * VihGorn);
            }
        }
        public double TeorTGor
        {
            get
            {
                return 0.6113 * TeplosodGorn + 165;
            }
        }

        public double VIstDut
        {
            get
            {
                return ((FactRashDut + RashGazNaF / 60) * (TDut + 273) * 77.73) / (DiamFurm * DiamFurm * (1 + DavlDut));
            }
        }
        public double KinetW
        {
            get
            {
                return ((FactRashDut * 1.293 + RashGazNaF * 0.717 / 60) / 1177) * VIstDut * VIstDut;
            }
        }
        public double ProtZoniCirk
        {
            get
            {
                return 0.8039 + 0.00005 * KinetW - 0.0000000005 * KinetW * KinetW;
            }
        }
        public double ProtZoniOkisl
        {
            get
            {
                return ProtZoniCirk + 0.29;
            }
        }
        public double OtnoshVPGD
        {
            get
            {
                return ((RashGazNaF / 60) / FactRashDut) * 100;
            }
        }
        //public double TrebZnTeor
        //{
        //    get
        //    {
        //        return 2150;       //перенесено в начальные значения
        //    }
        //}
        public double TeplosodPriZadZn1
        {
            get
            {
                return (TrebZnTeor - 165) / 0.6113;
            }
        }
        public double RashPodderz
        {
            get
            {
                return (9800 + RashUgl * TeplosodDut + TeplosodKoks - TeplosodPriZadZn1 * RashGorn) / (TeplosodPriZadZn1 * VihGorn - (1590 + RashGaz * TeplosodDut));
            }
        }
        public double TrebRashGaz
        {
            get
            {
                return RashPodderz * KolUgler * 60;
            }
        }
        public double SFurmOchag
        {
            get
            {
                return 3.14 * ProtZoniCirk * ProtZoniCirk / 4;
            }
        }
        #endregion
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
    }
}
        
