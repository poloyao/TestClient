using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;

namespace DXApplication1.ViewModels
{
    [POCOViewModel]
    public class RealTimeDetectionViewModel:ViewModelBase
    {

        public virtual int param1 { get; set; }

        public virtual int param2 { get; set; }

        public virtual ParRTD parm { get; set; } = new ParRTD();


        public RealTimeDetectionViewModel()
        {
            parm = new ParRTD();
            parm.param1 = new Random(Guid.NewGuid().GetHashCode()).Next(0, 100);
            parm.param2 = new Random(Guid.NewGuid().GetHashCode()).Next(0, 100);
        }

        public void Reset()
        {
            param1 = new Random(Guid.NewGuid().GetHashCode()).Next(0, 100);
            param2 = new Random(Guid.NewGuid().GetHashCode()).Next(0, 100);

            //parm = new ParRTD();
            parm.param1 = new Random(Guid.NewGuid().GetHashCode()).Next(0, 100);
            parm.param2 = new Random(Guid.NewGuid().GetHashCode()).Next(0, 100);
        }
    }

    public class ParRTD
    {
        public virtual int param1 { get; set; }

        public virtual int param2 { get; set; }

        public ParRTD()
        { }
    }
}