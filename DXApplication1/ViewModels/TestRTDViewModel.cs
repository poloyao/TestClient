using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Threading;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Xpf.Core;
using System.ComponentModel.DataAnnotations;

namespace DXApplication1.ViewModels
{
    [POCOViewModel]
    public class TestRTDViewModel
    {
        public ObservableCollectionCore<RTDStation> Stations { get; set; }
        public ObservableCollectionCore<RTDItem> Data { get; set; }
        DispatcherTimer timer;


        public TestRTDViewModel()
        {
            Data = new ObservableCollectionCore<RTDItem>();
            Data.Add(RTDItem.CreateItem());
            Stations = new ObservableCollectionCore<RTDStation>();
            Stations.Add(new RTDStation() { StationNo = "一工位", StationName = "尾气检测" });
            Stations.Add(new RTDStation() { StationNo = "二工位", StationName = "测重检测" });
            Stations.Add(new RTDStation() { StationNo = "三工位", StationName = "外廓检测" });
            Stations.Add(new RTDStation() { StationNo = "四工位", StationName = "灯光检测" });
        }

        public void StartUpdate()
        {
            timer = new DispatcherTimer() { Interval = TimeSpan.FromMilliseconds(500) };
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        int CarIndex;
        private void Timer_Tick(object sender, EventArgs e)
        {
            Data.BeginUpdate();
            foreach (var item in Data)
            {
                if (item.Detect6 == null)
                    UpdateRTD(item);
            }
            if(Data.First().Detect6 != null)
                Data.Insert(0,(RTDItem.CreateItem()));
            Data.EndUpdate();

            Stations.BeginUpdate();

            if (CarIndex == 0)
                Stations.First().CarNo = Data.First().CarNo;
            else if (CarIndex == 4)
            {
                Stations[3].CarNo = string.Empty;
                CarIndex = 0;
                Stations.First().CarNo = Data.First().CarNo;
            }

            if (CarIndex != 0)
            {
                Stations[CarIndex].CarNo = Stations[CarIndex - 1].CarNo;
                Stations[CarIndex - 1].CarNo = string.Empty;
            }
            //if (CarIndex == 3)
            //    CarIndex = 0;
            //else
                CarIndex++;
            
            Stations.EndUpdate();
        }

        void UpdateRTD(RTDItem item)
        {
            item.Detect1 = true;
            var props = typeof(RTDItem).GetProperties();
            var detectList = props.Where(x => x.Name.Contains("Detect")).ToList();

            foreach (var det in detectList)
            {
                var temp = det.GetValue(item);
                if (temp == null)
                {
                    det.SetValue(item, true);
                    break;
                }                
            }

            

        }

        public void Start()
        {
            timer.Start();
        }

        public void Pause()
        {
            timer.Stop();
        }

    }

    public class RTDItem
    {
        [Display(Name ="车牌号")]
        public string CarNo { get; set; }
        [Display(Name = "车辆类型")]
        public string CarType { get; set; }
        [Display(Name = "监测点1")]
        public bool? Detect1 { get; set; }
        [Display(Name = "监测点2")]
        public bool? Detect2 { get; set; }
        [Display(Name = "监测点3")]
        public bool? Detect3 { get; set; }
        [Display(Name = "监测点4")]
        public bool? Detect4 { get; set; }
        public bool? Detect5 { get; set; }
        public bool? Detect6 { get; set; }

        public DateTime UDP { get; set; }


        public static RTDItem CreateItem()
        {
            RTDItem result = new RTDItem()
            {
                CarNo = $"辽A{new Random().Next(10000, 99999)}",
                UDP = DateTime.Now
            };
            return result;
        }
    }

    public class RTDStation
    {
        public string Name { get; set; }

        public string StationNo { get; set; }

        public string StationName { get; set; }

        public string CarNo { get; set; }
    }
}
