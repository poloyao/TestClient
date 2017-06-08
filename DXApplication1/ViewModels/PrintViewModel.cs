using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using System.Collections.ObjectModel;

namespace DXApplication1.ViewModels
{
    [POCOViewModel]
    public class PrintViewModel
    {
        public virtual ObservableCollection<QueryCaritem> Data { get; set; }

        public PrintViewModel()
        {
            Data = new ObservableCollection<QueryCaritem>();
            for (int i = 0; i < 1000; i++)
            {
                Data.Add(new QueryCaritem()
                {
                    LineNo = "1",
                    CarNo = $"辽A{new Random(Guid.NewGuid().GetHashCode()).Next(10000, 99999)}",
                });
            }
        }
    }
}