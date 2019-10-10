using System;

namespace FurmaLibrary
{
    public class Furma//все значения по фурмам (20 штук в екселе)
    {
        public int NumberOfFurm { set; get; }//начальные
        public bool isActual { get; set; }

        public double RashGazNaF { set; get; }
        public double RashVodiNaF { set; get; }
        public double Tperepad { set; get; }
        public double TrebZnTeor { set; get; }

        public double KolTepla { set; get; }//расчетные
        public double RashDutPribor { set; get; }
        public double FactRashDut { set; get; }
        public double RasOtnos { set; get; }
        public double KolUgler { set; get; }
        public double RashPGNaKG { set; get; }
        public double TeplosodGorn { set; get; }
        public double TeorTGor { set; get; }
        public double VIstDut { set; get; }
        public double KinetW { set; get; }
        public double ProtZoniCirk { set; get; }
        public double ProtZoniOkisl { set; get; }
        public double OtnoshVPGD { set; get; }
        public double TeplosodPriZadZn1 { set; get; }
        public double RashPodderz { set; get; }
        public double TrebRashGaz { set; get; }
        public double SFurmOchag { set; get; }
    }
}
        
