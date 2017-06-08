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
            SettingMenu.Add(new ViewModels.SettingMenu() { Title = "属性形式", ViewPath = "SetDetectorView", Description = "根据model的属性特性值来创建呈现的位置。具有分组、查询的功能" });
            SettingMenu.Add(new ViewModels.SettingMenu() { Title = "自动布局", ViewPath = "SetDetector2View", Description = "根据model的特性值创建呈现的位置，可横向排版，具有分组、tab标签的功能，但不具备查询功能。" });
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