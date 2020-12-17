using Machine_APP.dal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.ServiceModel.Channels;
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
    public sealed partial class ProductEdit : Page
    {

        string ChannelCode1 = "";
        string MachineCode1 = "";
        string ProductName1 = "";
        string Price1 = "";
        string ProductNum1 = "";
        public ObservableCollection<PRODUCT> PRODUCTs { get; } = new ObservableCollection<PRODUCT>();
        public ProductEdit()
        {
            this.InitializeComponent();
            APP_PRODUCT_DAL pdal = new APP_PRODUCT_DAL();
            List<PRODUCT> plist = pdal.getlist();
            foreach (var item in plist)
            {
                PRODUCTs.Add(item);
            }
        }

        private void but_clear_Click(object sender, RoutedEventArgs e)
        {
            //Button but = sender as Button;
            //string a = but.Content.ToString();
            //string b = but.Command.ToString();
        }

        private void but_sub_Click(object sender, RoutedEventArgs e)
        {
            string updatesql = "update APP_PRODUCT set  productname='{0}',price={1},discountprice={1},ProductNum={2} where ChannelCode='{3}' and MachineCode='{4}'";

            Button but =  sender as Button;
            string aa = but.Name;
            StackPanel sp = but.Parent as StackPanel;
            
            for (int i = 0; i < sp.Children.Count; i++)
            {
                if (i == 0)
                {
                    TextBlock tb = sp.Children[0] as TextBlock;
                    ChannelCode1 = tb.Text;
                }
                if (i == 1)
                {
                    TextBlock tb = sp.Children[1] as TextBlock;
                    MachineCode1 = tb.Text;
                }
                if (i == 2)
                {
                    TextBox tb = sp.Children[2] as TextBox;
                    ProductName1 = tb.Text;
                }
                if (i == 3)
                {
                    TextBox tb = sp.Children[3] as TextBox;
                    Price1 = tb.Text;
                    double a = 0;
                    if (!double.TryParse(Price1, out a))
                    {

                        var dialog = new ContentDialog()
                        {
                            Title = "消息提示",
                            Content = "当前输入值错误",
                            PrimaryButtonText = "确定",
                            //SecondaryButtonText = "取消",
                            FullSizeDesired = false,
                        };
                        dialog.PrimaryButtonClick += (_s, _e) => { };
                        dialog.ShowAsync();
                    }
                }
                if (i == 4)
                {
                    TextBox tb = sp.Children[4] as TextBox;
                    ProductNum1 = tb.Text;
                    double a = 0;
                    if (!double.TryParse(Price1, out a))
                    {

                        var dialog = new ContentDialog()
                        {
                            Title = "消息提示",
                            Content = "当前输入值错误",
                            PrimaryButtonText = "确定",
                            //SecondaryButtonText = "取消",
                            FullSizeDesired = false,
                        };
                        dialog.PrimaryButtonClick += (_s, _e) => { };
                        dialog.ShowAsync();
                    }
                }
            }

            APP_PRODUCT_DAL dal = new APP_PRODUCT_DAL();
            dal.updateforsql(string.Format(updatesql, ProductName1,double.Parse(Price1), double.Parse(ProductNum1), ChannelCode1, MachineCode1));
            var dialogOK = new ContentDialog()
            {
                Title = "消息提示",
                Content = "保存成功",
                PrimaryButtonText = "确定",
                //SecondaryButtonText = "取消",
                FullSizeDesired = false,
            };
            dialogOK.PrimaryButtonClick += (_s, _e) => { };
            dialogOK.ShowAsync();
            ChannelCode1 = "";
            MachineCode1 = "";
            ProductName1 = "";
            Price1 = "";
            ProductNum1 = "";
        }

        private void but_edit_Click(object sender, RoutedEventArgs e)
        {
            ChannelCode1 = "";
            MachineCode1 = "";
            ProductName1 = "";
            Price1 = "";
            ProductNum1 = "";
            Button but = sender as Button;
            string aa = but.Name;
            StackPanel sp = but.Parent as StackPanel;

            for (int i = 0; i < sp.Children.Count; i++)
            {
                if (i == 0)
                {
                    TextBlock tb = sp.Children[0] as TextBlock;
                    ChannelCode1 = tb.Text;
                }
                if (i == 1)
                {
                    TextBlock tb = sp.Children[1] as TextBlock;
                    MachineCode1 = tb.Text;
                }
                if (i == 2)
                {
                    TextBox tb = sp.Children[2] as TextBox;
                    ProductName1 = tb.Text;
                }
            }
            this.Frame.Navigate(typeof(ProductEditbysingle), new { ChannelCode = ChannelCode1, MachineCode = MachineCode1 });
        }

        private void but_new_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ProductEditbysingle), new { ChannelCode = "", MachineCode = "" });
        }

        //private void but_new_Click(object sender, RoutedEventArgs e)
        //{
        //    this.Frame.Navigate(typeof(ProductEditbysingle), new { ChannelCode = "", MachineCode = "" });
        //}
    }
}
