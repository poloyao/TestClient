using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;

namespace DXApplication1.ViewModels
{
    [POCOViewModel]
    public class SetDetector2ViewModel
    {
        public ControlParameter ControlData { get; set; } = new ControlParameter();

        public ControlParameter5 ControlData2 { get; set; } = new ControlParameter5();

        public ControlParameter3 ControlData3 { get; set; } = new ControlParameter3();

        public ControlParameter4 ControlData4 { get; set; } = new ControlParameter4();
        

    }
}