using System;
using System.Collections.Generic;
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

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace Machine_APP
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class AppConfig : Page
    {
        public AppConfig()
        {
            this.InitializeComponent();
        }

        private void but_pro_edit_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ProductEdit), null);
        }

        private void but_sys_edit_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(App_sys_config), null);
        }

        private void but_row_edit_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Shelves_edit), null);
        }

        private void but_back_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(BuyMain), null);
        }
    }
}
