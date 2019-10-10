using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
namespace WebApplication3.Models
{
    public class InputData
    {
        #region Входные данные из файла: "Дутье по фурмам"
        //Входные данные из файла: "Дутье по фурмам"

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


        public double SrKolTepla { set; get; }//заглушка на среднее!!!!!
        public double SrFactRashDut { set; get; }//заглушка на среднее!!!!!


        public double TepKi { set; get; }
        public double TepAz { set; get; }
        public double TepDvuh { set; get; }
        public double RashUgl { set; get; }
        public double RashGaz { set; get; }
        public double RashGorn { set; get; }
        public double VihGorn { set; get; }
        public double TeplosodDut { set; get; }
        public double TeplosodKoks { set; get; }
        public double TeploemkDut { set; get; }
        public double TeploemkVod { set; get; } //теплоемкость воды как константа???

        public double TrebZnTeor { set; get; }


        public double RashGazNaF { set; get; }     //
        public double RashVodiNaF { set; get; }    //???
        public double Tperepad { set; get; }       //




        public int NumberOfFurm { set; get; }//номер фурмы 


        #endregion

        #region Недостающие входные данные из файла: "Фурменный очаг"
        public double Kszh { set; get; }
        public double PotPoTract { set; get; }
        public double ReaKoks { set; get; }
        #endregion 

        public List<Class1> Raschet { set; get; }

        public Class1 SredRaschet { set; get; }


        //среднее значение?????
        //cредние значения из файла: "Дутье по фурмам"
       

        public InputData()
        {
            Raschet = new List<Class1>();
        }

        public void SetDefaultData()//начальные значения 
        {
            this.Nfurm = 20;

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
            this.RashPrirGaz = 82.6;

            this.SrKolTepla = 130;//заглушка на среднее
            this.SrFactRashDut = 120;//заглушка на среднее
            
            this.Kszh = 0.75;
            this.PotPoTract = 7;
            this.ReaKoks = 31.5;


            this.RashGazNaF = 908.522;   ///
            this.RashVodiNaF = 11.412;   ///???
            this.Tperepad = 11.25;      ///


            this.TrebZnTeor = 2150;

            for (int i = 0; i < Nfurm; i++)//сколько используем начальных значений в зависимости от того сколько фурм работает
            {
                Class1 cls = new Class1
                {
                    NumberOfFurm = i + 1,
                    Vpolez = 1370,
                    Proizv = 6500,
                    UdRashKoks = 418.6,
                    DiamFurm = 142,
                    VisFurm = 350,
                    RashDut = 2417,
                    DavlDut = 2.5,
                    NrabFurm = 20,

                    TDut = 1182,
                    VlazDut = 16.4,
                    SodKislorod = 25.12,
                    RashPrirGaz = 82.6,
                    Kszh = 0.75,
                    PotPoTract = 7,
                    ReaKoks = 31.5,
                    RashGazNaF = 908.522,
                    RashVodiNaF = 11.412,
                    Tperepad = 11.25,


                    SrKolTepla = 130,//заглушка на среднее
                    SrFactRashDut = 120,//заглушка на среднее
                    TrebZnTeor = 2150,
            };

                this.Raschet.Add(cls);
            }


        }

    }
}

