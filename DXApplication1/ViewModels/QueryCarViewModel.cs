using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DXApplication1.ViewModels
{
    [POCOViewModel]
    public class QueryCarViewModel
    {
        public virtual ObservableCollection<QueryCaritem> Data { get; set; }
        public ObservableCollection<QueryCaritem> OldData { get; set; }

        public virtual string CarNo { get; set; } 

        public QueryCarViewModel()
        {
            Data = new ObservableCollection<QueryCaritem>();


            for (int i = 0; i < 100; i++)
            {
                Data.Add(new QueryCaritem()
                {
                    LineNo = "1",
                    CarNo = $"辽A{new Random(Guid.NewGuid().GetHashCode()).Next(10000, 99999)}",
                });
            }

            OldData = new ObservableCollection<QueryCaritem>(Data);
        }

        public void Query()
        {
            var query = OldData.Where(x => x.CarNo.Contains(CarNo)).ToList();
            Data = new ObservableCollection<QueryCaritem>(query);
        }

        public void Clear()
        {
            Data = new ObservableCollection<QueryCaritem>(OldData);
        }
    }


    public class QueryCaritem
    {
        public string LineNo { get; set; }

        public string CarNo { get; set; }

        public string LicenseType { get; set; }

        public string CarType { get; set; }

        public int Number { get; set; }

        public string UnitName { get; set; }

        public DateTime CheckDate { get; set; }

        public string SerialNumber { get; set; }

        public bool IsCorrect { get; set; }

    }
}