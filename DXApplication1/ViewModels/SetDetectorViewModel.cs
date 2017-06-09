using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Windows.Controls;
using DevExpress.Mvvm.POCO;

namespace DXApplication1.ViewModels
{
    [POCOViewModel]
    public class SetDetectorViewModel
    {
        public ControlParameter ControlData { get; set; } = new ControlParameter();

        public ControlParameter2 ControlData2 { get; set; } = new ControlParameter2();

        public ControlParameter3 ControlData3 { get; set; } = new ControlParameter3();

        public ControlParameter4 ControlData4 { get; set; } = new ControlParameter4();

        public SetDetectorViewModel()
        {

        }
    }


    public class ControlParameter
    {
        const string group1 = "轴重自动控制设定";
        const string group2 = "固定轴重设定";
        const string group3 = "尾气控制设定";

        [Display(Name = "参数1", GroupName = group1)]
        [Range(0, 1000000)]
        public virtual decimal Param1 { get; set; }
        [Display(Name = "参数2", GroupName = group1)]
        [Range(0, 1000000)]
        public decimal Param2 { get; set; }
        [Display(Name = "参数3", GroupName = group1)]
        [Range(0, 1000000)]
        public decimal Param3 { get; set; }
        [Display(Name = "参数4", GroupName = group1)]
        [Range(0, 1000000)]
        public decimal Param4 { get; set; }
        [Display(Name = "参数5", GroupName = group2)]
        [Range(0, 1000000)]
        public decimal Param5 { get; set; }
        [Display(Name = "参数6", GroupName = group2)]
        [Range(0, 1000000)]
        public decimal Param6 { get; set; }
        [Display(Name = "参数7", GroupName = group3)]
        [Range(0, 1000000)]
        public decimal Param7 { get; set; }
        [Display(Name = "参数8", GroupName = group3)]
        [Range(0, 1000000)]
        public decimal Param8 { get; set; }
        [Display(Name = "参数9", GroupName = group3)]
        [Range(0, 1000000)]
        public decimal Param9 { get; set; }
        [Display(Name = "参数10", GroupName = group3)]
        [Range(0, 1000000)]
        public decimal Param10 { get; set; }

        public void RaisePropertyChanged(string propertyName)
        {
            throw new NotImplementedException();
        }

        public void RaisePropertyChanging(string propertyName)
        {
            throw new NotImplementedException();
        }
    }
    public class ControlParameter2
    {
        const string group1 = "通用延迟设定";
        const string group2 = "速度延迟设定";
        const string group3 = "轴重延迟设定-";

        [Display(Name = "参数1", GroupName = group1)]
        [Range(0, 1000000)]
        public decimal Param1 { get; set; }
        [Display(Name = "参数2", GroupName = group1)]
        [Range(0, 1000000)]
        public decimal Param2 { get; set; }
        [Display(Name = "参数3", GroupName = group2)]
        [Range(0, 1000000)]
        public decimal Param3 { get; set; }
        [Display(Name = "参数4", GroupName = group2)]
        [Range(0, 1000000)]
        public decimal Param4 { get; set; }
        [Display(Name = "参数5", GroupName = group2)]
        [Range(0, 1000000)]
        public decimal Param5 { get; set; }
        [Display(Name = "参数6", GroupName = group3)]
        [Range(0, 1000000)]
        public decimal Param6 { get; set; }
        [Display(Name = "参数7", GroupName = group3)]
        [Range(0, 1000000)]
        public decimal Param7 { get; set; }
        [Display(Name = "参数8", GroupName = group3)]
        [Range(0, 1000000)]
        public decimal Param8 { get; set; }
        [Display(Name = "参数9", GroupName = group3)]
        [Range(0, 1000000)]
        public decimal Param9 { get; set; }
        [Display(Name = "参数10", GroupName = group3)]
        [Range(0, 1000000)]
        public decimal Param10 { get; set; }

    }

    public class ControlParameter3
    {
        const string group1 = "串口参数设定";
        const string group2 = "仪表地址设定";
        const string group3 = "灯屏设定";

        [Display(Name = "参数1", GroupName = group1)]
        [Range(0, 1000000)]
        public decimal Param1 { get; set; }
        [Display(Name = "参数2", GroupName = group1)]
        [Range(0, 1000000)]
        public decimal Param2 { get; set; }
        [Display(Name = "参数3", GroupName = group2)]
        [Range(0, 1000000)]
        public decimal Param3 { get; set; }
        [Display(Name = "参数4", GroupName = group2)]
        [Range(0, 1000000)]
        public decimal Param4 { get; set; }
        [Display(Name = "参数5", GroupName = group2)]
        [Range(0, 1000000)]
        public decimal Param5 { get; set; }
        [Display(Name = "参数6", GroupName = group2)]
        [Range(0, 1000000)]
        public decimal Param6 { get; set; }
        [Display(Name = "参数7", GroupName = group3)]
        [Range(0, 1000000)]
        public decimal Param7 { get; set; }
        [Display(Name = "参数8", GroupName = group3)]
        [Range(0, 1000000)]
        public decimal Param8 { get; set; }
        [Display(Name = "参数9", GroupName = group3)]
        [Range(0, 1000000)]
        public decimal Param9 { get; set; }
        [Display(Name = "参数10", GroupName = group3)]
        [Range(0, 1000000)]
        public decimal Param10 { get; set; }

    }

    public class ControlParameter4
    {
        const string group1 = "AD采集卡";
        const string group2 = "轴重制动";
        const string group3 = "平扳制动";
        const string group4 = "速度-";

        [Display(Name = "参数1", GroupName = group1)]
        [Range(0, 1000000)]
        public decimal Param1 { get; set; }
        [Display(Name = "参数2", GroupName = group1)]
        [Range(0, 1000000)]
        public decimal Param2 { get; set; }
        [Display(Name = "参数3", GroupName = group2)]
        [Range(0, 1000000)]
        public decimal Param3 { get; set; }
        [Display(Name = "参数4", GroupName = group2)]
        [Range(0, 1000000)]
        public decimal Param4 { get; set; }
        [Display(Name = "参数5", GroupName = group2)]
        [Range(0, 1000000)]
        public decimal Param5 { get; set; }
        [Display(Name = "参数6", GroupName = group3)]
        [Range(0, 1000000)]
        public decimal Param6 { get; set; }
        [Display(Name = "参数7", GroupName = group3)]
        [Range(0, 1000000)]
        public decimal Param7 { get; set; }
        [Display(Name = "参数8", GroupName = group3)]
        [Range(0, 1000000)]
        public decimal Param8 { get; set; }
        [Display(Name = "参数9", GroupName = group4)]
        [Range(0, 1000000)]
        public decimal Param9 { get; set; }
        [Display(Name = "参数10", GroupName = group4)]
        [Range(0, 1000000)]
        public decimal Param10 { get; set; }

    }

    [MetadataType(typeof(AdvancedGroupedLayoutMetadata))]
    public class ControlParameter5
    {
        public string Name { get; set; }
        public string deviceNo { get; set; }
        [Range(0, 1000000)]
        public decimal Param1 { get; set; }
        [Display(Name = "参数2")]
        [Range(0, 1000000)]
        public decimal Param2 { get; set; }
        [Display(Name = "参数3")]
        [Range(0, 1000000)]
        public decimal Param3 { get; set; }
        [Display(Name = "参数4")]
        [Range(0, 1000000)]
        public decimal Param4 { get; set; }

    }

    public static class AdvancedGroupedLayoutMetadata
    {
        public static void BuildMetadata(MetadataBuilder<ControlParameter5> builder)
        {
            builder.DataFormLayout()
               .GroupBox("asdas")
               .Group("1", Orientation.Horizontal)
                   .ContainsProperty(x => x.Name)
                   .ContainsProperty(x => x.deviceNo)
                   .ContainsProperty(x => x.Param1)
               .EndGroup()
               .Group("2", Orientation.Horizontal)
                   .ContainsProperty(x => x.Param2)
                   .ContainsProperty(x => x.Param3)
                   .ContainsProperty(x => x.Param4)
               .EndGroup()
               .EndGroup();
            



            builder.Property(x => x.Name)
                .DisplayName("名称");
            builder.Property(x => x.deviceNo)
                .DisplayName("型号");
            builder.Property(x => x.Param1)
                .DisplayName("参数1");
        }
    }

}