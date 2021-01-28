using Machine_APP.dal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Machine_APP.model;
// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace Machine_APP
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class App_sys_config : Page
    {
        public ObservableCollection<SYS_CONFIG> sconfigs { get; } = new ObservableCollection<SYS_CONFIG>();
        public ObservableCollection<SYS_SETTING> sseets { get; } = new ObservableCollection<SYS_SETTING>();
        public App_sys_config()
        {
            try
            {
                SYS_CONFIG_DAL pdal = new SYS_CONFIG_DAL();
                List<SYS_CONFIG> plist = pdal.getlist();
                foreach (var item in plist)
                {

                }
            }
            catch (Exception ex)
            {
                Log_dal ld = new Log_dal();
                ld.addLog(0, "App_sys_config  Error:" + ex.Message, DateTime.Now.ToString(), "");
            }
        }
    }
}
