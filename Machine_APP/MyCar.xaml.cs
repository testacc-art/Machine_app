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
using System.Data;
// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace Machine_APP
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MyCar : Page
    {

        public MyCar()
        {
            this.InitializeComponent();
            SetData();
        }


        public void SetData()
        {
            for (int i = 0; i < (Application.Current as App).pdlist.Count(); i++)
            {
                Grid gd = this.Content as Grid;
                Grid grid_1 = null;
                Windows.UI.Xaml.Controls.StackPanel sp = null;
                foreach (var item in gd.Children)
                {
                    if (((Windows.UI.Xaml.FrameworkElement)item).Name == "grid_1")
                    {
                        grid_1 = item as Grid;
                        break;
                    }
                }
                foreach (var item1 in grid_1.Children)
                {
                    string name1 = "";
                    name1 = "sp_" + (i + 1).ToString();
                    //name1 += name1 + "_"+(i+1).ToString();

                    if (((Windows.UI.Xaml.FrameworkElement)item1).Name == name1 + "_1")
                    {
                        sp = item1 as StackPanel;
                        sp.Visibility = Visibility.Visible;
                    }
                    if (((Windows.UI.Xaml.FrameworkElement)item1).Name == name1 + "_2")
                    {
                        sp = item1 as StackPanel;
                        sp.Visibility = Visibility.Visible;
                        foreach (var item in sp.Children)
                        {
                            Windows.UI.Xaml.Controls.TextBlock txt = item as Windows.UI.Xaml.Controls.TextBlock;
                            txt.Text = (Application.Current as App).pdlist[i].ProductName1;
                            break;
                        }

                    }
                    if (((Windows.UI.Xaml.FrameworkElement)item1).Name == name1 + "_3")
                    {
                        sp = item1 as StackPanel;
                        sp.Visibility = Visibility.Visible;
                        foreach (var item in sp.Children)
                        {
                            if (((Windows.UI.Xaml.FrameworkElement)item).Name == name1.Replace("sp", "txt") + "_3")
                            {
                                Windows.UI.Xaml.Controls.TextBox txt = item as Windows.UI.Xaml.Controls.TextBox;
                                txt.Text = (Application.Current as App).pdlist[i].OutNum1.ToString();
                                break;

                            }

                        }


                    }
                }

            }

        }
        private void but_next_Click(object sender, RoutedEventArgs e)
        {

            //主表
            string payNo = "payNo" + DateTime.Now.ToString();
            double amount = 0;
            int num = 0;
            for (int i = 0; i < (Application.Current as App).pdlist.Count(); i++)
            {
                amount += (Application.Current as App).pdlist[i].PayAmount1;
                num += (Application.Current as App).pdlist[i].OutNum1;
            }
                        (Application.Current as App).pr = new PAY_RECORD(payNo, "payUserID",
             "channelCode", "machineCode", 0, "payType", "payAccount", amount, 0, num, 0.00, 0.00, 0.00,
            0.00, 0.00, 0, " cashCode", "reator", DateTime.Now, "modifier", DateTime.Now);


            dal.PAY_RECORD_DAL prd = new dal.PAY_RECORD_DAL((Application.Current as App).pr);
            //主表主键
            //prd.record.PayNo1 = "PayNo" + DateTime.Now.ToString();
            //insert
            prd.insertData();

            //循环设置子表外键，并insert子表
            dal.PAY_DETAILS_DAL pdd = new dal.PAY_DETAILS_DAL();
            foreach (PAY_DETAILS item in (Application.Current as App).pdlist)
            {
                pdd.detail = item;
                pdd.detail.PayNo1 = prd.record.PayNo1;
                pdd.insertData();
            }

            Frame.Navigate(typeof(MyPay), null);
        }
        private void add_Click(object sender, RoutedEventArgs e)
        {
            string basename = ((Windows.UI.Xaml.FrameworkElement)sender).Name;
            Windows.UI.Xaml.Controls.TextBox plotBorder = (Windows.UI.Xaml.Controls.TextBox)FindName(basename.Replace("add", "txt"));
            int n = int.Parse(plotBorder.Text);
            plotBorder.Text = (n + 1).ToString();
            char[] al = { '_' };
            int listnum = int.Parse(basename.Split(al)[1].ToString());
            (Application.Current as App).pdlist[listnum - 1].OutNum1 = int.Parse(plotBorder.Text);



        }
        private void min_Click(object sender, RoutedEventArgs e)
        {
            string basename = ((Windows.UI.Xaml.FrameworkElement)sender).Name;
            Windows.UI.Xaml.Controls.TextBox plotBorder = (Windows.UI.Xaml.Controls.TextBox)FindName(basename.Replace("min", "txt"));
            int n = int.Parse(plotBorder.Text);
            if (n == 0)
                return;
            plotBorder.Text = (n - 1).ToString();
            char[] al = { '_' };
            int listnum = int.Parse(basename.Split(al)[1].ToString());
            (Application.Current as App).pdlist[listnum - 1].OutNum1 = int.Parse(plotBorder.Text);
        }

        private void del_Click(object sender, RoutedEventArgs e)
        {
            string basename = ((Windows.UI.Xaml.FrameworkElement)sender).Name;
            Windows.UI.Xaml.Controls.TextBox plotBorder = (Windows.UI.Xaml.Controls.TextBox)FindName(basename.Replace("del", "txt"));
           
            plotBorder.Text = "0";
            char[] al = { '_' };
            int listnum = int.Parse(basename.Split(al)[1].ToString());
            (Application.Current as App).pdlist[listnum - 1].OutNum1 = int.Parse(plotBorder.Text);
        }
    }
    //public void datebing()
    //    {



    //    }

}
