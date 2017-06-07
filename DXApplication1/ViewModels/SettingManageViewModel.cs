using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Mvvm.POCO;

namespace DXApplication1.ViewModels
{
    [POCOViewModel]
    public class SettingManageViewModel
    {
        protected INavigationService NavigationService { get { return this.GetService<INavigationService>(); } }
        protected IDocumentManagerService documentManagerService { get{ return this.GetService<IDocumentManagerService>(); } }

        public virtual List<SettingMenu> SettingMenu { get; set; } = new List<ViewModels.SettingMenu>();

        public virtual string Title { get; set; } = "121";

        public SettingManageViewModel()
        {
            SettingMenu.Add(new ViewModels.SettingMenu() { Title = "基本参数", ViewPath = "SetDetectorView", Description = "描述信息" });
            SettingMenu.Add(new ViewModels.SettingMenu() { Title = "基本参数1", ViewPath = "SetDetector2View", Description = "描述信息" });
            //SettingMenu.Add(new ViewModels.SettingMenu() { Title = "基本参数2", ViewPath = "", Description = "描述信息" });
            //SettingMenu.Add(new ViewModels.SettingMenu() { Title = "基本参数3", ViewPath = "", Description = "描述信息" });
                                    
            
        }

        public void Selected(SettingMenu item)
        {
            //NavigationService.Navigate("SetDetectorView", null, this);
            IDocument doc = documentManagerService.CreateDocument(item.ViewPath, null, this);
            doc.Id = documentManagerService.Documents.Count();
            doc.Title = item.Title;
            doc.Show();
        }

    }

    public class SettingMenu
    {
        public virtual string Description { get; set; }

        public virtual string Title { get; set; }

        public virtual string ViewPath { get; set; }
    }
    
}