using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using DevExpress.Utils;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DevExpress.Mvvm.POCO;

namespace DXApplication1.ViewModels
{
    [POCOViewModel]
    public class MainViewModel
    {
        /// <summary>
        /// 模块组
        /// </summary>
        public virtual IEnumerable<ModuleGroup> ModuleGroups { get; protected set; }
        public virtual ModuleInfo SelectedModuleInfo { get; set; }

        [Required]
        protected virtual ICurrentWindowService CurrentWindowService { get { return null; } }
        protected virtual ISplashScreenService SplashScreenService { get { return this.GetService<ISplashScreenService>(); } }

        public MainViewModel()
        {
            List<ModuleInfo> modules = new List<ModuleInfo>()
            {
                 ViewModelSource.Create(()=>new ModuleInfo("SettingView",this,"参数设置")).SetIcon("car"),
                  ViewModelSource.Create(()=>new ModuleInfo("SettingManageView",this,"参数设置")).SetIcon("car"),
                   ViewModelSource.Create(()=>new ModuleInfo("SetDetectorView",this,"参数设置")).SetIcon("car"),
                    ViewModelSource.Create(()=>new ModuleInfo("SettingView",this,"参数设置")).SetIcon("car"),
                     ViewModelSource.Create(()=>new ModuleInfo("SettingView",this,"参数设置")).SetIcon("car"),
                      ViewModelSource.Create(()=>new ModuleInfo("SettingView",this,"参数设置")).SetIcon("car"),
                       ViewModelSource.Create(()=>new ModuleInfo("SettingView",this,"参数设置")).SetIcon("car"),
                        ViewModelSource.Create(()=>new ModuleInfo("SettingView",this,"参数设置")).SetIcon("car"),


            };
            ModuleGroups = new ModuleGroup[] {
                new ModuleGroup("功能",modules)
            };

            var ass = this.GetService<INavigationService>();

        }


    }

    /// <summary>
    /// 模块
    /// </summary>
    public class ModuleInfo
    {
        ISupportServices parent;

        public ModuleInfo(string _type, object parent, string _title)
        {
            Type = _type;
            this.parent = (ISupportServices)parent;
            Title = _title;
        }

        public string Type { get; private set; }

        public virtual bool IsSelected { get; set; }

        public string Title { get; private set; }

        public virtual Uri Icon { get; set; }

        public ModuleInfo SetIcon(string icon)
        {
            this.Icon = AssemblyHelper.GetResourceUri(typeof(ModuleInfo).Assembly, string.Format("Img/{0}.png", icon));
            return this;
        }

        public void ClearNavigation()
        {
            INavigationService navigationService = parent.ServiceContainer.GetRequiredService<INavigationService>();
            navigationService.ClearNavigationHistory();
        }

        public void Show(object parameter = null)
        {
            try
            {
                if (IsSelected)
                {
                    INavigationService navigationService = parent.ServiceContainer.GetRequiredService<INavigationService>();
                    navigationService.Navigate(Type, parameter, parent);
                    IsSelected = false;
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }

    /// <summary>
    /// 模块组
    /// </summary>
    public class ModuleGroup
    {
        public ModuleGroup(string _title, IEnumerable<ModuleInfo> _moduleInfos)
        {
            Title = _title;
            ModuleInfos = _moduleInfos;
        }
        public string Title { get; private set; }
        public IEnumerable<ModuleInfo> ModuleInfos { get; private set; }
    }

}