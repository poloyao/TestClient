using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using System.Collections.Generic;

namespace DXApplication1.ViewModels
{
    [POCOViewModel]
    public class SettingManageViewModel
    {

        public virtual List<SettingMenu> SettingMenu { get; set; } = new List<ViewModels.SettingMenu>();

        public SettingManageViewModel()
        {
            SettingMenu.Add(new ViewModels.SettingMenu() { Title = "基本参数", Description = "描述信息" });
            SettingMenu.Add(new ViewModels.SettingMenu() { Title = "基本参数1", Description = "描述信息" });
            SettingMenu.Add(new ViewModels.SettingMenu() { Title = "基本参数2", Description = "描述信息" });
            SettingMenu.Add(new ViewModels.SettingMenu() { Title = "基本参数3", Description = "描述信息" });
        }

    }

    public class SettingMenu
    {
        public virtual string Description { get; set; }

        public virtual string Title { get; set; }
    }
}